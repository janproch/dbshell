using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Razor.Parser.SyntaxTree;
using System.Web.Razor.Resources;
using System.Web.Razor.Text;

namespace System.Web.Razor.Parser {
    public class HtmlMarkupParser : MarkupParser {
        private const string PseudoTagName = "text";
        private const char TagTransitionCharacter = '<';
        private const char LineTransitionCharacter = ':';

        private class TagInfo {
            public string Name { get; set; }
            public SourceLocation Start { get; set; }
            public bool IsEndTag { get; set; }

            public TagInfo(string tagName, SourceLocation start, bool isEndTag) {
                Name = tagName;
                Start = start;
                IsEndTag = isEndTag;
            }
        }

        public override bool IsAtExplicitTransition() {
            return CurrentCharacter == LineTransitionCharacter;
        }

        public override bool IsAtImplicitTransition() {
            return CurrentCharacter == TagTransitionCharacter;
        }

        public override void ParseSection(Tuple<string, string> nestingSequences, bool caseSensitive) {
            if (Context == null) { throw new InvalidOperationException(RazorResources.Parser_Context_Not_Set); }

            ParseRootBlock(nestingSequences, caseSensitive);
        }

        public override void ParseDocument() {
            if (Context == null) { throw new InvalidOperationException(RazorResources.Parser_Context_Not_Set); }

            ParseRootBlock(null);
        }

        private void ParseRootBlock(Tuple<string, string> nestingSequences, bool caseSensitive = true) {
            // We're only document level there are no nesting sequences
            bool documentLevel = nestingSequences == null;

            // Start a markup block
            using (StartBlock(BlockType.Markup)) {
                int nesting = 1;
                do {
                    if (nestingSequences != null && nestingSequences.Item1 != null && Context.Peek(nestingSequences.Item1, caseSensitive: caseSensitive)) {
                        nesting++;
                        Context.Expect(nestingSequences.Item1, outputError: true, errorMessage: null, caseSensitive: caseSensitive);
                    }
                    else if (nestingSequences != null && Context.Peek(nestingSequences.Item2, caseSensitive: caseSensitive)) {
                        nesting--;
                        if (nesting > 0) {
                            Context.Expect(nestingSequences.Item2, outputError: true, errorMessage: null, caseSensitive: caseSensitive);
                        }
                    }
                    else if (!TryStartCodeParser(documentLevel: documentLevel)) {
                        Context.UpdateSeenValidEmailPrefix();
                        Context.AcceptCurrent();
                    }
                } while (!EndOfFile && (nestingSequences == null || nesting > 0));

                if (!Context.PreviousSpanCanGrow || HaveContent) {
                    var span = MarkupSpan.Create(Context);
                    span.DocumentLevel = documentLevel;
                    End(span);
                }
            }
        }

        public override void ParseBlock() {
            if (Context == null) { throw new InvalidOperationException(RazorResources.Parser_Context_Not_Set); }

            using (StartBlock(BlockType.Markup)) {
                // An HTML block starts with a start tag and ends with the matching end tag. For example, each of the following lines are HTML blocks:
                //  <li>foo</li>
                //  <li>foo<b>bar</b></li>
                //  <text>This block uses the <pre>&lt;text&gt;</pre> pseudo-tag which is not emitted, but is used for balancing tags</text>
                // Or, if it starts with a ":", then it is part of the "@:" single-line markup construct.  The ":" is discarded and the rest of the line is markup
                // For example, each of the following lines are HTML blocks:
                //  :this is all markup, except for the initial ':'
                //  :you <b>can</b> put tags in here <em>and</em> they don't have to be <img src="foo.jpg"> balanced!

                SpanFactory spanFactory = MarkupSpan.Create;

                Context.AcceptWhiteSpace(includeNewLines: true);
                if (CurrentCharacter == RazorParser.TransitionCharacter) {
                    if (HaveContent) {
                        End(MarkupSpan.Create);
                    }
                    Context.AcceptCurrent();
                    Debug.Assert(HaveContent);
                    End(TransitionSpan.Create(Context, hidden: false, acceptedCharacters: AcceptedCharacters.None));
                    if (CurrentCharacter == RazorParser.TransitionCharacter) {
                        // Second "@" is for VB
                        // TODO: Refactor!!!
                        Context.AcceptCurrent();
                        End(MetaCodeSpan.Create);
                    }
                }

                bool complete = false;
                if (CurrentCharacter == ':') {
                    // Parse a single line of markup
                    spanFactory = SingleLineMarkupSpan.Create;
                    Context.WhiteSpaceIsImportantToAncestorBlock = true;
                    complete = !ParseSingleLineBlock();
                    Context.WhiteSpaceIsImportantToAncestorBlock = false;
                }
                else if (CurrentCharacter == '<') {
                    complete = !ParseTagBlock(false);
                }
                else {
                    // First non-whitespace character in a block must be a start tag or ':'
                    OnError(CurrentLocation, RazorResources.ParseError_MarkupBlock_Must_Start_With_Tag);
                    return;
                }

                // Output anything that's left over
                // If we have content ==> Output
                // If the previous span can't grow ==> Output UNLESS we're "complete"
                if ((!complete && !Context.PreviousSpanCanGrow) || HaveContent) {
                    Span span = spanFactory(Context);
                    span.AcceptedCharacters = complete ? AcceptedCharacters.None : AcceptedCharacters.Any;
                    End(span);
                }
            }
        }

