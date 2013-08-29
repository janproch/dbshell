using System.Web.Razor.Resources;
using System.Web.Razor.Text;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace System.Web.Razor.Parser.SyntaxTree {
    public class CodeSpan : Span {
        // For parser unit tests, where start point is calculated
        internal CodeSpan(string content) : base(SpanKind.Code, content) { }
        internal CodeSpan(string content, bool hidden) : base(SpanKind.Code, content, hidden) { }
        internal CodeSpan(string content, bool hidden, AcceptedCharacters acceptedCharacters) : base(SpanKind.Code, content, hidden, acceptedCharacters) { }

        public CodeSpan(SourceLocation start, string content) : base(SpanKind.Code, start, content) { }
        public CodeSpan(SourceLocation start, string content, bool hidden) : base(SpanKind.Code, start, content, hidden) { }
        public CodeSpan(SourceLocation start, string content, bool hidden, AcceptedCharacters acceptedCharacters) : base(SpanKind.Code, start, content, hidden, acceptedCharacters) { }

        public static CodeSpan Create(ParserContext context) {
            return new CodeSpan(context.CurrentSpanStart, context.ContentBuffer.ToString());
        }

        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "string", Justification="terminatingString is the most descriptive name for this parameter")]
        public static CodeSpan Create(ParserContext context, string autoCompleteString) {
            return new CodeSpan(context.CurrentSpanStart, context.ContentBuffer.ToString()) {
                AutoCompleteString = autoCompleteString
            };
        }

        public static CodeSpan Create(ParserContext context, bool hidden) {
            return new CodeSpan(context.CurrentSpanStart, context.ContentBuffer.ToString(), hidden);
        }

        public static CodeSpan Create(ParserContext context, bool hidden, AcceptedCharacters acceptedCharacters) {
            return new CodeSpan(context.CurrentSpanStart, context.ContentBuffer.ToString(), hidden, acceptedCharacters);
        }

        public override string ToString() {
            return base.ToString();
        }

        protected override PartialParseResult CanAcceptChange(TextChange change) {
            if (IsAtEndOfFirstLine(change) && change.IsInsert && ParserHelpers.IsNewLine(change.NewText) && AutoCompleteString != null) {
                return PartialParseResult.Rejected | PartialParseResult.AutoCompleteBlock;
            }
            return PartialParseResult.Rejected;
        }
    }
}
