using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.Razor.Text;

namespace System.Web.Razor.Parser.SyntaxTree {
    /// <summary>
    /// Span representing an implicit expression
    /// </summary>
    /// <remarks>
    /// Sample implicit expressions:
    ///   @foo.bar
    ///   @foo.bar(baz + boz)
    ///   @foo["bar"]
    ///   @foo["biz"](boz + 1).qux
    /// This class contains the logic to handle partial parsing of Implicit Expressions at design-time.
    /// </remarks>
    public class ImplicitExpressionSpan : CodeSpan {
        internal bool AcceptTrailingDot { get; private set; }
        internal ISet<string> Keywords { get; private set; }

        // For parser unit tests, where start point is calculated
        internal ImplicitExpressionSpan(string content, ISet<string> keywords, bool acceptTrailingDot)
            : this(content, keywords, acceptTrailingDot, AcceptedCharacters.NonWhiteSpace) { }

        internal ImplicitExpressionSpan(string content, ISet<string> keywords, bool acceptTrailingDot, AcceptedCharacters acceptedCharacters)
            : base(content) {
            Keywords = keywords ?? new HashSet<string>();
            AcceptTrailingDot = acceptTrailingDot;
            AcceptedCharacters = acceptedCharacters;
        }

        public ImplicitExpressionSpan(SourceLocation start, string content, ISet<string> keywords, bool acceptTrailingDot)
            : this(start, content, keywords, acceptTrailingDot, AcceptedCharacters.NonWhiteSpace) { }

        public ImplicitExpressionSpan(SourceLocation start, string content, ISet<string> keywords, bool acceptTrailingDot, AcceptedCharacters acceptedCharacters)
            : base(start, content) {
            Keywords = keywords ?? new HashSet<string>();
            AcceptTrailingDot = acceptTrailingDot;
            AcceptedCharacters = acceptedCharacters;
        }

        public static ImplicitExpressionSpan Create(ParserContext context, ISet<string> keywords, bool acceptTrailingDot, AcceptedCharacters acceptedCharacters) {
            return new ImplicitExpressionSpan(context.CurrentSpanStart, context.ContentBuffer.ToString(), keywords, acceptTrailingDot, acceptedCharacters);
        }

        public override bool Equals(object obj) {
            ImplicitExpressionSpan other = obj as ImplicitExpressionSpan;
            return other != null && base.Equals(other) && other.AcceptTrailingDot == AcceptTrailingDot;
        }

        // REVIEW: This seems unnecessary since the base class (Span) implementation is perfect for us, but we get a Warning (as Error) if we don't put this here...
        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public override string ToString() {
            return String.Format(CultureInfo.CurrentCulture,
                                 "{0} - {1}",
                                 base.ToString(),
                                 AcceptTrailingDot ? "AcceptTrailingDot" : "DontAcceptTrailingDot");
        }

        protected override PartialParseResult CanAcceptChange(TextChange change) {
            if (AcceptedCharacters == AcceptedCharacters.Any) {
                // TODO: Support partial parsing within brackets (with provisionally accepted "(" and "["?)
                return PartialParseResult.Rejected;
            }

            if (IsAcceptableReplace(change)) {
                return HandleReplacement(change);
            }
            else {
                int changeRelativePosition = change.OldPosition - Start.AbsoluteIndex;

                // Get the edit context
                char? lastChar = null;
                if (changeRelativePosition > 0 && Content.Length > 0) {
                    lastChar = Content[changeRelativePosition - 1];
                }

                // Don't support 0->1 length edits
                if (lastChar == null) {
                    return PartialParseResult.Rejected;
                }

                // Only support insertions at the end of the span
                if (IsAcceptableInsertion(change)) {
                    // Handle the insertion
                    return HandleInsertion(lastChar.Value, change);

                }
                else if (IsAcceptableDeletion(change)) {
                    return HandleDeletion(lastChar.Value, change);
                }
            }

            return PartialParseResult.Rejected;
        }

        private bool IsAcceptableReplace(TextChange change) {
            return IsEndReplace(change) ||
                   (change.IsReplace && RemainingIsWhitespace(change));
        }

