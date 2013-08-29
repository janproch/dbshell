using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web.Razor.Parser.SyntaxTree;
using System.Web.Razor.Resources;
using System.Web.Razor.Text;
using System.Globalization;

namespace System.Web.Razor.Parser {
    /// <summary>
    /// A helper base class for code parsers
    /// </summary>
    /// <remarks>
    /// Code parsers are not _required_ to inherit from this class, they can inherit from ParserBase.  However, this class
    /// provides helpful methods common to many code parsers.
    /// </remarks>
    public abstract class CodeParser : ParserBase {
        protected internal delegate bool BlockParser(CodeBlockInfo block);

        protected override ParserBase OtherParser {
            get { return Context.MarkupParser; }
        }

        private static Dictionary<char, char> _bracketPairs = new Dictionary<char, char>() {
            { '{', '}' },
            { '(', ')' },
            { '[', ']' },
            { '<', '>' }
        };

        protected internal virtual ISet<string> TopLevelKeywords {
            get { return null; }
        }

        protected internal abstract bool TryAcceptStringOrComment();
        protected internal abstract bool HandleTransition(SpanFactory spanFactory);
        protected internal abstract void AcceptGenericArgument();
        protected virtual bool TryRecover(bool allowTransition, SpanFactory previousSpanFactory) {
            return false;
        }

        protected void AcceptTypeName() {
            AcceptTypeName(allowGenerics: true);
        }

        protected void AcceptTypeName(bool allowGenerics) {
            do {
                if (CurrentCharacter == '.') {
                    Context.AcceptCurrent();
                }
                Context.AcceptIdentifier();
                if (allowGenerics) {
                    AcceptGenericArgument();
                }
            } while (CurrentCharacter == '.');
        }

        protected virtual void AcceptUntilUnquoted(Predicate<char> condition) {
            while (!EndOfFile) {
                if (!TryAcceptStringOrComment()) {
                    if (condition(CurrentCharacter)) {
                        return;
                    }
                    Context.AcceptCurrent();
                }
            }
        }

        private SpanFactory CreateImplicitExpressionSpanFactory(bool acceptTrailingDot) {
            return context => CreateImplicitExpressionSpan(context, acceptTrailingDot, AcceptedCharacters.Any);
        }

        protected virtual ImplicitExpressionSpan CreateImplicitExpressionSpan(ParserContext context, bool acceptTrailingDot, AcceptedCharacters accepted) {
            return ImplicitExpressionSpan.Create(context, TopLevelKeywords, acceptTrailingDot, accepted);
        }

        protected AcceptedCharacters AcceptDottedExpression(bool isWithinCode, bool expectIdentifierFirst, params char[] allowedBrackets) {
            if (!expectIdentifierFirst || ParserHelpers.IsIdentifierStart(CurrentCharacter)) {
                do {
                    // Parse Parentheses or Brackets if we see them
                    do {
                        if (!allowedBrackets.Any(c => CurrentCharacter == c)) {
                            break;
                        }

                        // Dev10 884975 - Incorrect Error Messaging
                        SourceLocation bracketStart = CurrentLocation;
                        char bracket = CurrentCharacter;

                        if (!BalanceBrackets(allowTransition: true, spanFactory: CreateImplicitExpressionSpanFactory(isWithinCode))) {
                            // Balancing terminated because of EOF
                            char terminator = _bracketPairs[bracket];
                            Context.AcceptCurrent();

                            TryRecover(RecoveryModes.Any);

                            OnError(bracketStart, RazorResources.ParseError_Expected_CloseBracket_Before_EOF, bracket, terminator);
                            return AcceptedCharacters.Any;
                        }

                    } while (!EndOfFile);

                    // If the next character is a dot, followed by an identifier start, keep on parsing
                    using (Context.StartTemporaryBuffer()) {
                        if (CurrentCharacter != '.') {
                            break;
                        }

                        Context.AcceptCurrent();

                        if (!ParserHelpers.IsIdentifierStart(CurrentCharacter)) {
                            if (isWithinCode) {
                                Context.AcceptTemporaryBuffer();
                            }
                            break;
                        }

                        Context.AcceptTemporaryBuffer(); // Put the dot in the primary buffer
                    }

                    // Parse an identifier
                    Context.AcceptIdentifier();
                } while (!EndOfFile);
            }

            return AcceptedCharacters.NonWhiteSpace;
        }

