using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Web.Razor.Parser.SyntaxTree;
using System.Web.Razor.Resources;
using System.Web.Razor.Text;
using System.Web.Razor.Utils;
using System.Text;

namespace System.Web.Razor.Parser {
#if DEBUG
    [DebuggerDisplay("{Unparsed}")]
#endif
    public class ParserContext {
        private int? _ownerTaskId;

        private Stack<TemporaryContext> _temporaryContextStack = new Stack<TemporaryContext>();
        private StringBuilder _primaryBuffer = new StringBuilder();
        private int _nestedAnonymousSections = 0;
        private int _nestedNamedSections = 0;
        private int _nestedHelpers = 0;

#if DEBUG
        private const int InfiniteLoopCountThreshold = 1000;
        private int _infiniteLoopGuardCount = 0;
        private SourceLocation? _infiniteLoopGuardLocation = null;
#endif

        private bool _terminated = false;
        private Span _nextSpanToOutput = null;
        
        private Stack<BlockType> _blockStack = new Stack<BlockType>();
        private Stack<ParserVisitor> _visitorStack = new Stack<ParserVisitor>();

        private class TemporaryContext {
            public StringBuilder Buffer { get; set; }
            public IDisposable LookaheadContext { get; set; }
        }

        public LookaheadTextReader Source { get; set; }
        public SourceLocation CurrentSpanStart { get; private set; }
        public Span PreviousSpan { get; private set; }

        public bool PreviousSpanCanGrow {
            get {
                return PreviousSpan != null && PreviousSpan.AcceptedCharacters == AcceptedCharacters.Any;
            }
        }

        public SourceLocation CurrentLocation {
            get { return Source.CurrentLocation; }
        }

        // Used by Markup Parsers to determine if the previous character was a valid email prefix character
        public bool SeenValidEmailPrefix { get; set; }

        public ParserBase CodeParser { get; private set; }
        public MarkupParser MarkupParser { get; private set; }
        public ParserBase ActiveParser { get; private set; }
        public bool DesignTimeMode { get; set; }
        
        public bool WhiteSpaceIsImportantToAncestorBlock { get; set; }
        
        public bool InTemporaryBuffer {
            get {
                return _temporaryContextStack.Count > 0;
            }
        }

        public StringBuilder ContentBuffer {
            get {
                return _temporaryContextStack.Count > 0 ? _temporaryContextStack.Peek().Buffer : _primaryBuffer;
            }
        }

#if DEBUG
        internal string Unparsed {
            get {
                using (StartTemporaryBuffer()) {
                    return Source.ReadToEnd();
                }
            }
        }
#endif

        public char CurrentCharacter {
            get {
                if (_terminated) {
                    return '\0';
                }

#if DEBUG
                // Infinite loop guard
                //  Basically, if this property is accessed 1000 times in a row without having advanced the source reader to the next position, we
                //  cause a parser error
                if (_infiniteLoopGuardLocation != null) {
                    if (CurrentLocation == _infiniteLoopGuardLocation.Value) {
                        _infiniteLoopGuardCount++;
                        if (_infiniteLoopGuardCount > InfiniteLoopCountThreshold) {
                            Debug.Fail(RazorResources.ParseError_Internal_Error_Is_Causing_Infinite_Loop);
                            _terminated = true;
                            return '\0';
                        }
                    }
                    else {
                        _infiniteLoopGuardCount = 0;
                    }
                }
                _infiniteLoopGuardLocation = CurrentLocation;
#endif

                int ch = Source.Peek();
                if (ch == -1) {
                    return '\0';
                }
                return (char)ch;
            }
        }

        public bool EndOfFile {
            get { return _terminated || Source.Peek() == -1; }
        }

        public bool HaveContent {
            get { return ContentBuffer.Length > 0; }
        }

        internal ParserVisitor Visitor {
            get {
                if (_visitorStack.Count == 0) {
                    throw new InvalidOperationException(RazorResources.ParserContext_VisitorStackEmpty);
                }
                return _visitorStack.Peek();
            }
        }

