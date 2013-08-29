namespace System.Web.Razor.Generator {
    using System;
    using System.CodeDom;
    using Microsoft.Internal.Web.Utils;

    public class CodeGenerationCompleteEventArgs : EventArgs {
        public CodeCompileUnit GeneratedCode { get; private set; }
        public string VirtualPath { get; private set; }
        public string PhysicalPath { get; private set; }

        public CodeGenerationCompleteEventArgs(string virtualPath, string physicalPath, CodeCompileUnit generatedCode) {
            if (String.IsNullOrEmpty(virtualPath)) {
                throw ExceptionHelper.CreateArgumentNullOrEmptyException("virtualPath");
            }
            if (generatedCode == null) {
                throw new ArgumentNullException("generatedCode");
            }
            VirtualPath = virtualPath;
            PhysicalPath = physicalPath;
            GeneratedCode = generatedCode;
        }
    }
}