using System.Web.Razor.Resources;
using System.Web.Razor.Text;

namespace System.Web.Razor.Parser.SyntaxTree {
    public class MetaCodeSpan : Span {
        // For parser unit tests, where start point is calculated
        internal MetaCodeSpan(string content) : base(SpanKind.MetaCode, content) { }
        internal MetaCodeSpan(string content, bool hidden) : base(SpanKind.MetaCode, content, hidden) { }
        internal MetaCodeSpan(string content, bool hidden, AcceptedCharacters acceptedCharacters) : base(SpanKind.MetaCode, content, hidden, acceptedCharacters) { }

        public MetaCodeSpan(SourceLocation start, string content) : base(SpanKind.MetaCode, start, content) { }
        public MetaCodeSpan(SourceLocation start, string content, bool hidden) : base(SpanKind.MetaCode, start, content, hidden) { }
        public MetaCodeSpan(SourceLocation start, string content, bool hidden, AcceptedCharacters acceptedCharacters) : base(SpanKind.MetaCode, start, content, hidden, acceptedCharacters) { }

        public static MetaCodeSpan Create(ParserContext context) {
            return new MetaCodeSpan(context.CurrentSpanStart, context.ContentBuffer.ToString());
        }

        public static MetaCodeSpan Create(ParserContext context, bool hidden) {
            return new MetaCodeSpan(context.CurrentSpanStart, context.ContentBuffer.ToString(), hidden);
        }

        public static MetaCodeSpan Create(ParserContext context, bool hidden, AcceptedCharacters acceptedCharacters) {
            return new MetaCodeSpan(context.CurrentSpanStart, context.ContentBuffer.ToString(), hidden, acceptedCharacters);
        }
    }
}
