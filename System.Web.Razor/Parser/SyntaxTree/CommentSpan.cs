using System.Web.Razor.Resources;
using System.Web.Razor.Text;

namespace System.Web.Razor.Parser.SyntaxTree {
    public class CommentSpan : Span {
        // For parser unit tests, where start point is calculated
        internal CommentSpan(string content) : base(SpanKind.Comment, content) { }
        internal CommentSpan(string content, bool hidden) : base(SpanKind.Comment, content, hidden) { }
        internal CommentSpan(string content, bool hidden, AcceptedCharacters acceptedCharacters) : base(SpanKind.Comment, content, hidden, acceptedCharacters) { }

        public CommentSpan(SourceLocation start, string content) : base(SpanKind.Comment, start, content) { }
        public CommentSpan(SourceLocation start, string content, bool hidden) : base(SpanKind.Comment, start, content, hidden) { }
        public CommentSpan(SourceLocation start, string content, bool hidden, AcceptedCharacters acceptedCharacters) : base(SpanKind.Comment, start, content, hidden, acceptedCharacters) { }

        public static CommentSpan Create(ParserContext context) {
            return new CommentSpan(context.CurrentSpanStart, context.ContentBuffer.ToString());
        }

        public static CommentSpan Create(ParserContext context, bool hidden) {
            return new CommentSpan(context.CurrentSpanStart, context.ContentBuffer.ToString(), hidden);
        }

        public static CommentSpan Create(ParserContext context, bool hidden, AcceptedCharacters acceptedCharacters) {
            return new CommentSpan(context.CurrentSpanStart, context.ContentBuffer.ToString(), hidden, acceptedCharacters);
        }
    }
}
