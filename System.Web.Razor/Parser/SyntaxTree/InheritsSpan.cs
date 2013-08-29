using System.Globalization;
using System.Web.Razor.Resources;
using System.Web.Razor.Text;

namespace System.Web.Razor.Parser.SyntaxTree {
    public class InheritsSpan : CodeSpan {
        public string BaseClass { get; set; }

        // For parser unit tests, where start point is calculated
        internal InheritsSpan(string content) : this(content, content.TrimStart()) {
        }

        internal InheritsSpan(string content, string baseClass)
            : base(content) {
            if (!String.IsNullOrEmpty(baseClass)) {
                BaseClass = baseClass;
            }
        }

        public InheritsSpan(SourceLocation start, string content, string baseClass)
            : base(start, content) {
            BaseClass = baseClass;
        }

        public override bool Equals(object obj) {
            InheritsSpan other = obj as InheritsSpan;
            return other != null && base.Equals(other) && String.Equals(other.BaseClass, BaseClass, StringComparison.Ordinal);
        }

        // REVIEW: This seems unnecessary since the base class (Span) implementation is perfect for us, but we get a Warning (as Error) if we don't put this here...
        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public override string ToString() {
            return String.Format(CultureInfo.CurrentCulture, "{0} - [BaseClass: [{1}]]", base.ToString(), BaseClass);
        }

        public static new InheritsSpan Create(ParserContext context, string baseClass) {
            return new InheritsSpan(context.CurrentSpanStart, context.ContentBuffer.ToString(), baseClass);
        }
    }
}
