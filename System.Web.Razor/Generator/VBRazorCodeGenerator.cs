using System.Web.Razor.Parser.SyntaxTree;

namespace System.Web.Razor.Generator {
    public class VBRazorCodeGenerator : RazorCodeGenerator {
        public VBRazorCodeGenerator(string className, string rootNamespaceName, string sourceFileName, RazorEngineHost host)
            : base(className, rootNamespaceName, sourceFileName, host) { }

        protected override CodeWriter CreateCodeWriter() {
            return new VBCodeWriter();
        }

        protected override void WriteHelperVariable(string type, string name) {
            // Write the design-time inherits helper
            CurrentBlock.Writer.WriteSnippet("Dim ");
            CurrentBlock.Writer.WriteSnippet(name);
            CurrentBlock.Writer.WriteSnippet(" As ");
            CurrentBlock.MarkStartGeneratedCode();
            CurrentBlock.Writer.WriteSnippet(type);
            CurrentBlock.MarkEndGeneratedCode();
            CurrentBlock.Writer.WriteSnippet(" = Nothing");
            CurrentBlock.Writer.WriteEndStatement();
            HelperVariablesMethod.Statements.Add(CreateStatement(CurrentBlock));
            CurrentBlock.ResetBuffer();
        }

        public override void VisitSpan(Span span) {
            if (!TryVisit<VBOptionSpan>(span, VisitSpan)) {
                base.VisitSpan(span);
            }
        }

        protected virtual void VisitSpan(VBOptionSpan span) {
            if (!String.IsNullOrEmpty(span.OptionName)) {
                GeneratedCode.UserData[span.OptionName] = span.Value;
            }
        }
    }
}
