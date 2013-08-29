using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Web.Razor.Text;

namespace System.Web.Razor.Parser.SyntaxTree {
    public delegate Span SpanFactory(ParserContext context);

    public abstract class Span : SyntaxTreeNode {
        private SourceLocation? _start;
        private string _content;

        [SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods", Justification = "Type is the most appropriate name for this property and there is little chance of confusion with GetType")]
        public SpanKind Kind { get; set; }
        public bool Hidden { get; set; }
        public AcceptedCharacters AcceptedCharacters { get; set; }

        public Span Previous { get; set; }
        public Span Next { get; set; }

        public string AutoCompleteString {
            get;
            set;
        }

        public override bool IsBlock {
            get { return false; }
        }

        public override int Length {
            get { return Content.Length; }
        }

        public override SourceLocation Start {
            get {
                EnsureStart();
                return _start.Value;
            }
        }

        public SourceLocation Offset {
            get;
            private set;
        }

        public string Content {
            get { return _content; }
            set {
                _content = value;
                UpdateOffset();
            }
        }

        private int EndIndex {
            get { return Start.AbsoluteIndex + Length; }
        }

        // For parser unit tests, where start point is calculated
        internal Span(SpanKind kind, string content) : this(kind, content, false, AcceptedCharacters.Any) { }
        internal Span(SpanKind kind, string content, bool hidden) : this(kind, content, hidden, AcceptedCharacters.Any) { }
        internal Span(SpanKind kind, string content, bool hidden, AcceptedCharacters acceptedCharacters) {
            Kind = kind;
            Content = content;
            Hidden = hidden;
            AcceptedCharacters = acceptedCharacters;
        }

        protected Span(SpanKind kind, SourceLocation start, string content)
            : this(kind, content) {
            _start = start;
        }

        protected Span(SpanKind kind, SourceLocation start, string content, bool hidden)
            : this(kind, content, hidden) {
            _start = start;
        }

        protected Span(SpanKind kind, SourceLocation start, string content, bool hidden, AcceptedCharacters acceptedCharacters)
            : this(kind, content, hidden, acceptedCharacters) {
            _start = start;
        }

        protected Span(ParserContext context, SpanKind kind) : this(kind, context.CurrentSpanStart, context.ContentBuffer.ToString()) { }
        protected Span(ParserContext context, SpanKind kind, bool hidden) : this(kind, context.CurrentSpanStart, context.ContentBuffer.ToString(), hidden) { }
        protected Span(ParserContext context, SpanKind kind, bool hidden, AcceptedCharacters acceptedCharacters) : this(kind, context.CurrentSpanStart, context.ContentBuffer.ToString(), hidden, acceptedCharacters) { }

        /// <summary>
        /// Accepts the specified visitor
        /// </summary>
        /// <remarks>
        /// Calls the VisitSpan method on the specified visitor, passing in this
        /// </remarks>
        public override void Accept(ParserVisitor visitor) {
            visitor.VisitSpan(this);
        }

        /// <summary>
        /// Applies the specified change to this span
        /// </summary>
        /// <remarks>
        /// If this method returns a value with the PartialParseResults.Accepted flag, the change has been applied to the span and the Partial Parsing of this
        /// change is complete.
        /// </remarks>
        /// <returns>true if the change was successfully applied, false if it wasn't</returns>
        public PartialParseResult ApplyChange(TextChange change) {
            return ApplyChange(change, force: false);
        }

        /// <summary>
        /// Applies the specified change to this span, optionally forcing it to accept it
        /// </summary>
        /// <param name="force">If true, no evaluation is performed, the content of the span is simply updated based on the change</param>
        /// <remarks>
        /// If this method returns a value with the PartialParseResults.Accepted flag, the change has been applied to the span.
        /// If force was specified, this does not indicate that the partial parsing was successful, only that the Span now reflects the applied change.
        /// </remarks>
        /// <returns>true if the change was successfully applied, false if it wasn't</returns>
        public PartialParseResult ApplyChange(TextChange change, bool force) {
            PartialParseResult result = PartialParseResult.Accepted;
            TextChange normalized = change.Normalize();
            if (!force) {
                result = CanAcceptChange(normalized);
            }
            
            // If the change is accepted then apply the change
            if (result.HasFlag(PartialParseResult.Accepted)) {
                UpdateContent(normalized);
            }

            return result;
        }

        protected virtual PartialParseResult CanAcceptChange(TextChange change) {
            return PartialParseResult.Rejected;
        }

        private void UpdateContent(TextChange change) {
            // Update the span's content
            Content = change.ApplyChange(this);

            ClearCachedStartPoints(Next);
        }

        /// <summary>
        /// Determines if the specified change belongs to this span.
        /// </summary>
        /// <remarks>
        /// Used for Partial Parsing to identify which span to augment with the specified change.
        /// Some changes have no owner, because they overlap multiple spans.
        /// Also, just because a span owns a change, doesn't mean it can accept it
        /// </remarks>
        public virtual bool OwnsChange(TextChange change) {
            int changeOldEnd = change.OldPosition + change.OldLength;
            return change.OldPosition >= Start.AbsoluteIndex &&
                   (changeOldEnd < EndIndex || (changeOldEnd == EndIndex && AcceptedCharacters != AcceptedCharacters.None));
        }

        public override string ToString() {
            string type = GetSpanTypeName();
            if (!String.Equals(type, Kind.ToString(), StringComparison.OrdinalIgnoreCase)) {
                type = String.Format(CultureInfo.CurrentCulture, "{0}/{1}", Kind, type);
            }
            string autoComplete = null;
            if (!String.IsNullOrEmpty(AutoCompleteString)) {
                autoComplete = String.Format(CultureInfo.CurrentCulture, "- AutoComplete:({0})", AutoCompleteString);
            }
            return String.Format(CultureInfo.CurrentCulture, "{0} Span [{3};{4}] at {1}::{5} - [{2}]{6}", type, Start, Content, Hidden ? "H" : "V", AcceptedCharacters, Length, autoComplete);
        }

        public override bool Equals(object obj) {
            Span other = obj as Span;
            return other != null &&
                   other.Kind.Equals(Kind) &&
                   other.Start.Equals(Start) &&
                   String.Equals(other.Content, Content, StringComparison.Ordinal) &&
                   other.AcceptedCharacters == AcceptedCharacters &&
                   other.Hidden == Hidden &&
                   String.Equals(AutoCompleteString, AutoCompleteString, StringComparison.Ordinal);
        }

        public override int GetHashCode() {
            return (int)Kind ^ Start.GetHashCode() ^ Content.GetHashCode();
        }

        /// <summary>
        /// Merges the specified span into the current span
        /// </summary>
        /// <remarks>
        /// <paramref name="other"/> must be adjacent to the current span, but may be on _either_ the left or the right.
        /// The content of the other span is merged into this span and the Start point is updated if merging left.
        /// None of the other attributes of this span are changed, and the other span is unchanged.
        /// </remarks>
        /// <param name="other">The span to merge in to this one</param>
        public bool TryMergeWith(Span other) {
            if (IsAdjacentOnLeft(other)) {
                MergeLeft(other);
                return true;
            }
            else if (IsAdjacentOnRight(other)) {
                MergeRight(other);
                return true;
            }
            return false;
        }

        protected bool IsAtEndOfFirstLine(TextChange change) {
            int endOfFirstLine = Content.IndexOfAny(new char[] { (char)0x000d, (char)0x000a, (char)0x2028, (char)0x2029 });
            return (endOfFirstLine == -1 || (change.OldPosition - Start.AbsoluteIndex) <= endOfFirstLine);
        }
        
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "This method performs non-trivial work and is not suitable for a property")]
        protected virtual string GetSpanTypeName() {
            string type = GetType().Name;
            if (type.EndsWith("Span", StringComparison.OrdinalIgnoreCase)) {
                type = type.Substring(0, type.Length - 4);
            }
            return type;
        }