        protected bool TryRecover(RecoveryModes mode) {
            return TryRecover(mode, ch => false, allowTransition: false, previousSpanFactory: null);
        }

        protected bool TryRecover(RecoveryModes mode,
                                  Predicate<char> condition,
                                  bool allowTransition,
                                  SpanFactory previousSpanFactory) {
            bool anyNewLines = false;
            while (!EndOfFile && !condition(CurrentCharacter)) {
                // Eat whitespace
                Context.AcceptWhiteSpace(false);

                if (mode.HasFlag(RecoveryModes.Markup)) {
                    // If we see new lines before a '<' then assume it's markup. 
                    // This isn't 100% correct but it is the 80/90% case when typing razor code
                    if (anyNewLines && Context.MarkupParser.IsStartTag()) {
                        return true;
                    }

                    // End tags are mostly unambiguous
                    // REVIEW: Does this make sense?
                    if (Context.MarkupParser.IsEndTag()) {
                        return true;
                    }
                }

                if (mode.HasFlag(RecoveryModes.Code)) {
                    if (TryRecover(allowTransition, previousSpanFactory)) {
                        return true;
                    }
                }

                if (mode.HasFlag(RecoveryModes.Transition)) {
                    if (CurrentCharacter == RazorParser.TransitionCharacter) {
                        return true;
                    }
                }

                anyNewLines = ParserHelpers.IsNewLine(CurrentCharacter);

                Context.AcceptCurrent();
            }
            return false;
        }
        
        private void AcceptOrSkipCurrent(bool appendOuter, int nesting) {
            if (nesting > 0 || appendOuter) {
                Context.AcceptCurrent();
            }
            else {
                Context.SkipCurrent();
            }
        }

        protected bool RequireSingleWhiteSpace() {
            if (Char.IsWhiteSpace(CurrentCharacter)) {
                if (ParserHelpers.IsNewLine(CurrentCharacter)) {
                    Context.AcceptNewLine();
                }
                else {
                    Context.AcceptCurrent();
                }
                return true;
            }
            return false;
        }

        protected CodeBlockInfo ParseBlockStart(bool isTopLevel, bool captureTransition) {
            // Capture the transition token, if any, into a span
            Span transitionSpan = null;
            if (HaveContent && captureTransition) {
                transitionSpan = TransitionSpan.Create(Context, hidden: false, acceptedCharacters: AcceptedCharacters.None);
                Context.ResetBuffers();
            }

            SourceLocation start = CurrentLocation;
            string identifier = Context.AcceptIdentifier();

            Span initialSpan = null;
            if (isTopLevel) {
                initialSpan = CodeSpan.Create(Context);
                Context.ResetBuffers();
            }

            CodeBlockInfo block = new CodeBlockInfo(identifier, start, isTopLevel, transitionSpan, initialSpan);
            return block;
        }

