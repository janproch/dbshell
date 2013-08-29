using System.Globalization;
using System.Web.Razor.Resources;
using System.Web.Razor.Text;

namespace System.Web.Razor.Parser.SyntaxTree {
    public class HelperFooterSpan : CodeSpan {

        // For parser unit tests, where start point is calculated
        internal HelperFooterSpan(string content)
            : base(content) {
        }

        public HelperFooterSpan(SourceLocation start, string content)
            : base(start, content, hidden: false) {
        }

        public static new HelperFooterSpan Create(ParserContext context) {
            return Create(context, AcceptedCharacters.None);
        }

        public static HelperFooterSpan Create(ParserContext context, AcceptedCharacters acceptedCharacters) {
            return new HelperFooterSpan(context.CurrentSpanStart, context.ContentBuffer.ToString()) {
                AcceptedCharacters = acceptedCharacters
            };
        }

        public override bool Equals(object obj) {
            HelperFooterSpan other = obj as HelperFooterSpan;
            return other != null && base.Equals(other);
        }

        // REVIEW: This seems unnecessary since the base class (Span) implementation is perfect for us, but we get a Warning (as Error) if we don't put this here...
        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public override string ToString() {
            return base.ToString();
        }
    }
}