        public ParserContext(LookaheadTextReader source, ParserBase codeParser, MarkupParser markupParser, ParserBase activeParser, ParserVisitor visitor) {
            if (source == null) { throw new ArgumentNullException("source"); }
            if (codeParser == null) { throw new ArgumentNullException("codeParser"); }
            if (markupParser == null) { throw new ArgumentNullException("markupParser"); }
            if (activeParser == null) { throw new ArgumentNullException("activeParser"); }
            if (visitor == null) { throw new ArgumentNullException("visitor"); }
            if (activeParser != codeParser && activeParser != markupParser) {
                throw new ArgumentException(RazorResources.ActiveParser_Must_Be_Code_Or_Markup_Parser, "activeParser");
            }

            CaptureOwnerTask();

            Source = source;
            CodeParser = codeParser;
            MarkupParser = markupParser;
            ActiveParser = activeParser;
            _visitorStack.Push(visitor);
            ResetBuffers();
        }

        public IDisposable StartTemporaryBuffer() {
            AssertOnOwnerTask();
            
            // Create a temporary buffer
            TemporaryContext context = new TemporaryContext() {
                Buffer = new StringBuilder(),
                LookaheadContext = Source.BeginLookahead()
            };
            _temporaryContextStack.Push(context);

            return new DisposableAction(() => {
                RejectTemporaryBuffer(context);
            });
        }

        public void AcceptTemporaryBuffer() {
            AssertOnOwnerTask();
            if (InTemporaryBuffer) {
                // Get the buffer
                TemporaryContext context = _temporaryContextStack.Pop();

                // Cancel backtrack
                Source.CancelBacktrack();

                // Append the temporary content to the new current buffer
                ContentBuffer.Append(context.Buffer.ToString());

                // Now just clean up the lookahead context
                context.LookaheadContext.Dispose();
            }
        }

        public char AcceptCurrent() {
            AssertOnOwnerTask();
            char ch = '\0';
            if (!EndOfFile) {
                ch = CurrentCharacter;
                ContentBuffer.Append(CurrentCharacter);
                SkipCurrent();
            }
            return ch;
        }

        public string Append(string value) {
            AssertOnOwnerTask();
            ContentBuffer.Append(value);
            return value;
        }

        /// <summary>
        /// Outputs the specified span (does NOT affect the buffers at all)
        /// </summary>
        /// <remarks>
        /// Null is allowed and will have no effect (nothing will be outputted)
        /// </remarks>
        /// <param name="span">The span to output</param>
        public void OutputSpan(Span span) {
            AssertOnOwnerTask();
            if (span != null) {
                if (_blockStack.Count == 0) {
                    throw new InvalidOperationException(RazorResources.No_Current_Parser_Block);
                }
                FlushNextOutputSpan();
                _nextSpanToOutput = span;
                PreviousSpan = span;
            }
        }

        /// <summary>
        /// Put the contents of the specified span back into the buffer at the front (preserving the existing buffer contents)
        /// </summary>
        /// <remarks>
        /// Null is allowed and will have no effect (buffers will be unaffected)
        /// </remarks>
        /// <param name="span">The span to resume</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Resuming only makes sense for Spans, not other SyntaxTreeNodes")]
        public void ResumeSpan(Span span) {
            AssertOnOwnerTask();
            if (span != null) {
                // Capture what was already in the buffer
                string buffer = _primaryBuffer.ToString();

                // Reset the start marker
                CurrentSpanStart = span.Start;

                // Clear the buffer and put the span content back
                _primaryBuffer.Clear();
                _primaryBuffer.Append(span.Content);

                // Reappend what we captured above
                _primaryBuffer.Append(buffer);
            }
        }

