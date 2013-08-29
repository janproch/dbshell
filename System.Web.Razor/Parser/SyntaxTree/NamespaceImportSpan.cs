using System.Globalization;
using System.Web.Razor.Text;

namespace System.Web.Razor.Parser.SyntaxTree {
    public class NamespaceImportSpan : Span {
        public string Namespace { get; set; }
        public int NamespaceKeywordLength { get; set; }

        // For parser unit tests, where start point is calculated
        internal NamespaceImportSpan(SpanKind kind, string content, AcceptedCharacters acceptedCharacters, string ns, int namespaceKeywordLength)
            : base(kind, content, hidden: false, acceptedCharacters: acceptedCharacters) {
            Namespace = ns;
            NamespaceKeywordLength = namespaceKeywordLength;
        }

        public NamespaceImportSpan(SpanKind kind, SourceLocation start, string content, AcceptedCharacters acceptedCharacters, string ns, int namespaceKeywordLength)
            : base(kind, start, content, hidden: false, acceptedCharacters: acceptedCharacters) {
            Namespace = ns;
            NamespaceKeywordLength = namespaceKeywordLength;
        }

        public override bool Equals(object obj) {
            NamespaceImportSpan other = obj as NamespaceImportSpan;
            return other != null &&
                   base.Equals(other) &&
                   String.Equals(other.Namespace, Namespace, StringComparison.Ordinal) &&
                   other.NamespaceKeywordLength == NamespaceKeywordLength;
        }

        // REVIEW: This seems unnecessary since the base class (Span) implementation is perfect for us, but we get a Warning (as Error) if we don't put this here...
        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public override string ToString() {
            return String.Format(CultureInfo.CurrentCulture, "{0} - [NS: {1}]", base.ToString(), Namespace);
        }

        public static NamespaceImportSpan Create(ParserContext context, AcceptedCharacters acceptedCharacters, SpanKind kind, string ns, int namespaceKeywordLength) {
            return new NamespaceImportSpan(kind, context.CurrentSpanStart, context.ContentBuffer.ToString(), acceptedCharacters, ns, namespaceKeywordLength);
        }
    }
}
