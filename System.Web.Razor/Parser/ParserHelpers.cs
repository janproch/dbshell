using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace System.Web.Razor.Parser {
    public static class ParserHelpers {
        public static bool IsIdentifier(string value) {
            return IsIdentifier(value, requireIdentifierStart: true);
        }

        public static bool IsIdentifier(string value, bool requireIdentifierStart) {
            IEnumerable<char> identifierPart = value;
            if (requireIdentifierStart) {
                identifierPart = identifierPart.Skip(1);
            }
            return (!requireIdentifierStart || IsIdentifierStart(value[0])) && identifierPart.All(IsIdentifierPart);
        }

        public static bool IsHexDigit(char value) {
            return (value >= '0' && value <= '9') || (value >= 'A' && value <= 'F') || (value >= 'a' && value <= 'f');
        }

        public static bool IsIdentifierStart(char value) {
            return value == '_' || ParserHelpers.IsLetter(value);
        }

        public static bool IsIdentifierPart(char value) {
            return IsLetter(value)
                || IsDecimalDigit(value)
                || IsConnecting(value)
                || IsCombining(value)
                || IsFormatting(value);
        }

        public static bool IsTerminatingCharToken(char value) {
            return IsNewLine(value) || value == '\'';
        }

        public static bool IsTerminatingQuotedStringToken(char value) {
            return IsNewLine(value) || value == '"';
        }

        public static bool IsDecimalDigit(char value) {
            return Char.GetUnicodeCategory(value) == UnicodeCategory.DecimalDigitNumber;
        }

        public static bool IsLetter(char value) {
            var cat = Char.GetUnicodeCategory(value);
            return cat == UnicodeCategory.UppercaseLetter
                     || cat == UnicodeCategory.LowercaseLetter
                     || cat == UnicodeCategory.TitlecaseLetter
                     || cat == UnicodeCategory.ModifierLetter
                     || cat == UnicodeCategory.OtherLetter
                     || cat == UnicodeCategory.LetterNumber;
        }

        public static bool IsNewLine(char value) {
            return value == 0x000d        // Carriage return
                    || value == 0x000a        // Linefeed
                    || value == 0x2028        // Line separator
                    || value == 0x2029        // Paragraph separator
                    ;
        }

        public static bool IsNewLine(string value) {
            return (value.Length == 1 && (ParserHelpers.IsNewLine(value[0]))) ||
                    (String.Equals(value, "\r\n", StringComparison.Ordinal));
        }

        public static bool IsFormatting(char value) {
            return Char.GetUnicodeCategory(value) == UnicodeCategory.Format;
        }

        public static bool IsCombining(char value) {
            var cat = Char.GetUnicodeCategory(value);
            return cat == UnicodeCategory.SpacingCombiningMark || cat == UnicodeCategory.NonSpacingMark;
        }

        public static bool IsConnecting(char value) {
            return Char.GetUnicodeCategory(value) == UnicodeCategory.ConnectorPunctuation;
        }

        public static string SanitizeClassName(string inputName) {
            if (!ParserHelpers.IsIdentifierStart(inputName[0]) && ParserHelpers.IsIdentifierPart(inputName[0])) {
                inputName = "_" + inputName;
            }

            return new String((from value in inputName
                               select ParserHelpers.IsIdentifierPart(value) ? value : '_')
                              .ToArray());
        }
    }
}
