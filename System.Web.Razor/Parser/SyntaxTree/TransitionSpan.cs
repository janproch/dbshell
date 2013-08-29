using System.Web.Razor.Resources;
using System.Web.Razor.Text;

namespace System.Web.Razor.Parser.SyntaxTree {
    public class TransitionSpan : Span {
        // For parser unit tests, where start point is calculated
        internal TransitionSpan(string content) : base(SpanKind.Transition, content) { }
        internal TransitionSpan(string content, bool hidden) : base(SpanKind.Transition, content, hidden) { }
        internal TransitionSpan(string content, bool hidden, AcceptedCharacters acceptedCharacters) : base(SpanKind.Transition, content, hidden, acceptedCharacters) { }

        public TransitionSpan(SourceLocation start, string content) : base(SpanKind.Transition, start, content) { }
        public TransitionSpan(SourceLocation start, string content, bool hidden) : base(SpanKind.Transition, start, content, hidden) { }
        public TransitionSpan(SourceLocation start, string content, bool hidden, AcceptedCharacters acceptedCharacters) : base(SpanKind.Transition, start, content, hidden, acceptedCharacters) { }

        public static TransitionSpan Create(ParserContext context) {
            return new TransitionSpan(context.CurrentSpanStart, context.ContentBuffer.ToString());
        }

        public static TransitionSpan Create(ParserContext context, bool hidden) {
            return new TransitionSpan(context.CurrentSpanStart, context.ContentBuffer.ToString(), hidden);
        }

        public static TransitionSpan Create(ParserContext context, bool hidden, AcceptedCharacters acceptedCharacters) {
            return new TransitionSpan(context.CurrentSpanStart, context.ContentBuffer.ToString(), hidden, acceptedCharacters);
        }
    }
}
