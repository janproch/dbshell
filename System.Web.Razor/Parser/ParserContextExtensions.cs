using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Web.Razor.Resources;
using System.Web.Razor.Text;
using System.Web.Razor.Utils;

namespace System.Web.Razor.Parser {
    public static class ParserContextExtensions {
        public static bool Accept(this ParserContext context, string expected, bool caseSensitive) {
            SourceLocation? errorLocation;
            char? errorChar;
            return Accept(context, expected, caseSensitive, out errorLocation, out errorChar);
        }

        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "4#", Justification = "Out parameters are required in this case")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "3#", Justification = "Out parameters are required in this case")]
        public static bool Accept(this ParserContext context, string expected, bool caseSensitive, out SourceLocation? errorLocation, out char? errorChar) {
            errorLocation = null;
            errorChar = null;
            using (context.StartTemporaryBuffer()) {
                for (int i = 0; i < expected.Length; i++) {
                    if (CharsEqual(expected[i], context.CurrentCharacter, caseSensitive)) {
                        context.AcceptCurrent();
                    }
                    else {
                        errorLocation = context.CurrentLocation;
                        errorChar = context.CurrentCharacter;
                        context.RejectTemporaryBuffer();
                        return false;
                    }
                }
                context.AcceptTemporaryBuffer();
            }
            return true;
        }

        private static bool CharsEqual(char l, char r, bool caseSensitive) {
            if (!caseSensitive) {
                l = Char.ToLowerInvariant(l);
                r = Char.ToLowerInvariant(r);
            }
            return l == r;
        }

        public static bool Expect(this ParserContext context, char expected) {
            return Expect(context, expected, true, null, true, null);
        }

        public static bool Expect(this ParserContext context, char expected, bool outputError) {
            return Expect(context, expected, outputError, null, true, null);
        }

        public static bool Expect(this ParserContext context, char expected, bool outputError, string errorMessage) {
            return Expect(context, expected, outputError, errorMessage, true, null);
        }

        public static bool Expect(this ParserContext context, char expected, bool outputError , string errorMessage, bool caseSensitive) {
            return Expect(context, expected, outputError, errorMessage, caseSensitive, null);
        }

        public static bool Expect(this ParserContext context, char expected, bool outputError, string errorMessage, bool caseSensitive, SourceLocation? errorLocation) {
            return Expect(context, expected.ToString(), outputError, errorMessage, caseSensitive, errorLocation);
        }

        public static bool Expect(this ParserContext context, string expected) {
            return Expect(context, expected, true, null, true, null);
        }

        public static bool Expect(this ParserContext context, string expected, bool outputError) {
            return Expect(context, expected, outputError, null, true, null);
        }

        public static bool Expect(this ParserContext context, string expected, bool outputError, string errorMessage) {
            return Expect(context, expected, outputError, errorMessage, true, null);
        }

        public static bool Expect(this ParserContext context, string expected, bool outputError, string errorMessage, bool caseSensitive) {
            return Expect(context, expected, outputError, errorMessage, caseSensitive, null);
        }

        public static bool Expect(this ParserContext context, string expected, bool outputError, string errorMessage, bool caseSensitive, SourceLocation? errorLocation) {
            SourceLocation? errLoc;
            char? errorChar;
            if (!Accept(context, expected, caseSensitive, out errLoc, out errorChar)) {
                if (outputError) {
                    context.OnError(errorLocation ?? errLoc ?? context.CurrentLocation, errorMessage ?? RazorResources.ParseError_Expected_X, expected);
                }
                return false;
            }
            return true;
        }

        public static void AcceptCharacters(this ParserContext context, int number) {
            for (int i = 0; i < number; i++) {
                context.AcceptCurrent();
            }
        }

        public static void AcceptLine(this ParserContext context, bool includeNewLineSequence) {
            context.AcceptUntil('\r', '\n');
            if (!includeNewLineSequence) {
                return;
            }

            if (context.CurrentCharacter == '\r') {
                context.AcceptCurrent();
                if (context.CurrentCharacter == '\n') {
                    context.AcceptCurrent();
                }
            }
            else if (context.CurrentCharacter == '\n') {
                context.AcceptCurrent();
            }
        }

        public static string AcceptIdentifier(this ParserContext context) {
            // Identifier Start is a proper subset of Identifier Part, so this will also parse the start character
            if (ParserHelpers.IsIdentifierStart(context.CurrentCharacter)) {
                return context.AcceptWhile(c => ParserHelpers.IsIdentifierPart(c));
            }
            return null;
        }

        public static string AcceptUntil(this ParserContext context, SourceLocation location) {
            var builder = new StringBuilder();
            while (context.CurrentLocation < location) {
                builder.Append(context.AcceptCurrent());
            }
            return builder.ToString();
        }

        public static string AcceptUntil(this ParserContext context, Predicate<char> condition) {
            return context.AcceptWhile(c => !condition(c));
        }

        public static string AcceptUntil(this ParserContext context, params char[] terminators) {
            return context.Append(context.Source.ReadUntil(terminators));
        }

        public static string AcceptUntilInclusive(this ParserContext context, params char[] terminators) {
            return context.Append(context.Source.ReadUntil(true, terminators));
        }

        public static string AcceptWhiteSpace(this ParserContext context, bool includeNewLines) {
            return context.Append(context.ReadWhiteSpace(includeNewLines));
        }

        public static string AcceptWhile(this ParserContext context, Predicate<char> condition) {
            return context.Append(context.Source.ReadWhile(condition));
        }

        public static string ReadWhiteSpace(this ParserContext context, bool includeNewLines) {
            return context.Source.ReadWhile(c => Char.IsWhiteSpace(c) && (includeNewLines || !CharUtils.IsNewLine(c)));
        }

        public static bool Peek(this ParserContext context, string expectedText, bool caseSensitive) {
            if (expectedText == null) { throw new ArgumentNullException("expectedText"); }

            // Check the first character outside of lookahead to avoid the overhead of starting a lookahead if there's no match
            if (!CharsEqual(context.CurrentCharacter, expectedText[0], caseSensitive)) {
                return false;
            }

            using (context.Source.BeginLookahead()) {
                for (int i = 0; i < expectedText.Length; i++) {
                    int ch = context.Source.Read();
                    if (ch == -1 || !CharsEqual((char)ch, expectedText[i], caseSensitive)) {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool PeekAny(this ParserContext context, params string[] items) {
            return PeekAny(context, true, items);
        }

        public static bool PeekAny(this ParserContext context, bool caseSensitive, params string[] items) {
            // TODO: Can we optimize this?
            foreach (string item in items) {
                if (Peek(context, item, caseSensitive)) {
                    return true;
                }
            }
            return false;
        }

        public static string ExpectIdentifier(this ParserContext context, string unexpectedErrorMessageFormat) {
            return ExpectIdentifier(context, unexpectedErrorMessageFormat, allowPrecedingWhiteSpace: true);
        }

        public static string ExpectIdentifier(this ParserContext context, string unexpectedErrorMessageFormat, bool allowPrecedingWhiteSpace) {
            return ExpectIdentifier(context, unexpectedErrorMessageFormat, allowPrecedingWhiteSpace, errorLocation: null);
        }

        public static string ExpectIdentifier(this ParserContext context, string unexpectedErrorMessageFormat, bool allowPrecedingWhiteSpace, SourceLocation? errorLocation) {
            using (context.StartTemporaryBuffer()) {
                if (allowPrecedingWhiteSpace) {
                    context.AcceptWhiteSpace(includeNewLines: true);
                }
                if (!ParserHelpers.IsIdentifierStart(context.CurrentCharacter)) {
                    if (context.EndOfFile) {
                        context.OnError(errorLocation ?? context.CurrentLocation, unexpectedErrorMessageFormat, RazorResources.ErrorComponent_EndOfFile);
                    }
                    else if (Char.IsWhiteSpace(context.CurrentCharacter)) {
                        context.OnError(errorLocation ?? context.CurrentLocation, unexpectedErrorMessageFormat, RazorResources.ErrorComponent_Whitespace);
                    }
                    else {
                        context.OnError(errorLocation ?? context.CurrentLocation,
                                    unexpectedErrorMessageFormat,
                                    String.Format(CultureInfo.CurrentCulture,
                                                  RazorResources.ErrorComponent_Character,
                                                  context.CurrentCharacter));
                    }
                    return null;
                }
                else {
                    context.AcceptTemporaryBuffer();
                }
            }

            return context.AcceptIdentifier();
        }

        public static void AcceptNewLine(this ParserContext context) {
            if (context.CurrentCharacter == '\n') {
                context.AcceptCurrent();
            }
            else if (context.CurrentCharacter == '\r') {
                context.AcceptCurrent();
                if (context.CurrentCharacter == '\n') {
                    context.AcceptCurrent();
                }
            }
        }
    }
}
