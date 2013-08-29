
namespace System.Web.Razor.Generator {
    public abstract class BaseCodeWriter : CodeWriter {
        public override void WriteSnippet(string snippet) {
            InnerWriter.Write(snippet);
        }

        protected internal override void EmitStartMethodInvoke(string methodName) {
            InnerWriter.Write(methodName);
            InnerWriter.Write("(");
        }

        protected internal override void EmitEndMethodInvoke() {
            InnerWriter.Write(")");
        }

        protected internal override void EmitEndConstructor() {
            InnerWriter.Write(")");
        }

        protected internal override void EmitEndLambdaExpression() {
        }

        public override void WriteParameterSeparator() {
            InnerWriter.Write(", ");
        }

        protected internal void WriteCommaSeparatedList<T>(T[] items, Action<T> writeItemAction) {
            for (int i = 0; i < items.Length; i++) {
                if (i > 0) {
                    InnerWriter.Write(", ");
                }
                writeItemAction(items[i]);
            }
        }
    }
}
