using System.Globalization;
using System.Web.Razor.Resources;
using System.Web.Razor.Text;

namespace System.Web.Razor.Parser.SyntaxTree {
    public class VBOptionSpan : MetaCodeSpan {
        public string OptionName { get; set; }
        public bool Value { get; set; }

        // For parser unit tests, where start point is calculated
        internal VBOptionSpan(string content, string optionName, bool value)
            : base(content) {
            OptionName = optionName;
            Value = value;
        }

        public VBOptionSpan(SourceLocation start, string content, string optionName, bool value)
            : base(start, content) {
            OptionName = optionName;
            Value = value;
        }

        public static VBOptionSpan Create(ParserContext context, string optionName, bool value) {
            return new VBOptionSpan(context.CurrentSpanStart, context.ContentBuffer.ToString(), optionName, value);
        }

        public override bool Equals(object obj) {
            VBOptionSpan other = obj as VBOptionSpan;
            return other != null &&
                   base.Equals(other) &&
                   String.Equals(other.OptionName, OptionName, StringComparison.Ordinal) &&
                   other.Value == Value;
        }

        public override string ToString() {
            return String.Format(CultureInfo.CurrentCulture, "{0} - {1} {2}", base.ToString(), OptionName, Value ? "On" : "Off");
        }

        // REVIEW: This seems unnecessary since the base class (Span) implementation is perfect for us, but we get a Warning (as Error) if we don't put this here...
        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}
