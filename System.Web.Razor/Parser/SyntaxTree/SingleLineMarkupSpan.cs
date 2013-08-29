using System.Web.Razor.Resources;
using System.Web.Razor.Text;

namespace System.Web.Razor.Parser.SyntaxTree {
    public class SingleLineMarkupSpan : MarkupSpan {
        // For parser unit tests, where start point is calculated
        internal SingleLineMarkupSpan(string content) : base(content) { }
        internal SingleLineMarkupSpan(string content, bool hidden, AcceptedCharacters acceptedCharacters) : base(content, hidden, acceptedCharacters) { }

        public SingleLineMarkupSpan(SourceLocation start, string content) : base(start, content) { }
        public SingleLineMarkupSpan(SourceLocation start, string content, bool hidden, AcceptedCharacters acceptedCharacters) : base(start, content, hidden, acceptedCharacters) { }

        public static new SingleLineMarkupSpan Create(ParserContext context) {
            return new SingleLineMarkupSpan(context.CurrentSpanStart, context.ContentBuffer.ToString());
        }

        public override bool Equals(object obj) {
            SingleLineMarkupSpan other = obj as SingleLineMarkupSpan;
            return other != null &&
                   base.Equals(other);
        }

        // REVIEW: This seems unnecessary since the base class (Span) implementation is perfect for us, but we get a Warning (as Error) if we don't put this here...
        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}
