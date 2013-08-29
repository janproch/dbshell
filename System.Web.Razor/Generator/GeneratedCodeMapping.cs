using System.Globalization;
using Microsoft.Internal.Web.Utils;

namespace System.Web.Razor.Generator {
    public struct GeneratedCodeMapping {
        public int CodeLength { get; set; }
        public int StartColumn { get; set; }
        public int StartGeneratedColumn { get; set; }
        public int StartLine { get; set; }

        public GeneratedCodeMapping(int startLine, int startColumn, int startGeneratedColumn, int codeLength) : this() {
            if (startLine < 0) { throw new ArgumentOutOfRangeException("startLine", String.Format(CultureInfo.CurrentCulture, CommonResources.Argument_Must_Be_GreaterThanOrEqualTo, "startLine", "0")); }
            if (startColumn < 0) { throw new ArgumentOutOfRangeException("startColumn", String.Format(CultureInfo.CurrentCulture, CommonResources.Argument_Must_Be_GreaterThanOrEqualTo, "startColumn", "0")); }
            if (startGeneratedColumn < 0) { throw new ArgumentOutOfRangeException("startGeneratedColumn", String.Format(CultureInfo.CurrentCulture, CommonResources.Argument_Must_Be_GreaterThanOrEqualTo, "startGeneratedColumn", "0")); }
            if (codeLength < 0) { throw new ArgumentOutOfRangeException("codeLength", String.Format(CultureInfo.CurrentCulture, CommonResources.Argument_Must_Be_GreaterThanOrEqualTo, "codeLength", "0")); }

            StartLine = startLine;
            StartColumn = startColumn;
            StartGeneratedColumn = startGeneratedColumn;
            CodeLength = codeLength;
        }

        public override bool Equals(object obj) {
            if (!(obj is GeneratedCodeMapping)) {
                return false;
            }
            GeneratedCodeMapping other = (GeneratedCodeMapping)obj;
            return CodeLength == other.CodeLength &&
                   StartColumn == other.StartColumn &&
                   StartGeneratedColumn == other.StartGeneratedColumn &&
                   StartLine == other.StartColumn;
        }

        public static bool operator ==(GeneratedCodeMapping left, GeneratedCodeMapping right) {
            return left.Equals(right);
        }

        public static bool operator !=(GeneratedCodeMapping left, GeneratedCodeMapping right) {
            return !left.Equals(right);
        }

        public override int GetHashCode() {
            return CodeLength.GetHashCode() ^
                   StartColumn.GetHashCode() ^
                   StartGeneratedColumn.GetHashCode() ^
                   StartLine.GetHashCode();
        }
    }
}