        /// <summary>
        /// Starts a block of the specified type
        /// </summary>
        /// <remarks>
        /// The current contents of the buffer will be outputted as a transition token AFTER starting the block if outputCurrentBufferAsTransition is true
        /// </remarks>
        /// <param name="blockType">The type of the block to start</param>
        public IDisposable StartBlock(BlockType blockType, bool outputCurrentBufferAsTransition) {
            AssertOnOwnerTask();
            if (blockType == BlockType.Template) {
                HandleNestingCheck(RazorResources.ParseError_InlineMarkup_Blocks_Cannot_Be_Nested,
                                   ref _nestedAnonymousSections);
            }
            else if (blockType == BlockType.Section) {
                HandleNestingCheck(FormatForLanguage(RazorResources.ParseError_Sections_Cannot_Be_Nested,
                                                     RazorResources.SectionExample_VB,
                                                     RazorResources.SectionExample_CS),
                                   ref _nestedNamedSections);
                if (_nestedHelpers > 0) {
                    OnError(CurrentLocation, RazorResources.ParseError_Helpers_Cannot_Contain_Sections);
                }
            }
            else if (blockType == BlockType.Helper) {
                HandleNestingCheck(RazorResources.ParseError_Helpers_Cannot_Be_Nested, ref _nestedHelpers);
            }

            // TODO: Remove this super-hacky whitespace rewriting
            if (!DesignTimeMode &&
                !WhiteSpaceIsImportantToAncestorBlock &&
                blockType == BlockType.Statement &&
                (_blockStack.Count == 0 || _blockStack.Peek() != BlockType.Statement) &&
                _nextSpanToOutput != null) {
                HandleWhitespaceRewriting();
            }
            else {
                FlushNextOutputSpan();
            }

            _blockStack.Push(blockType);
            Visitor.VisitStartBlock(blockType);
            if (outputCurrentBufferAsTransition && HaveContent) {
                OutputSpan(TransitionSpan.Create(this, hidden: false, acceptedCharacters: AcceptedCharacters.None));
                ResetBuffers();
            }
            return new DisposableAction(EndBlock);
        }

        /// <summary>
        /// Pushes a visitor onto the visitor stack
        /// </summary>
        /// <remarks>
        /// When StartBlock/EndBlock/EndSpan/OnError are called, the visitor on the top of the visitor stack
        /// will receive those calls.
        /// </remarks>
        public void PushVisitor(ParserVisitor visitor) {
            AssertOnOwnerTask();
            _visitorStack.Push(visitor);
        }

        /// <summary>
        /// Pops a visitor from the visitor stack
        /// </summary>
        /// <remarks>
        /// When StartBlock/EndBlock/EndSpan/OnError are called, the visitor on the top of the visitor stack
        /// will receive those calls.
        /// </remarks>
        /// <exception cref="InvalidOperationException">The visitor stack is empty</exception>
        public void PopVisitor() {
            AssertOnOwnerTask();
            if (_visitorStack.Count == 0) {
                throw new InvalidOperationException(RazorResources.ParserContext_VisitorStackEmpty);
            }
            _visitorStack.Pop();
        }

        /// <summary>
        /// Replays the specified parse tree nodes and errors on the current visitor
        /// </summary>
        /// <param name="elements">The elements to replay</param>
        /// <param name="errors">The errors to replay</param>
        public void Replay(IEnumerable<SyntaxTreeNode> elements, IEnumerable<RazorError> errors) {
            AssertOnOwnerTask();
            foreach (SyntaxTreeNode element in elements) {
                element.Accept(Visitor);
            }
            foreach (RazorError error in errors) {
                Visitor.VisitError(error);
            }
        }

        private string FormatForLanguage(string formatString, string vbExample, string csExample) {
            // TODO: Refactor for other languages?
            return String.Format(CultureInfo.CurrentCulture, formatString,
                                 (CodeParser is VBCodeParser) ?
                                 vbExample :
                                 csExample);
        }

        private void HandleWhitespaceRewriting() {
            Debug.Assert(!String.IsNullOrEmpty(_nextSpanToOutput.Content));

            // Check the last span for trailing whitespace
            int endOfWhitespaceToCapture = _nextSpanToOutput.Content.Length;
            for (int i = _nextSpanToOutput.Content.Length - 1; i >= 0; i--) {
                char c = _nextSpanToOutput.Content[i];
                if (CharUtils.IsNewLine(c)) {
                    break;
                }
                else if (!Char.IsWhiteSpace(c)) {
                    return; // Saw non-whitespace before newline, markup owns this whitespace so don't touch it
                }
                else {
                    endOfWhitespaceToCapture = i;
                }
            }

            // Ok, endOfWhitespaceToCapture is now at the offset of the first whitespace character after the newline
            string oldContent = _nextSpanToOutput.Content;
            _nextSpanToOutput.Content = oldContent.Substring(0, endOfWhitespaceToCapture);

            SourceLocationTracker tracker = new SourceLocationTracker();
            tracker.CurrentLocation = _nextSpanToOutput.Start;
            tracker.UpdateLocation(_nextSpanToOutput.Content);
            Span whitespaceSpan = new CodeSpan(tracker.CurrentLocation, oldContent.Substring(endOfWhitespaceToCapture));

            Visitor.VisitSpan(_nextSpanToOutput);
            _nextSpanToOutput = whitespaceSpan;
        }