        private bool IsAcceptableDeletion(TextChange change) {
            return IsEndDeletion(change) ||
                   (change.IsDelete && RemainingIsWhitespace(change));
        }

        private bool IsAcceptableInsertion(TextChange change) {
            return IsEndInsertion(change) ||
                   (change.IsInsert && RemainingIsWhitespace(change));
        }

        private bool RemainingIsWhitespace(TextChange change) {
            int offset = (change.OldPosition - Start.AbsoluteIndex) + change.OldLength;
            return String.IsNullOrWhiteSpace(Content.Substring(offset));
        }

        private PartialParseResult HandleReplacement(TextChange change) {
            // Special Case for IntelliSense commits.
            //  When IntelliSense commits, we get two changes (for example user typed "Date", then committed "DateTime" by pressing ".")
            //  1. Insert "." at the end of this span
            //  2. Replace the "Date." at the end of the span with "DateTime."
            //  We need partial parsing to accept case #2.
            string oldText = GetOldText(change);

            PartialParseResult result = PartialParseResult.Rejected;
            if (IsDotWithOptionalPreceedingIdentifier(oldText) && IsDotWithOptionalPreceedingIdentifier(change.NewText)) {
                result = PartialParseResult.Accepted;
                if (!AcceptTrailingDot) {
                    result |= PartialParseResult.Provisional;
                }
            }
            return result;
        }

        private PartialParseResult HandleDeletion(char previousChar, TextChange change) {
            // What's left after deleting?
            if (previousChar == '.') {
                return TryAcceptChange(change, PartialParseResult.Accepted | PartialParseResult.Provisional);
            }
            else if (ParserHelpers.IsIdentifierPart(previousChar)) {
                return TryAcceptChange(change);
            }
            else {
                return PartialParseResult.Rejected;
            }
        }

        private PartialParseResult HandleInsertion(char previousChar, TextChange change) {
            // What are we inserting after?
            if (previousChar == '.') {
                return HandleInsertionAfterDot(change);
            }
            else if (ParserHelpers.IsIdentifierPart(previousChar)) {
                return HandleInsertionAfterIdPart(change);
            }
            else {
                return PartialParseResult.Rejected;
            }
        }

        private PartialParseResult HandleInsertionAfterIdPart(TextChange change) {
            // If the insertion is a full identifier part, accept it
            if (ParserHelpers.IsIdentifier(change.NewText, requireIdentifierStart: false)) {
                return TryAcceptChange(change);
            }
            else if (IsDotWithOptionalPreceedingIdentifier(change.NewText)) {
                // Accept it, possibly provisionally
                PartialParseResult result = PartialParseResult.Accepted;
                if (!AcceptTrailingDot) {
                    result |= PartialParseResult.Provisional;
                }
                return TryAcceptChange(change, result);
            }
            else {
                return PartialParseResult.Rejected;
            }
        }

        private static bool IsDotWithOptionalPreceedingIdentifier(string content) {
            return (content.Length == 1 && content[0] == '.') ||
                   (content[content.Length - 1] == '.' &&
                    content.Take(content.Length - 1).All(ParserHelpers.IsIdentifierPart));
        }

        private PartialParseResult HandleInsertionAfterDot(TextChange change) {
            // If the insertion is a full identifier, accept it
            if (ParserHelpers.IsIdentifier(change.NewText)) {
                return TryAcceptChange(change);
            }
            return PartialParseResult.Rejected;
        }

        private PartialParseResult TryAcceptChange(TextChange change, PartialParseResult acceptResult = PartialParseResult.Accepted) {
            string content = change.ApplyChange(this);
            if (StartsWithKeyword(content)) {
                return PartialParseResult.Rejected | PartialParseResult.SpanContextChanged;
            }

            return acceptResult;
        }

        private bool StartsWithKeyword(string newContent) {
            using (StringReader reader = new StringReader(newContent)) {
                return Keywords.Contains(reader.ReadWhile(ParserHelpers.IsIdentifierPart));
            }
        }
    }
}