        public override bool IsStartTag() {
            return CurrentCharacter == '<';
        }

        public override bool IsEndTag() {
            return Context.Peek("</", caseSensitive: true);
        }

        private bool ParseSingleLineBlock() {
            Context.UpdateSeenValidEmailPrefix();

            // Output the ":" as a transition token
            Context.AcceptCurrent();
            End(MetaCodeSpan.Create);

            while (!EndOfFile) {
                if (!TryStartCodeParser(isSingleLineMarkup: true)) {
                    if (ParserHelpers.IsNewLine(CurrentCharacter)) {
                        Context.AcceptNewLine();
                        return false;
                    }
                    else {
                        Context.UpdateSeenValidEmailPrefix();
                        Context.AcceptCurrent();
                    }
                }
            }
            return true;
        }

        private bool ParseTagBlock(bool inDocument) {
            // For tracking end tags
            Stack<TagInfo> tags = new Stack<TagInfo>();
            bool startedByPseudoTag = false;

            bool? canGrow = null;
            do {
                // Append until the next tag, processing code as we find it
                AppendUntilAndParseCode(c => c == '<');

                // Read the tag name in lookahead since we might not actually want to accept it
                TagInfo tag = ParseStartOfTag();

                // Special case for "<text>" tag as the first tag we've seen
                if (IsPsuedoTagValidHere(inDocument, tags, startedByPseudoTag, tag)) {
                    if (!tag.IsEndTag) {
                        startedByPseudoTag = true; // Set a flag to indicate that a </text> is a valid end tag
                        if (ParseStartPsuedoTag(tags, tag)) {
                            // Can't just do "canGrow = !ParseStartPsuedoTag(...)" because we can't canGrow to 
                            // stay null if we get false from ParseStartPsuedoTag
                            canGrow = false;
                        }
                    }
                    else {
                        ParseEndPsuedoTag(tags, tag, inDocument);
                        canGrow = false;
                    }
                }
                // It wasn't a "<text>" OR it was but it was within a block, so we don't do anything special
                else {
                    // We're at the '<'
                    Context.AcceptCurrent(); // "<"

                    if (tag.IsEndTag) {
                        Context.AcceptCurrent(); // "/"
                    }
                    Context.AcceptCharacters(tag.Name.Length); // tag name

                    // Invalid tag name? Not a real tag
                    if (!String.IsNullOrEmpty(tag.Name)) {
                        // What kind of tag is it
                        bool? unterminated = null;
                        switch (tag.Name[0]) {
                            case '!':
                                unterminated = ParseBangTag(tag.Name);
                                break;
                            case '?':
                                unterminated = ParseProcessingInstruction();
                                break;
                            default:
                                if (tag.IsEndTag) {
                                    unterminated = ParseEndTag(tags, tag, inDocument);
                                }
                                else {
                                    unterminated = ParseStartTag(tags, tag);
                                }
                                break;
                        }
                        if (tags.Count == 0 && unterminated != null) {
                            canGrow = unterminated.Value;
                        }
                    }
                    else {
                        canGrow = true;
                        if (tags.Count == 0) {
                            OnError(CurrentLocation, RazorResources.ParseError_OuterTagMissingName);
                        }
                    }
                }
            } while (!EndOfFile && tags.Count > 0);

            if (canGrow == null) {
                canGrow = tags.Count > 0;
            }

            if (tags.Count > 0) {
                // Ended because of EOF, not matching close tag.  Throw error for last tag
                while (tags.Count > 1) {
                    tags.Pop();
                }
                TagInfo tag = tags.Pop();
                OnError(tag.Start, RazorResources.ParseError_MissingEndTag, tag.Name);
            }

            // Add the remaining whitespace (up to and including the next newline) to the token if run-time mode
            if (!DesignTimeMode) {
                // Dev10 Bug 884969 - Emit space between markup and code
                Context.AcceptWhiteSpace(includeNewLines: false);
                if (Char.IsWhiteSpace(CurrentCharacter)) {
                    Context.AcceptLine(includeNewLineSequence: true);
                }
            }
            else if (canGrow.Value) {
                Context.AcceptWhiteSpace(includeNewLines: false);
                if (ParserHelpers.IsNewLine(CurrentCharacter)) {
                    Context.AcceptNewLine();
                }
            }

            return canGrow.Value;
        }

