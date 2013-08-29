using System.Globalization;
using Microsoft.Internal.Web.Utils;

namespace System.Web.Razor.Text {
    [Serializable]
    public struct SourceLocation : IEquatable<SourceLocation>, IComparable<SourceLocation> {
        public static readonly SourceLocation Zero = new SourceLocation(0, 0, 0);

        private int _absoluteIndex;
        private int _lineIndex;
        private int _characterIndex;

        public int AbsoluteIndex { get { return _absoluteIndex; } }
        public int LineIndex { get { return _lineIndex; } }
        public int CharacterIndex { get { return _characterIndex; } }
        
        public SourceLocation(int absoluteIndex, int lineIndex, int characterIndex) {
            _absoluteIndex = absoluteIndex;
            _lineIndex = lineIndex;
            _characterIndex = characterIndex;
        }

        public override string ToString() {
            return String.Format(CultureInfo.CurrentCulture, "({0}:{1},{2})", AbsoluteIndex, LineIndex, CharacterIndex);
        }

        public override bool Equals(object obj) {
            return (obj is SourceLocation) && Equals((SourceLocation)obj);
        }

        public override int GetHashCode() {
            return AbsoluteIndex;
        }

        public bool Equals(SourceLocation other) {
            if (other == null) { throw new ArgumentNullException("other"); }

            return AbsoluteIndex == other.AbsoluteIndex && 
                   LineIndex == other.LineIndex && 
                   CharacterIndex == other.CharacterIndex;
        }

        public int CompareTo(SourceLocation other) {
            return AbsoluteIndex.CompareTo(other.AbsoluteIndex);
        }

        public static bool operator <(SourceLocation left, SourceLocation right) {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(SourceLocation left, SourceLocation right) {
            return left.CompareTo(right) > 0;
        }

        public static bool operator ==(SourceLocation left, SourceLocation right) {
            return left.Equals(right);
        }

        public static bool operator !=(SourceLocation left, SourceLocation right) {
            return !left.Equals(right);
        }
    }
}
