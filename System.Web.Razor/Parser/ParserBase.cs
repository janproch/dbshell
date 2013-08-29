using System.Web.Razor.Parser.SyntaxTree;
using System.Web.Razor.Resources;
using System.Web.Razor.Text;
using System.Web.Razor.Utils;
using System.Diagnostics;

namespace System.Web.Razor.Parser {
    public abstract class ParserBase {
        private ParserContext _context;
        public ParserContext Context {
            get { return _context; }
            set {
                //Debug.Assert(_context == null, "Context has already been set for this parser!");
                _context = value;
                _context.AssertOnOwnerTask();
            }
        }

        protected abstract ParserBase OtherParser { get; }

        public virtual bool IsAtExplicitTransition() { return false; }
        public virtual bool IsAtImplicitTransition() { return false; }
        
        public virtual bool IsAtTransition() {
            return IsAtImplicitTransition() || IsAtExplicitTransition();
        }

        // Simple wrapper properties for commonly used context properties
        protected bool HaveContent { get { return Context.HaveContent; } }
        protected bool InTemporaryBuffer { get { return Context.InTemporaryBuffer; } }
        protected bool DesignTimeMode { get { return Context.DesignTimeMode; } }
        protected bool EndOfFile { get { return Context.EndOfFile; } }
        protected char CurrentCharacter { get { return Context.CurrentCharacter; } }
        protected SourceLocation CurrentLocation { get { return Context.CurrentLocation; } }

        public virtual bool NextIsTransition(bool allowImplicit, bool allowExplicit) {
            using (Context.StartTemporaryBuffer()) {
                Context.AcceptCurrent();
                return (allowExplicit && IsAtExplicitTransition()) ||
                       (allowImplicit && IsAtImplicitTransition());
            }
        }

        public abstract void ParseBlock();

        // Simple wrapper methods for commonly used context methods
        protected IDisposable StartBlock(BlockType type) {
            return StartBlock(type, true);
        }

        protected IDisposable StartBlock(BlockType type, bool outputCurrentAsTransition) { 
            return Context.StartBlock(type, outputCurrentAsTransition); 
        }

        protected void EndBlock() { Context.EndBlock(); }
        protected void Output(Span span) { Context.OutputSpan(span); }

        protected void OnError(SourceLocation location, string message) {
            Context.OnError(location, message);
        }

        protected void OnError(SourceLocation location, string message, params object[] args) {
            Context.OnError(location, message, args);
        }

        protected void End(SpanFactory spanFactory) {
            if (HaveContent || !Context.PreviousSpanCanGrow) {
                if (Context.InTemporaryBuffer) {
                    throw new InvalidOperationException(RazorResources.Cannot_Call_EndSpan_From_Temporary_Buffer);
                }
                End(spanFactory(Context));
            }
        }

        protected void End(Span span) {
            Context.OutputSpan(span); 
            Context.ResetBuffers(); 
        }

        protected void ParseBlockWithOtherParser(SpanFactory previousSpanFactory) {
            ParseBlockWithOtherParser(previousSpanFactory, false);
        }

        protected void ParseBlockWithOtherParser(SpanFactory previousSpanFactory, bool collectTransitionToken) {
            // Capture the current span if we have one
            if (TryParseComment(previousSpanFactory)) {
                return;
            }

            Span prev = null;
            if (HaveContent) {
                prev = previousSpanFactory(Context);
                Context.ResetBuffers();
            }

            // Skip over the switch token if requested
            if (collectTransitionToken) {
                Context.AcceptCurrent();
            }

            if (collectTransitionToken && CurrentCharacter == RazorParser.TransitionCharacter) {
                // We were told to handle the transition token and found another transition character ==> Escape sequence

                // Output the previous content and a hidden token so that the first at of the escape sequence doesn't get rendered
                if (prev != null) {
                    Output(prev);
                }
                Span span = previousSpanFactory(Context);
                Context.ResetBuffers();
                span.Hidden = true;
                Output(span);

                // Now accept the current transition token so it doesn't get treated as a transition and return to the current context
                Context.AcceptCurrent();
            }
            else {
                if (prev != null) {
                    Output(prev);
                }

                // Switch to the other parser
                Context.SwitchActiveParser();

                // Have the other parser parse a block starting with the character after the '@'
                Context.ActiveParser.ParseBlock();
                
                // Switch back
                Context.SwitchActiveParser();

                // Once we're done, start a new span
                Context.ResetBuffers();
            }
        }

        protected bool TryParseComment(SpanFactory previousSpanFactory) {
            // Check for comment
            using (Context.StartTemporaryBuffer()) {
                Context.AcceptWhiteSpace(includeNewLines: true);
                if (Context.Peek(RazorParser.StartCommentSequence, caseSensitive: true)) {
                    Context.AcceptTemporaryBuffer();
                    End(previousSpanFactory);
                }
                else {
                    return false;
                }
            }

            ParseComment();
            return true;
        }

        protected void ParseComment() {
            using (StartBlock(BlockType.Comment)) {
                SourceLocation startLocation = CurrentLocation;
                Context.Expect(RazorParser.StartCommentSequence[0]);
                End(TransitionSpan.Create(Context, hidden: false, acceptedCharacters: AcceptedCharacters.None));

                Context.Expect(RazorParser.StartCommentSequence[1]);
                End(MetaCodeSpan.Create(Context, hidden: false, acceptedCharacters: AcceptedCharacters.None));

                bool inComment = true;
                while (inComment && !EndOfFile) {
                    Context.AcceptUntil(RazorParser.EndCommentSequence[0]);
                    if (Context.Peek(RazorParser.EndCommentSequence, caseSensitive: true)) {
                        inComment = false;
                    }
                    else {
                        Context.AcceptCurrent();
                    }
                }
                End(CommentSpan.Create);
                if (EndOfFile) {
                    OnError(startLocation, RazorResources.ParseError_RazorComment_Not_Terminated);
                }
                else {
                    Context.Expect(RazorParser.EndCommentSequence[0]);
                    End(MetaCodeSpan.Create(Context, hidden: false, acceptedCharacters: AcceptedCharacters.None));
                    Context.Expect(RazorParser.EndCommentSequence[1]);
                    End(TransitionSpan.Create(Context, hidden: false, acceptedCharacters: AcceptedCharacters.None));
                }
            }
        }

        protected void AcceptLineWithBlockComments(ParserContext context, SpanFactory spanFactory) {
            // Read to the end of the line checking for plan9 block comments
            bool keepReading = true;
            while (keepReading) {
                if (CharUtils.IsNewLine(context.CurrentCharacter)) {
                    context.AcceptNewLine();
                    keepReading = false;
                }
                else if (!TryParseComment(spanFactory)) {
                    context.AcceptCurrent();
                }
            }
        }
    }
}
