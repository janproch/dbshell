using System.CodeDom;

namespace System.Web.Razor.Generator {
    public class CSharpRazorCodeGenerator : RazorCodeGenerator {
        public CSharpRazorCodeGenerator(string className, string rootNamespaceName, string sourceFileName, RazorEngineHost host)
            : base(className, rootNamespaceName, sourceFileName, host) { }

        protected override CodeWriter CreateCodeWriter() {
            return new CSharpCodeWriter();
        }

        protected override void WriteHelperVariable(string type, string name) {
            // Write the design-time inherits helper
            HelperVariablesMethod.Statements.Add(new CodeSnippetStatement("#pragma warning disable 219"));

            CurrentBlock.MarkStartGeneratedCode();
            CurrentBlock.Writer.WriteSnippet(type);
            CurrentBlock.MarkEndGeneratedCode();
            CurrentBlock.Writer.WriteSnippet(" ");
            CurrentBlock.Writer.WriteSnippet(name);
            CurrentBlock.Writer.WriteSnippet(" = null");
            CurrentBlock.Writer.WriteEndStatement();
            HelperVariablesMethod.Statements.Add(CreateStatement(CurrentBlock));
            CurrentBlock.ResetBuffer();

            HelperVariablesMethod.Statements.Add(new CodeSnippetStatement("#pragma warning restore 219"));
        }
    }
}
