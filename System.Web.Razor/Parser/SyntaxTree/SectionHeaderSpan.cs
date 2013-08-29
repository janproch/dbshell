using System.Globalization;
using System.Web.Razor.Resources;
using System.Web.Razor.Text;

namespace System.Web.Razor.Parser.SyntaxTree {
    public class SectionHeaderSpan : MetaCodeSpan {
        public string SectionName { get; set; }
        
        // For parser unit tests, where start point is calculated
        internal SectionHeaderSpan(string content, string sectionName, AcceptedCharacters acceptedCharacters)
            : base(content, hidden: false, acceptedCharacters: acceptedCharacters) {
            SectionName = sectionName;
        }

        public SectionHeaderSpan(SourceLocation start, string content, string sectionName, AcceptedCharacters acceptedCharacters)
            : base(start, content, hidden: false, acceptedCharacters: acceptedCharacters) {
            SectionName = sectionName;
        }

        public override bool Equals(object obj) {
            SectionHeaderSpan other = obj as SectionHeaderSpan;
            return other != null &&
                   base.Equals(other) &&
                   String.Equals(other.SectionName, SectionName, StringComparison.Ordinal);
        }

        protected override PartialParseResult CanAcceptChange(TextChange change) {
            if (IsEndInsertion(change) && ParserHelpers.IsNewLine(change.NewText) && AutoCompleteString != null) {
                return PartialParseResult.Rejected | PartialParseResult.AutoCompleteBlock;
            }
            return PartialParseResult.Rejected;
        }

        // REVIEW: This seems unnecessary since the base class (Span) implementation is perfect for us, but we get a Warning (as Error) if we don't put this here...
        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public override string ToString() {
            return String.Format(CultureInfo.CurrentCulture, "{0} - [Section: {1}]", base.ToString(), SectionName);
        }

        public static SectionHeaderSpan Create(ParserContext context, string sectionName, AcceptedCharacters acceptedCharacters) {
            return new SectionHeaderSpan(context.CurrentSpanStart, context.ContentBuffer.ToString(), sectionName, acceptedCharacters);
        }
    }
}