        /// <summary>
        /// Returns true if the specified change is an insertion of text at the end of this span.
        /// </summary>
        protected bool IsEndInsertion(TextChange change) {
            return change.IsInsert && IsAtEndOfSpan(change);
        }

        /// <summary>
        /// Returns true if the specified change is an insertion of text at the end of this span.
        /// </summary>
        protected bool IsEndDeletion(TextChange change) {
            return change.IsDelete && IsAtEndOfSpan(change);
        }

        /// <summary>
        /// Returns true if the specified change is a replacement of text at the end of this span.
        /// </summary>
        protected bool IsEndReplace(TextChange change) {
            return change.IsReplace && IsAtEndOfSpan(change);
        }

        protected bool IsAtEndOfSpan(TextChange change) {
            return (change.OldPosition + change.OldLength) == EndIndex;
        }

        /// <summary>
        /// Returns the old text referenced by the change.
        /// </summary>
        /// <remarks>
        /// If the content has already been updated by applying the change, this data will be _invalid_
        /// </remarks>
        protected internal string GetOldText(TextChange change) {
            return Content.Substring(change.OldPosition - Start.AbsoluteIndex, change.OldLength);
        }

        private void EnsureStart() {
            if (_start == null) {
                if (Previous == null) {
                    _start = SourceLocation.Zero;
                }
                else {
                    Debug.Assert(!ReferenceEquals(Previous, this), "Cycle detected in Span chain.");
                    // Update the start position based on the offset.  Absolute and Line are added, Character offset is simply set
                    _start = new SourceLocation(
                        Previous.Start.AbsoluteIndex + Previous.Offset.AbsoluteIndex,
                        Previous.Start.LineIndex + Previous.Offset.LineIndex,
                        Previous.Offset.LineIndex == 0 ?
                            Previous.Start.CharacterIndex + Previous.Offset.CharacterIndex :
                            Previous.Offset.CharacterIndex
                    );
                }
            }
        }

        internal static void ClearCachedStartPoints(Span startSpan) {
            Span current = startSpan;
            while (current != null) {
                // Clear the start point of each span
                current._start = null;
                current = current.Next;
            }
        }

        private void UpdateOffset() {
            SourceLocationTracker tracker = new SourceLocationTracker();
            tracker.UpdateLocation(Content);
            Offset = tracker.CurrentLocation;
        }

        // Adds other's content to the end of this span
        private void MergeRight(Span other) {
            _content += other.Content;
        }

        // Adds other's content to the start of this span
        // Adjusts this span's start point appropriately
        private void MergeLeft(Span other) {
            _content = other.Content + _content;
            _start = other.Start;
        }

        // Is the specified span to the right of this span and immediately adjacent?
        private bool IsAdjacentOnRight(Span other) {
            return Start.AbsoluteIndex < other.Start.AbsoluteIndex && Start.AbsoluteIndex + Length == other.Start.AbsoluteIndex;
        }

        // Is the specified span to the left of this span and immediately adjacent?
        private bool IsAdjacentOnLeft(Span other) {
            return other.Start.AbsoluteIndex < Start.AbsoluteIndex && other.Start.AbsoluteIndex + other.Length == Start.AbsoluteIndex;
        }
    }
}
