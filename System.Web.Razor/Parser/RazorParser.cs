using System.IO;
using System.Web.Razor.Parser.SyntaxTree;
using System.Web.Razor.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Web.Razor.Parser {
    public class RazorParser {
        public static readonly char TransitionCharacter = '@';
        public static readonly string TransitionString = "@";
        public static readonly string StartCommentSequence = "@*";
        public static readonly string EndCommentSequence = "*@";

        internal ParserBase CodeParser { get; private set; }
        internal MarkupParser MarkupParser { get; private set; }

        public bool DesignTimeMode { get; set; }

        public RazorParser(ParserBase codeParser, MarkupParser markupParser) {
            if (codeParser == null) { throw new ArgumentNullException("codeParser"); }
            if (markupParser == null) { throw new ArgumentNullException("markupParser"); }

            MarkupParser = markupParser;
            CodeParser = codeParser;
        }

        public virtual void Parse(TextReader input, ParserVisitor visitor) {
            Parse(new BufferingTextReader(input), visitor);
        }

        public virtual ParserResults Parse(TextReader input) {
            return SyncParseCore(new BufferingTextReader(input));
        }

        public virtual void Parse(LookaheadTextReader input, ParserVisitor visitor) {
            // Setup the parser context
            ParserContext context = new ParserContext(input, CodeParser, MarkupParser, MarkupParser, visitor) {
                DesignTimeMode = DesignTimeMode
            };

            MarkupParser.Context = context;
            CodeParser.Context = context;

            // Execute the context
            try {
                MarkupParser.ParseDocument();
            }
            finally {
                context.OnComplete();
            }
        }

        public virtual ParserResults Parse(LookaheadTextReader input) {
            return SyncParseCore(input);
        }

        public virtual Task CreateParseTask(TextReader input, Action<Span> spanCallback, Action<RazorError> errorCallback) {
            return CreateParseTask(input, new CallbackVisitor(spanCallback, errorCallback));
        }

        public virtual Task CreateParseTask(TextReader input, Action<Span> spanCallback, Action<RazorError> errorCallback, SynchronizationContext context) {
            return CreateParseTask(input, new CallbackVisitor(spanCallback, errorCallback) { SynchronizationContext = context });
        }

        public virtual Task CreateParseTask(TextReader input, Action<Span> spanCallback, Action<RazorError> errorCallback, CancellationToken cancelToken) {
            return CreateParseTask(input, new CallbackVisitor(spanCallback, errorCallback) { CancelToken = cancelToken });
        }

        public virtual Task CreateParseTask(TextReader input, Action<Span> spanCallback, Action<RazorError> errorCallback, SynchronizationContext context, CancellationToken cancelToken) {
            return CreateParseTask(input, new CallbackVisitor(spanCallback, errorCallback) {
                SynchronizationContext = context,
                CancelToken = cancelToken
            });
        }

        public virtual Task CreateParseTask(TextReader input,
                                            ParserVisitor consumer) {
            return new Task(() => {
                try {
                    Parse(input, consumer);
                }
                catch (OperationCanceledException) {
                    return; // Just return if we're cancelled.
                }
            });
        }


        private ParserResults SyncParseCore(LookaheadTextReader input) {
            SyntaxTreeBuilderVisitor listener = new SyntaxTreeBuilderVisitor();
            Parse(input, listener);
            return listener.Results;
        }
    }
}

