using System.Globalization;

namespace System.Web.Razor.Generator {
    public class CSharpCodeWriter : BaseCodeWriter {
        public override void WriteStringLiteral(string literal) {
            if (literal == null) { throw new ArgumentNullException("literal"); }

            // From CSharpCodeProvider in CodeDOM
            //  If the string is short, use C style quoting (e.g "\r\n")
            //  Also do it if it is too long to fit in one line
            //  If the string contains '\0', verbatim style won't work.
            if (literal.Length >= 256 && literal.Length <= 1500 && literal.IndexOf('\0') == -1) {
                WriteVerbatimStringLiteral(literal);
            }
            else {
                WriteCStyleStringLiteral(literal);
            }
        }

        private void WriteVerbatimStringLiteral(string literal) {
            // From CSharpCodeGenerator.QuoteSnippetStringVerbatim in CodeDOM
            InnerWriter.Write("@\"");
            for (int i = 0; i < literal.Length; i++) {
                if (literal[i] == '\"') {
                    InnerWriter.Write("\"\"");
                }
                else {
                    InnerWriter.Write(literal[i]);
                }
            }
            InnerWriter.Write("\"");
        }

        private void WriteCStyleStringLiteral(string literal) {
            // From CSharpCodeGenerator.QuoteSnippetStringCStyle in CodeDOM
            InnerWriter.Write("\"");
            for (int i = 0; i < literal.Length; i++) {
                switch (literal[i]) {
                    case '\r':
                        InnerWriter.Write("\\r");
                        break;
                    case '\t':
                        InnerWriter.Write("\\t");
                        break;
                    case '\"':
                        InnerWriter.Write("\\\"");
                        break;
                    case '\'':
                        InnerWriter.Write("\\\'");
                        break;
                    case '\\':
                        InnerWriter.Write("\\\\");
                        break;
                    case '\0':
                        InnerWriter.Write("\\\0");
                        break;
                    case '\n':
                        InnerWriter.Write("\\n");
                        break;
                    case '\u2028':
                    case '\u2029':
                        // Inlined CSharpCodeGenerator.AppendEscapedChar
                        InnerWriter.Write("\\u");
                        InnerWriter.Write(((int)literal[i]).ToString("X4", CultureInfo.InvariantCulture));
                        break;
                    default:
                        InnerWriter.Write(literal[i]);
                        break;
                }
                if (i > 0 && i % 80 == 0) {
                    // If current character is a high surrogate and the following 
                    // character is a low surrogate, don't break them. 
                    // Otherwise when we write the string to a file, we might lose 
                    // the characters.
                    if (Char.IsHighSurrogate(literal[i])
                        && (i < literal.Length - 1)
                        && Char.IsLowSurrogate(literal[i + 1])) {
                        InnerWriter.Write(literal[++i]);
                    }

                    InnerWriter.Write("\" +");
                    InnerWriter.Write(Environment.NewLine);
                    InnerWriter.Write('\"');
                }
            }
            InnerWriter.Write("\"");
        }

        public override void WriteEndStatement() {
            InnerWriter.WriteLine(";");
        }

        public override void WriteIdentifier(string identifier) {
            InnerWriter.Write("@" + identifier);
        }

        protected internal override void EmitStartLambdaExpression(string[] parameterNames) {
            if (parameterNames == null) { throw new ArgumentNullException("parameterNames"); }

            if (parameterNames.Length == 0 || parameterNames.Length > 1) {
                InnerWriter.Write("(");
            }
            WriteCommaSeparatedList(parameterNames, InnerWriter.Write);
            if (parameterNames.Length == 0 || parameterNames.Length > 1) {
                InnerWriter.Write(")");
            }
            InnerWriter.Write(" => ");
        }

        protected internal override void EmitStartLambdaDelegate(string[] parameterNames) {
            if (parameterNames == null) { throw new ArgumentNullException("parameterNames"); }

            EmitStartLambdaExpression(parameterNames);
            InnerWriter.WriteLine("{");
        }

        protected internal override void EmitEndLambdaDelegate() {
            InnerWriter.Write("}");
        }

        protected internal override void EmitStartConstructor(string typeName) {
            if (typeName == null) { throw new ArgumentNullException("typeName"); }

            InnerWriter.Write("new ");
            InnerWriter.Write(typeName);
            InnerWriter.Write("(");
        }

        public override void WriteReturn() {
            InnerWriter.Write("return ");
        }

        public override void WriteLinePragma(int? lineNumber, string fileName) {
            InnerWriter.WriteLine();
            if (lineNumber != null) {
                InnerWriter.Write("#line ");
                InnerWriter.Write(lineNumber);
                InnerWriter.Write(" \"");
                InnerWriter.Write(fileName);
                InnerWriter.Write("\"");
                InnerWriter.WriteLine();
            }
            else {
                InnerWriter.WriteLine("#line default");
                InnerWriter.WriteLine("#line hidden");
            }
        }

        public override void WriteHiddenLinePragma() {
            InnerWriter.WriteLine("#line hidden");
        }

        public override void WriteHelperHeaderPrefix(string templateTypeName, bool isStatic) {
            InnerWriter.Write("public ");
            if (isStatic) {
                InnerWriter.Write("static ");
            }
            InnerWriter.Write(templateTypeName);
            InnerWriter.Write(" ");
        }
    }
}