        // Must be context from within a temporary buffer
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "ByLines", Justification = "This is not intended to reference the term 'bylines' but the two word phrase 'by lines'")]
        protected virtual void AcceptWhiteSpaceByLines() {
            Debug.Assert(InTemporaryBuffer);

            // Eat whitespace until a non-whitespace character, 
            while (Char.IsWhiteSpace(CurrentCharacter)) {
                Context.AcceptWhiteSpace(includeNewLines: false);

                // Stopped because of a newline, so accept the newline, then accept the temporary buffer and start it again
                if (Char.IsWhiteSpace(CurrentCharacter)) {
                    Context.AcceptLine(includeNewLineSequence: true);
                    Context.AcceptTemporaryBuffer();
                    Context.StartTemporaryBuffer();
                }
            }
        }

        protected bool BalanceBrackets() {
            return BalanceBrackets(false);
        }

        protected bool BalanceBrackets(bool allowTransition) {
            return BalanceBrackets(allowTransition, null, true, null, true);
        }

        protected bool BalanceBrackets(bool allowTransition, SpanFactory spanFactory) {
            return BalanceBrackets(allowTransition, spanFactory, true, null, true);
        }

        protected bool BalanceBrackets(bool allowTransition, SpanFactory spanFactory, bool appendOuter) {
            return BalanceBrackets(allowTransition, spanFactory, appendOuter, null, true);
        }

        protected bool BalanceBrackets(bool allowTransition, SpanFactory spanFactory, bool appendOuter, char bracket) {
            return BalanceBrackets(allowTransition, spanFactory, appendOuter, bracket, true);
        }

        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "To be fixed soon. Dev10 Bug 917893")]
        protected virtual bool BalanceBrackets(bool allowTransition, SpanFactory spanFactory, bool appendOuter, char? bracket, bool useTemporaryBuffer) {
            spanFactory = spanFactory ?? CodeSpan.Create;

            if (useTemporaryBuffer) {
                Context.StartTemporaryBuffer();
            }

            int nesting = 0; // Nesting level
            bool callerReadBracket = true;
            if (bracket == null) {
                callerReadBracket = false;
                bracket = CurrentCharacter;
            }
            else {
                // The caller already read the bracket, so start at nesting level 1, and also, don't append the outer bracket
                nesting = 1;
            }
            char terminator = _bracketPairs[bracket.Value];

            do {
                // Gather whitespace
                Context.StartTemporaryBuffer();
                AcceptWhiteSpaceByLines();

                if (CurrentCharacter == RazorParser.TransitionCharacter) {
                    if (Context.Peek(RazorParser.StartCommentSequence, caseSensitive: true)) {
                        Context.AcceptTemporaryBuffer();
                        if (useTemporaryBuffer) {
                            Context.AcceptTemporaryBuffer();
                        }
                        End(spanFactory);
                        ParseComment();
                        if (useTemporaryBuffer) {
                            Context.StartTemporaryBuffer();
                        }
                    }
                    else if (allowTransition) {
                        Context.RejectTemporaryBuffer();
                        if (!HandleTransition(spanFactory)) {
                            Context.AcceptWhiteSpace(includeNewLines: true);
                            if (!TryAcceptStringOrComment()) {
                                Context.AssertCurrent(RazorParser.TransitionCharacter);
                                Context.AcceptCurrent();
                            }
                        }
                        else if (useTemporaryBuffer) {
                            // Start a new outer temporary buffer
                            Context.StartTemporaryBuffer();
                        }
                    }
                    else {
                        Context.AcceptTemporaryBuffer();
                        if (!TryAcceptStringOrComment()) {
                            Context.AcceptCurrent();
                        }
                    }
                }
                else {
                    Context.AcceptTemporaryBuffer();
                }

                AcceptUntilUnquoted(c => Char.IsWhiteSpace(c) || c == bracket || c == terminator || c == RazorParser.TransitionCharacter);
                if (CurrentCharacter == terminator) {
                    // If the nesting level is 1 and no bracket was specified, don't read the terminator, but we are done
                    if (nesting == 1 && callerReadBracket) {
                        nesting--;
                    }
                    else {
                        AcceptOrSkipCurrent(appendOuter, --nesting);
                    }
                }
                else if (CurrentCharacter == bracket) {
                    AcceptOrSkipCurrent(appendOuter, nesting++);
                }
            } while (!EndOfFile && nesting > 0);

            if (useTemporaryBuffer) {
                if (nesting > 0) {
                    Context.RejectTemporaryBuffer();
                }
                else {
                    Context.AcceptTemporaryBuffer();
                }
            }

            Debug.Assert(!InTemporaryBuffer);
            return nesting == 0; // Return a boolean indicating if we exited because of EOF or because of the end bracket
        }
    }
}
