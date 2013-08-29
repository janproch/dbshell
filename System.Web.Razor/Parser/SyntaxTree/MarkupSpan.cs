using System.Web.Razor.Text;

namespace System.Web.Razor.Parser.SyntaxTree {
    public class MarkupSpan : Span {
        // For parser unit tests, where start point is calculated
        internal MarkupSpan(string content) : base(SpanKind.Markup, content) { }
        internal MarkupSpan(string content, bool hidden) : base(SpanKind.Markup, content, hidden) { }
        internal MarkupSpan(string content, bool hidden, AcceptedCharacters acceptedCharacters) : base(SpanKind.Markup, content, hidden, acceptedCharacters) { }

        public MarkupSpan(SourceLocation start, string content) : base(SpanKind.Markup, start, content) { }
        public MarkupSpan(SourceLocation start, string content, bool hidden) : base(SpanKind.Markup, start, content, hidden) { }
        public MarkupSpan(SourceLocation start, string content, bool hidden, AcceptedCharacters acceptedCharacters) : base(SpanKind.Markup, start, content, hidden, acceptedCharacters) { }

        public bool DocumentLevel {
            get;
            set;
        }

        public static MarkupSpan Create(ParserContext context) {
            return new MarkupSpan(context.CurrentSpanStart, context.ContentBuffer.ToString());
        }

        public static MarkupSpan Create(ParserContext context, bool hidden) {
            return new MarkupSpan(context.CurrentSpanStart, context.ContentBuffer.ToString(), hidden);
        }

        public static MarkupSpan Create(ParserContext context, bool hidden, AcceptedCharacters acceptedCharacters) {
            return new MarkupSpan(context.CurrentSpanStart, context.ContentBuffer.ToString(), hidden, acceptedCharacters);
        }

        public override string ToString() {
            if (DocumentLevel) {
                return base.ToString() + " (Document)";
            }
            return base.ToString();
        }
    }
}