        private void ParseEndPsuedoTag(Stack<TagInfo> tags, TagInfo tag, bool inDocument) {
            Debug.Assert(tag.IsEndTag, "ParseEndPsuedoTag requires an end tag");

            // Collect what we've seen so far, since the "</text>" is not a markup span, it's a transition span
            Span prev = null;
            if (HaveContent) {
                prev = MarkupSpan.Create(Context);
                Context.ResetBuffers();
            }

            // Accept the "</text>"
            Context.Expect("<");
            Context.AcceptWhiteSpace(includeNewLines: true);
            Context.Expect("/text");

            bool complete = CurrentCharacter == '>';
            if (!complete) {
                OnError(tag.Start, RazorResources.ParseError_TextTagCannotContainAttributes);
            }
            else {
                Context.AcceptCurrent();
            }

            // Remove the tag
            UpdateTagStack(tags, tag, !inDocument);

            if (tags.Count == 0) {
                // That was the top-level tag, output the markup then a transition span for the </text>
                if (prev != null) {
                    Output(prev);
                }
                End(TransitionSpan.Create(Context, hidden: false, acceptedCharacters: complete ? AcceptedCharacters.None : AcceptedCharacters.Any));
            }
            else {
                // Wasn't top-level, so resume the original span
                Context.ResumeSpan(prev);
            }
        }

        private bool ParseStartPsuedoTag(Stack<TagInfo> tags, TagInfo tag) {
            Debug.Assert(!tag.IsEndTag, "ParseStartPsuedoTag requires a start tag");

            // Output what we've seen so far, since the "<text>" is not a markup token, it's a transition token
            if (HaveContent) {
                End(MarkupSpan.Create);
            }

            // Accept the "<text>"
            Context.Expect("<");
            Context.AcceptWhiteSpace(includeNewLines: true);
            Context.Expect("text");

            bool isValid = false;
            using (Context.StartTemporaryBuffer()) {
                Context.AcceptWhiteSpace(includeNewLines: true);
                if (CurrentCharacter == '/' || CurrentCharacter == '>') {
                    isValid = true;
                    Context.AcceptTemporaryBuffer();
                }
            }

            bool transitionComplete = false;
            bool isEmpty = false;
            if (!isValid) {
                OnError(tag.Start, RazorResources.ParseError_TextTagCannotContainAttributes);
            }
            else {
                isEmpty = CurrentCharacter == '/';
                Context.AcceptCurrent();
                if (isEmpty) {
                    if (CurrentCharacter != '>') {
                        OnError(CurrentLocation, RazorResources.ParseError_SlashInEmptyTagMustBeFollowedByCloseAngle);
                    }
                    else {
                        transitionComplete = true;
                        Context.AcceptCurrent();
                    }
                }
                else {
                    transitionComplete = true;
                }
            }

            // Output the transition
            End(TransitionSpan.Create(Context, hidden: false, acceptedCharacters: transitionComplete ? AcceptedCharacters.None : AcceptedCharacters.Any));

            // Push it on to the stack and continue
            if (!isEmpty) {
                tags.Push(tag);
            }
            return isEmpty;
        }

        private TagInfo ParseStartOfTag() {
            bool isEndTag = false;
            SourceLocation tagStart = CurrentLocation;

            using (Context.StartTemporaryBuffer()) {
                Context.AcceptCurrent(); // Accept the "<"

                // Is this an end tag?
                if (CurrentCharacter == '/') {
                    Context.AcceptCurrent(); // Skip the "/"
                    isEndTag = true;
                }

                // Parse the tag name
                return new TagInfo(AcceptTagName(), tagStart, isEndTag);
            }
        }

