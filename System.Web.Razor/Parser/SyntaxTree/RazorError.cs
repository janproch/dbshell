using System.Globalization;
using System.Web.Razor.Text;

namespace System.Web.Razor.Parser.SyntaxTree {
    public class RazorError : IEquatable<RazorError> {
        public string Message { get; private set; }
        public SourceLocation Location { get; private set; }
        public int Length { get; private set; }

        public RazorError(string message, SourceLocation location)
            : this(message, location, 1) {
        }

        public RazorError(string message, SourceLocation location, int length) {
            Message = message;
            Location = location;
            Length = length;
        }

        public override string ToString() {
            return String.Format(CultureInfo.CurrentCulture, "Error @ {0}({2}) - [{1}]", Location, Message, Length);
        }

        public override bool Equals(object obj) {
            RazorError err = obj as RazorError;
            return (err != null) && (Equals(err));
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public bool Equals(RazorError other) {
            return String.Equals(other.Message, Message, StringComparison.Ordinal) &&
                   Location.Equals(other.Location);
        }
    }
}
