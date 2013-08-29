using System.Globalization;
using System.Web.Razor.Resources;
using System.Web.Razor.Text;

namespace System.Web.Razor.Parser.SyntaxTree {
    public class HelperHeaderSpan : CodeSpan {
        public bool Complete { get; private set; }
        
        // For parser unit tests, where start point is calculated
        internal HelperHeaderSpan(string content, bool complete) : base(content) {
            Complete = complete;
        }
        
        public HelperHeaderSpan(SourceLocation start, string content, bool complete) : base(start, content, hidden: false) {
            Complete = complete;
        }

        public static new HelperHeaderSpan Create(ParserContext context, bool complete) {
            return Create(context, complete, AcceptedCharacters.Any);
        }

        public static new HelperHeaderSpan Create(ParserContext context, bool complete, AcceptedCharacters acceptedCharacters) {
            return new HelperHeaderSpan(context.CurrentSpanStart, context.ContentBuffer.ToString(), complete) {
                AcceptedCharacters = acceptedCharacters
            };
        }

        public override bool Equals(object obj) {
            HelperHeaderSpan other = obj as HelperHeaderSpan;
            return other != null && base.Equals(other) && other.Complete == Complete;
        }

        // REVIEW: This seems unnecessary since the base class (Span) implementation is perfect for us, but we get a Warning (as Error) if we don't put this here...
        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public override string ToString() {
            return String.Format(CultureInfo.CurrentCulture, "{0} - {1}", base.ToString(), Complete ? "Complete" : "Incomplete");
        }

        protected override PartialParseResult CanAcceptChange(TextChange change) {
            if (IsEndInsertion(change) && ParserHelpers.IsNewLine(change.NewText) && AutoCompleteString != null) {
                return PartialParseResult.Rejected | PartialParseResult.AutoCompleteBlock;
            }
            return PartialParseResult.Rejected;
        }
    }
}