        private bool ParseEndTag(Stack<TagInfo> tags, TagInfo tag, bool acceptUnmatchedEndTag) {
            Debug.Assert(tag.IsEndTag, "ParseEndTag requires an end tag");

            // Read the tag (no attributes allowed in an end tag)
            AppendUntilAndParseCode(c => c == '>' || c == '<');

            // Make sure we're actually in a valid tag
            if (CurrentCharacter == '>') {

                //OnTagFinished(new TagFinishedEventArgs(context, tagName, true, false, tagStartLocation));
                Context.AcceptCurrent(); // '>'

                // Verify the tag
                if (tags.Count == 0 && !acceptUnmatchedEndTag) {
                    // Started with an end tag
                    OnError(tag.Start, RazorResources.ParseError_UnexpectedEndTag, tag.Name);
                }
                else {
                    UpdateTagStack(tags, tag, !acceptUnmatchedEndTag);
                }

                // Successfully terminated
                return false;
            }

            // Not terminated, return true to indicate unterminated
            return true;
        }

        private void UpdateTagStack(Stack<TagInfo> tags, TagInfo tag, bool errorIfUnmatched) {
            Debug.Assert(tag.IsEndTag, "Update tag stack requires an end tag");

            // Walk up the stack to find the matching start tag
            TagInfo currentTag = null;
            while (tags.Count > 0) {
                currentTag = tags.Pop();
                if (String.Equals(currentTag.Name, tag.Name, StringComparison.OrdinalIgnoreCase)) {
                    // Found a match! Just return
                    return;
                }
            }

            // No match! Add an error if requested
            if (errorIfUnmatched) {
                OnError((currentTag == null) ? tag.Start : currentTag.Start,
                        RazorResources.ParseError_MissingEndTag,
                        (currentTag == null) ? "[[unknown]]" : currentTag.Name);
            }
        }

        private bool ParseStartTag(Stack<TagInfo> tags, TagInfo tag) {
            Debug.Assert(!tag.IsEndTag, "ParseStartTag requires a start tag");

            // Append Until the end of the tag
            AppendToEndOfTag(tag);

            // Make sure we're actually in a valid tag
            bool unterminated = false;
            switch (CurrentCharacter) {
                case '>':
                    //OnTagFinished(new TagFinishedEventArgs(context, tagName, false, false, tagStartLocation));
                    Context.AcceptCurrent();

                    // Start tag, push it on the stack
                    tags.Push(tag);
                    break;
                case '/':
                    Context.AcceptCurrent(); // Accept the "/"

                    //OnTagFinished(new TagFinishedEventArgs(context, tagName, false, true, tagStartLocation));

                    // We know that it's followed immediately by '>' because that's what AppendToEndOfTag expects, so accept that
                    Context.AcceptCurrent();

                    // An empty tag has no content, so don't push anything onto the stack (no need to set the "End" property on the tag either, since it's going away)
                    break;
                default:
                    unterminated = true;
                    break;
            }
            return unterminated;
        }

        private bool ParseProcessingInstruction() {
            // Parse until '?>'
            while (!EndOfFile) {
                AppendUntilAndParseCode(c => c == '?');
                if (CurrentCharacter == '?') {
                    Context.AcceptCurrent();
                    if (CurrentCharacter == '>') {
                        // End of the PI
                        Context.AcceptCurrent();

                        // Done parsing the PI
                        return false;
                    }
                }
            }
            return true;
        }

        private bool ParseBangTag(string tagName) {
            if (String.Equals(tagName, "!--", StringComparison.Ordinal)) {
                return ParseHtmlComment();
            }
            else if (tagName.StartsWith("![CDATA[", StringComparison.OrdinalIgnoreCase)) {
                return ParseCData();
            }
            else {
                return ParseSgmlDeclaration();
            }
        }

        private bool ParseSgmlDeclaration() {
            // Just parse until the '>'
            AppendUntilAndParseCode(c => c == '>' || c == '<');

            // Make sure we're actually in a valid tag
            if (EndOfFile) {
                return true;
            }

            if (CurrentCharacter == '>') {
                Context.AcceptCurrent();
            }
            return false;
        }

        private bool ParseCData() {
            // Parse until the ']]>'
            while (!EndOfFile) {
                AppendUntilAndParseCode(c => c == ']');
                if (CurrentCharacter == ']') {
                    Context.AcceptCurrent();
                    if (Context.Peek("]>", caseSensitive: true)) {
                        // End of the CData section
                        Context.AcceptUntilInclusive('>');

                        // Done parsing the CData
                        return false;
                    }
                }
            }
            return true;
        }

