using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Web.Razor.Resources;

namespace System.Web.Razor.Generator {
    // Utility class which helps write code snippets
    public abstract class CodeWriter : IDisposable {
        private StringWriter _writer;
        
        private Stack<WriterMode> _contextStack = new Stack<WriterMode>();

        public string Content {
            get {
                return InnerWriter.ToString();
            }
        }

        public StringWriter InnerWriter {
            get {
                if (_writer == null) {
                    _writer = new StringWriter(CultureInfo.InvariantCulture);
                }
                return _writer;
            }
        }

        protected CodeWriter() { }
        
        public abstract void WriteParameterSeparator();
        public abstract void WriteReturn();
        public abstract void WriteLinePragma(int? lineNumber, string fileName);
        public abstract void WriteHelperHeaderPrefix(string templateTypeName, bool isStatic);
        public abstract void WriteSnippet(string snippet);
        public abstract void WriteStringLiteral(string literal);

        public virtual void WriteHiddenLinePragma() {

        }

        public virtual void WriteIdentifier(string identifier) {
            InnerWriter.Write(identifier);
        }

        public virtual void WriteHelperHeaderSuffix(string templateTypeName) {
        }

        public virtual void WriteHelperTrailer() {
        }

        public void WriteStartMethodInvoke(string methodName) {
            _contextStack.Push(WriterMode.MethodCall);
            EmitStartMethodInvoke(methodName);
        }

        public void WriteEndMethodInvoke() {
            EnsureCorrectContext(WriterMode.MethodCall);
            EmitEndMethodInvoke();
            _contextStack.Pop();
        }

        public virtual void WriteEndStatement() {
        }

        public virtual void WriteStartAssignment(string variableName) {
            InnerWriter.Write(variableName);
            InnerWriter.Write(" = ");
        }

        public void WriteStartLambdaExpression(params string[] parameterNames) {
            _contextStack.Push(WriterMode.LambdaExpression);
            EmitStartLambdaExpression(parameterNames);
        }

        public void WriteStartConstructor(string typeName) {
            _contextStack.Push(WriterMode.Constructor);
            EmitStartConstructor(typeName);
        }

        public void WriteStartLambdaDelegate(params string[] parameterNames) {
            _contextStack.Push(WriterMode.LambdaDelegate);
            EmitStartLambdaDelegate(parameterNames);
        }

        public void WriteEndLambdaExpression() {
            EnsureCorrectContext(WriterMode.LambdaExpression);
            EmitEndLambdaExpression();
            _contextStack.Pop();
        }

        public void WriteEndConstructor() {
            EnsureCorrectContext(WriterMode.Constructor);
            EmitEndConstructor();
            _contextStack.Pop();
        }

        public void WriteEndLambdaDelegate() {
            EnsureCorrectContext(WriterMode.LambdaDelegate);
            EmitEndLambdaDelegate();
            _contextStack.Pop();
        }

        private void EnsureCorrectContext(WriterMode writerContext) {
            if (_contextStack.Count == 0) {
                Debug.Fail(String.Format(CultureInfo.CurrentCulture,
                                  RazorResources.CodeWriter_NoCurrentContext,
                                  GetContextName(writerContext)));
                throw new InvalidOperationException(
                    String.Format(CultureInfo.CurrentCulture,
                                  RazorResources.CodeWriter_NoCurrentContext,
                                  GetContextName(writerContext)));
            }
            else if (_contextStack.Peek() != writerContext) {
                Debug.Fail(String.Format(CultureInfo.CurrentCulture,
                                  RazorResources.CodeWriter_MismatchedContexts,
                                  GetContextName(writerContext),
                                  GetContextName(_contextStack.Peek())));
                throw new InvalidOperationException(
                    String.Format(CultureInfo.CurrentCulture, 
                                  RazorResources.CodeWriter_MismatchedContexts,
                                  GetContextName(writerContext),
                                  GetContextName(_contextStack.Peek())));
            }
        }

        private static string GetContextName(WriterMode writerContext) {
            return RazorResources.ResourceManager.GetString("WriterContext_" + writerContext.ToString());
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Clear() {
            if (InnerWriter != null) {
                InnerWriter.GetStringBuilder().Clear();
            }
        }

        public CodeSnippetStatement ToStatement() {
            return new CodeSnippetStatement(Content);
        }

        public CodeSnippetTypeMember ToTypeMember() {
            return new CodeSnippetTypeMember(Content);
        }

        protected internal abstract void EmitStartLambdaDelegate(string[] parameterNames);
        protected internal abstract void EmitStartLambdaExpression(string[] parameterNames);
        protected internal abstract void EmitStartConstructor(string typeName);
        protected internal abstract void EmitStartMethodInvoke(string methodName);

        protected internal abstract void EmitEndLambdaDelegate();
        protected internal abstract void EmitEndLambdaExpression();
        protected internal abstract void EmitEndConstructor();
        protected internal abstract void EmitEndMethodInvoke();

        protected virtual void Dispose(bool disposing) {
            if (disposing && _writer != null) {
                _writer.Dispose();
            }
        }

        private enum WriterMode {
            Constructor,
            MethodCall,
            LambdaDelegate,
            LambdaExpression
        }
    }
}