        /// <summary>
        /// Ends the current block
        /// </summary>
        public void EndBlock() {
            AssertOnOwnerTask();
            FlushNextOutputSpan();

            if (_blockStack.Count == 0) {
                throw new InvalidOperationException(RazorResources.EndBlock_Called_Without_Matching_StartBlock);
            }
            BlockType type = _blockStack.Pop();
            if (type == BlockType.Template) {
                _nestedAnonymousSections--;
            }
            else if (type == BlockType.Section) {
                _nestedNamedSections--;
            }
            else if (type == BlockType.Helper) {
                _nestedHelpers--;
            }
            Visitor.VisitEndBlock(type);
        }

        public static bool IsEmailPrefixOrSuffixCharacter(char character) {
            // Source: http://tools.ietf.org/html/rfc5322#section-3.4.1
            // We restrict the allowed characters to alpha-numerics and '_' in order to ensure we cover most of the cases where an
            // email address is intended without restricting the usage of code within JavaScript, CSS, and other contexts.
            return Char.IsLetterOrDigit(character) || character == '_';
        }

        public void UpdateSeenValidEmailPrefix() {
            AssertOnOwnerTask();
            SeenValidEmailPrefix = IsEmailPrefixOrSuffixCharacter(CurrentCharacter);
        }

        public void RejectTemporaryBuffer() {
            AssertOnOwnerTask();
            RejectTemporaryBuffer(_temporaryContextStack.Peek());
        }

        public bool SkipCurrent() {
            AssertOnOwnerTask();
            Source.Read();
            return Source.Peek() != -1;
        }

        public void ResetBuffers() {
            AssertOnOwnerTask();
            while (InTemporaryBuffer) { RejectTemporaryBuffer(); }

            _primaryBuffer.Clear();
            CurrentSpanStart = Source.CurrentLocation;
        }


        public void SwitchActiveParser() {
            AssertOnOwnerTask();
            if (ReferenceEquals(ActiveParser, CodeParser)) {
                ActiveParser = MarkupParser;
            }
            else {
                ActiveParser = CodeParser;
            }
        }

        public void OnComplete() {
            AssertOnOwnerTask();
            Visitor.OnComplete();
        }

        public void OnError(SourceLocation location, string message) {
            AssertOnOwnerTask();
            Visitor.VisitError(new RazorError(message, location));
        }

        public void OnError(SourceLocation location, string message, params object[] args) {
            AssertOnOwnerTask();
            OnError(location, String.Format(CultureInfo.CurrentCulture, message, args));
        }

        public void FlushNextOutputSpan() {
            AssertOnOwnerTask();
            if (_nextSpanToOutput != null) {
                Visitor.VisitSpan(_nextSpanToOutput);
                _nextSpanToOutput = null;
            }
        }

        private void HandleNestingCheck(string errorMessage, ref int nestingCounter) {
            if (nestingCounter > 0) {
                OnError(Source.CurrentLocation, errorMessage);
            }
            nestingCounter++;
        }

        private void RejectTemporaryBuffer(TemporaryContext context) {
            // Check the provided context to prevent double-rejection by the dispose handler
            if (InTemporaryBuffer && ReferenceEquals(_temporaryContextStack.Peek(), context)) {
                _temporaryContextStack.Pop();
                context.LookaheadContext.Dispose();
            }
        }

        public void AcceptTemporaryBufferInDesignTimeMode() {
            AssertOnOwnerTask();
            if (DesignTimeMode) {
                AcceptTemporaryBuffer();
            }
            else {
                RejectTemporaryBuffer();
            }
        }

        [Conditional("DEBUG")]
        internal void CaptureOwnerTask() {
            if (Threading.Tasks.Task.CurrentId != null) {
                _ownerTaskId = Threading.Tasks.Task.CurrentId;
            }
        }

        [Conditional("DEBUG")]
        internal void AssertOnOwnerTask() {
            if (_ownerTaskId != null) {
                Debug.Assert(_ownerTaskId == Threading.Tasks.Task.CurrentId);
            }
        }

        [Conditional("DEBUG")]
        internal void AssertCurrent(char expected) {
            Debug.Assert(CurrentCharacter == expected);
        }
    }
}