        private bool ParseHtmlComment() {
            // Parse until the '-->'
            while (!EndOfFile) {
                AppendUntilAndParseCode(c => c == '-');
                if (CurrentCharacter == '-') {
                    Context.AcceptCurrent();

                    // Peek only needs to check for "->" because we've already seen the first '-'
                    if (Context.Peek("->", caseSensitive: true)) {
                        // End of the Comment
                        Context.AcceptUntilInclusive('>');
                        return false;
                    }
                }
            }
            return true;
        }

        private void AppendToEndOfTag(TagInfo tag) {
            char? balancingQuote = null;
            do {
                // Read until a quoted literal or the end of the tag (and handle code we find in between)
                AppendUntilAndParseCode(c => c == '\"' || c == '\'' || c == '/' || c == '>' || c == '<');

                if (balancingQuote != null) {
                    if (balancingQuote.Value == CurrentCharacter) {
                        balancingQuote = null;
                    }
                    Context.AcceptCurrent();
                }
                else if (CurrentCharacter == '\"' || CurrentCharacter == '\'') {
                    balancingQuote = CurrentCharacter;
                    Context.AcceptCurrent();
                }
                else if (CurrentCharacter == '/') {
                    using (Context.Source.BeginLookahead()) {
                        Context.SkipCurrent();
                        if (CurrentCharacter == '>') {
                            return;
                        }
                    }
                    Context.AcceptCurrent(); // "/"
                }
            } while (!EndOfFile && (balancingQuote != null || (CurrentCharacter != '>' && CurrentCharacter != '<')));

            if (CurrentCharacter != '>' && CurrentCharacter != '<') {
                OnError(tag.Start, RazorResources.ParseError_UnfinishedTag, tag.Name);
            }
        }

        private void AppendUntilAndParseCode(Func<char, bool> terminator) {
            while (!EndOfFile && !terminator(CurrentCharacter)) {
                if (!TryStartCodeParser()) {
                    Context.UpdateSeenValidEmailPrefix();
                    Context.AcceptCurrent();
                }
            }

            // The terminator may or may not be a valid prefix/suffix character, and since the else block above was skipped if we reached the terminator
            // we should check it
            Context.UpdateSeenValidEmailPrefix();
        }

        private bool TryStartCodeParser(bool isSingleLineMarkup = false, bool documentLevel = false) {
            if (CurrentCharacter == RazorParser.TransitionCharacter) {
                if (CheckForCodeBlockAndSkipIfNotCode()) {
                    // Get the correct span factory
                    SpanFactory spanFactory = null;
                    if (isSingleLineMarkup) {
                        spanFactory = SingleLineMarkupSpan.Create;
                    }
                    else {
                        spanFactory = context => {
                            var span = MarkupSpan.Create(context);
                            span.DocumentLevel = documentLevel;
                            return span;
                        };
                    }
                    ParseBlockWithOtherParser(spanFactory, collectTransitionToken: true);
                    return true;
                }
            }
            return false;
        }

        private string AcceptTagName() {
            // Comments start as soon as the "!--" is read, so parsing until the first whitespace character (or the end of the tag) won't identify them properly.
            if (Context.Peek("!--", caseSensitive: true)) {
                Context.Expect("!--");
                return "!--";
            }

            // Didn't return from above, so it's not a comment
            return Context.AcceptUntil(c => Char.IsWhiteSpace(c) || c == '/' || c == '>' || c == RazorParser.TransitionCharacter);
        }

        private bool CheckForCodeBlockAndSkipIfNotCode() {
            if (Context.SeenValidEmailPrefix) {
                char next = '\0';
                using (Context.Source.BeginLookahead()) {
                    Context.SkipCurrent();
                    if (EndOfFile) {
                        return true;
                    }
                    next = CurrentCharacter;
                }
                if (ParserContext.IsEmailPrefixOrSuffixCharacter(next)) {
                    // Assume it's an email address
                    Context.AcceptCharacters(2);
                    return false;
                }
            }
            return true;
        }

        private static bool IsPsuedoTagValidHere(bool inDocument, Stack<TagInfo> tags, bool startedByPseudoTag, TagInfo tag) {
            return !inDocument && (
                (
                    (tags.Count == 0 && !tag.IsEndTag) ||
                    (tags.Count > 0 && startedByPseudoTag && tag.IsEndTag)
                ) &&
                String.Equals(tag.Name, PseudoTagName, StringComparison.OrdinalIgnoreCase)
            );
        }
    }
}
