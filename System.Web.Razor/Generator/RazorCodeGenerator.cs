using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Razor.Parser;
using System.Web.Razor.Parser.SyntaxTree;
using System.Web.Razor.Resources;
using System.Web.Razor.Text;
using System.Text;
using Microsoft.Internal.Web.Utils;

namespace System.Web.Razor.Generator {
    public abstract class RazorCodeGenerator : ParserVisitor {
        private const string TemplateWriterName = "__razor_template_writer";
        private const string HelperWriterName = "__razor_helper_writer";

        protected static readonly string InheritsHelperName = "__inheritsHelper";

        private CodeCompileUnit _generatedCode;
        private CodeNamespace _rootNamespace;
        private CodeTypeDeclaration _generatedClass;
        private CodeMemberMethod _renderMethod;
        private CodeMemberMethod _helperVariablesMethod;
        private int _nextDesignTimeLinePragma = 1;
        private Stack<BlockContext> _blockStack = new Stack<BlockContext>();
        private Stack<HelperContext> _helperStack = new Stack<HelperContext>();
        private CodeWriter _writer;
        private bool _insertedExpressionVariable = false;

        private HelperContext CurrentHelper {
            get {
                Debug.Assert(_helperStack.Count > 0);
                return _helperStack.Peek();
            }
        }

        // Internal state and constants useful to derived classes
        protected internal bool InTemplate { get; set; }
        protected internal bool InSection { get; set; }
        protected internal bool InHelper { get { return _helperStack.Count > 0; } }
        protected internal bool InNestedWriterBlock { get { return InTemplate || InHelper; } }

        protected internal string CurrentWriteMethod {
            get {
                return InNestedWriterBlock ? Host.GeneratedClassContext.WriteToMethodName
                                           : Host.GeneratedClassContext.WriteMethodName;
            }
        }

        protected internal string CurrentWriteLiteralMethod {
            get {
                return InNestedWriterBlock ? Host.GeneratedClassContext.WriteLiteralToMethodName
                                           : Host.GeneratedClassContext.WriteLiteralMethodName;
            }
        }

        protected internal string CurrentWriterName {
            get {
                if (InTemplate) {
                    return TemplateWriterName;
                }
                else if (InHelper) {
                    return HelperWriterName;
                }
                return null;
            }
        }

        // Data pulled from constructor
        public string ClassName { get; private set; }
        public string RootNamespaceName { get; private set; }
        public string SourceFileName { get; private set; }
        public RazorEngineHost Host { get; private set; }

        // Generation settings
        public bool GenerateLinePragmas { get; set; }
        public bool DesignTimeMode { get; set; }

        // Outputs
        public IDictionary<int, GeneratedCodeMapping> CodeMappings { get; private set; }

        public CodeCompileUnit GeneratedCode {
            get {
                EnsureCompileUnitInitialized();
                return _generatedCode;
            }
            internal set { _generatedCode = value; }
        }

        public CodeNamespace GeneratedNamespace {
            get {
                EnsureCompileUnitInitialized();
                return _rootNamespace;
            }
        }

        public CodeTypeDeclaration GeneratedClass {
            get {
                EnsureCompileUnitInitialized();
                return _generatedClass;
            }
        }
        public CodeMemberMethod GeneratedExecuteMethod {
            get {
                EnsureCompileUnitInitialized();
                return _renderMethod;
            }
        }

        public CodeMemberMethod HelperVariablesMethod {
            get {
                EnsureCompileUnitInitialized();
                if (_helperVariablesMethod == null) {
                    _helperVariablesMethod = new CodeMemberMethod() {
                        Name = "__RazorDesignTimeHelpers__",
                        Attributes = MemberAttributes.Private
                    };
                    GeneratedClass.Members.Insert(0, _helperVariablesMethod);
                }
                return _helperVariablesMethod;
            }
        }

        protected BlockContext CurrentBlock {
            get { return _blockStack.Count > 0 ? _blockStack.Peek() : null; }
        }

        private CodeWriter Writer {
            get {
                if (_writer == null) {
                    _writer = CreateCodeWriter();
                }
                return _writer;
            }
        }

        protected RazorCodeGenerator(string className, string rootNamespaceName, string sourceFileName, RazorEngineHost host) {
            if (String.IsNullOrEmpty(className)) { throw new ArgumentException(CommonResources.Argument_Cannot_Be_Null_Or_Empty, "className"); }
            if (rootNamespaceName == null) { throw new ArgumentNullException("rootNamespaceName"); }
            if (host == null) { throw new ArgumentNullException("host"); }

            ClassName = className;
            RootNamespaceName = rootNamespaceName;
            SourceFileName = sourceFileName;
            GenerateLinePragmas = String.IsNullOrEmpty(SourceFileName) ? false : true;
            Host = host;
            CodeMappings = new Dictionary<int, GeneratedCodeMapping>();
        }

        protected abstract CodeWriter CreateCodeWriter();

        protected virtual void WriteHelperVariable(string type, string name) {
        }

        public override void VisitStartBlock(BlockType type) {
            base.VisitStartBlock(type);
            BlockContext next = new BlockContext(type, Writer);
            BlockContext current = CurrentBlock;
            if (current != null) {
                SuspendBlock(current, next);
            }
            StartBlock(next);
            _blockStack.Push(next);
        }

        public override void VisitEndBlock(BlockType type) {
            base.VisitEndBlock(type);
            BlockContext prev = CurrentBlock;
            EndBlock(CurrentBlock);
            _blockStack.Pop();
            if (CurrentBlock != null) {
                ResumeBlock(CurrentBlock, prev);
            }
        }

        public override void VisitSpan(Span span) {
            base.VisitSpan(span);
            if (span.Hidden) {
                WriteBlock(CurrentBlock);
            }
            else {
                CurrentBlock.VisitSpan(span);
                if (!TryVisitSpecialSpanCore(span)) {
                    switch (span.Kind) {
                        case SpanKind.Code:
                            CurrentBlock.Writer.WriteSnippet(span.Content);
                            if (CurrentBlock.BlockType == BlockType.Functions) {
                                // Write the block immediately
                                WriteBlock(CurrentBlock);
                            }
                            else if (CurrentBlock.BlockType == BlockType.Statement &&
                                    CurrentBlock.VisitedSpans.Count == 2 &&
                                    CurrentBlock.VisitedSpans[0].Kind == SpanKind.Transition) {
                                CurrentBlock.GeneratedColumnOffset = -1;
                            }
                            return;

                        case SpanKind.Markup:
                            if (!String.IsNullOrEmpty(span.Content)) {
                                CurrentBlock.Writer.WriteStartMethodInvoke(CurrentWriteLiteralMethod);
                                if (InNestedWriterBlock) {
                                    CurrentBlock.Writer.WriteIdentifier(CurrentWriterName);
                                    CurrentBlock.Writer.WriteParameterSeparator();
                                }
                                CurrentBlock.Writer.WriteStringLiteral(span.Content);
                                CurrentBlock.Writer.WriteEndMethodInvoke();
                                CurrentBlock.Writer.WriteEndStatement();
                                WriteBlock(CurrentBlock);
                            }
                            return;
                    }
                }
            }
        }

        private bool TryVisitSpecialSpanCore(Span span) {
            // Try the known special span types, then call the virtual version to allow subclasses to add their special spans
            return TryVisit<SectionHeaderSpan>(span, VisitSpan) ||
                   TryVisit<NamespaceImportSpan>(span, VisitSpan) ||
                   TryVisit<HelperHeaderSpan>(span, VisitSpan) ||
                   TryVisit<HelperFooterSpan>(span, VisitSpan) ||
                   TryVisit<InheritsSpan>(span, VisitSpan) ||
                   TryVisitSpecialSpan(span);
        }

        protected virtual bool TryVisitSpecialSpan(Span span) {
            return false;
        }

        protected internal static bool TryVisit<T>(Span baseSpan, Action<T> subclassVisitor) where T : Span {
            T tspan = baseSpan as T;
            if (tspan != null) {
                subclassVisitor(tspan);
                return true;
            }
            return false;
        }

        public override void VisitError(RazorError err) {
            // No-op, we don't care about errors.
            base.VisitError(err);
        }

        public override void OnComplete() {
            base.OnComplete();
        }

        protected internal virtual void VisitSpan(InheritsSpan span) {
            // Set the appropriate base type
            GeneratedClass.BaseTypes.Clear();
            GeneratedClass.BaseTypes.Add(span.BaseClass);

            if (DesignTimeMode) {
                WriteHelperVariable(span.Content, InheritsHelperName);
            }
        }

        protected internal virtual void VisitSpan(HelperFooterSpan span) {
            WriteHelperTrailer(CurrentBlock, endSequenceSpan: span);
        }

        protected internal virtual void VisitSpan(HelperHeaderSpan span) {
            Debug.Assert(InHelper);

            CurrentBlock.WriteLinePragma = DesignTimeMode;
            if (!DesignTimeMode) {
                CurrentBlock.Writer.WriteHiddenLinePragma();
            }

            // Write the prefix
            CurrentBlock.Writer.WriteHelperHeaderPrefix(Host.GeneratedClassContext.TemplateTypeName, isStatic: Host.StaticHelpers);
            CurrentBlock.MarkStartGeneratedCode();
            CurrentBlock.Writer.WriteSnippet(span.Content);
            CurrentBlock.MarkEndGeneratedCode();
            if (span.Complete) {
                CurrentBlock.Writer.WriteHelperHeaderSuffix(Host.GeneratedClassContext.TemplateTypeName);
            }
            CurrentBlock.Writer.InnerWriter.WriteLine();
            if (span.Complete) {
                CurrentBlock.Writer.WriteReturn();
                CurrentBlock.Writer.WriteStartConstructor(Host.GeneratedClassContext.TemplateTypeName);
                CurrentBlock.Writer.WriteStartLambdaDelegate(HelperWriterName);
                CurrentHelper.WroteHelperPrefix = true;
            }

            WriteBlockToHelperContent(CurrentBlock);

            CurrentBlock.ResetBuffer();
        }

        protected internal virtual void VisitSpan(NamespaceImportSpan span) {
            string ns = span.Namespace;

            // If the first character is whitespace, yank it out since the CodeDOM will add one space
            if (ns.Length > 0 && Char.IsWhiteSpace(ns[0])) {
                ns = ns.Substring(1);
            }

            // Check for an existing import
            CodeNamespaceImport existingImport =
                GeneratedNamespace.Imports
                                  .OfType<CodeNamespaceImport>()
                                  .FirstOrDefault(import => String.Equals(import.Namespace,
                                                                          span.Namespace.Trim(),
                                                                          StringComparison.Ordinal));

            CodeLinePragma pragma = CreateLinePragma(span.Start, 0, span.Content.Length);
            if (existingImport != null && existingImport.LinePragma == null) {
                existingImport.LinePragma = pragma;
                existingImport.Namespace = ns;
            }
            else {
                // Build the import
                GeneratedNamespace.Imports.Add(new CodeNamespaceImport(ns) {
                    LinePragma = pragma
                });
            }
        }

        protected internal virtual void VisitSpan(SectionHeaderSpan span) {
            if (!Host.GeneratedClassContext.AllowSections) {
                throw new InvalidOperationException(RazorResources.CodeGenerator_SectionsNotSupported);
            }

            CurrentBlock.Writer.WriteStartMethodInvoke(Host.GeneratedClassContext.DefineSectionMethodName);
            CurrentBlock.Writer.WriteStringLiteral(span.SectionName);
            CurrentBlock.Writer.WriteParameterSeparator();
            CurrentBlock.Writer.WriteStartLambdaDelegate(new string[0]);
            InSection = true;
        }

        // Called before the start of a sub-block of the specified block
        protected virtual void SuspendBlock(BlockContext currentBlock, BlockContext nextBlock) {
            currentBlock.MarkEndGeneratedCode();
            if (nextBlock.BlockType == BlockType.Template) {
                if (!Host.GeneratedClassContext.AllowTemplates) {
                    throw new InvalidOperationException(RazorResources.CodeGenerator_TemplatesNotSupported);
                }
                currentBlock.Writer.WriteStartLambdaExpression("item");
                currentBlock.Writer.WriteStartConstructor(Host.GeneratedClassContext.TemplateTypeName);
                currentBlock.Writer.WriteStartLambdaDelegate(TemplateWriterName);
            }
            WriteBlock(currentBlock);

        }

        // Called after the end of a sub-block within the specified block
        protected virtual void ResumeBlock(BlockContext block, BlockContext previousBlock) {
            if (previousBlock.BlockType == BlockType.Template) {
                block.Writer.WriteEndLambdaDelegate();
                block.Writer.WriteEndConstructor();
                block.Writer.WriteEndLambdaExpression();
            }
            block.MarkStartGeneratedCode();
        }

        // Called at the end of the specified block
        protected virtual void EndBlock(BlockContext block) {
            block.MarkEndGeneratedCode();

            switch (block.BlockType) {
                case BlockType.Section:
                    if (InSection) {
                        CurrentBlock.Writer.WriteEndLambdaDelegate();
                        CurrentBlock.Writer.WriteEndMethodInvoke();
                        CurrentBlock.Writer.WriteEndStatement();
                    }
                    InSection = false;
                    break;

                case BlockType.Template:
                    InTemplate = false;
                    break;

                case BlockType.Expression:
                    if (!DesignTimeMode) {
                        block.Writer.WriteEndMethodInvoke();
                    }
                    block.Writer.WriteEndStatement();
                    break;
                case BlockType.Helper:
                    if (!CurrentHelper.TrailerWritten) {
                        WriteHelperTrailer(block);
                    }
                    WriteBlockToHelperContent(block);
                    block.ResetBuffer();

                    // Dump the helper
                    WriteHelper();
                    break;
            }

            if (block.BlockType != BlockType.Template) {
                WriteBlock(CurrentBlock);
            }
        }

        // Called at the start of the specified block
        protected virtual void StartBlock(BlockContext block) {
            switch (block.BlockType) {
                case BlockType.Template:
                    InTemplate = true;
                    break;

                case BlockType.Expression:
                    if (DesignTimeMode) {
                        EnsureExpressionHelperVariable();
                        block.Writer.WriteStartAssignment("__o");
                    }
                    else {
                        block.Writer.WriteStartMethodInvoke(CurrentWriteMethod);
                        if (InNestedWriterBlock) {
                            block.Writer.WriteIdentifier(CurrentWriterName);
                            block.Writer.WriteParameterSeparator();
                        }
                    }
                    break;
                case BlockType.Helper:
                    // Set up the helper context
                    _helperStack.Push(new HelperContext());
                    break;
            }

        }

        protected virtual void WriteHelperTrailer(BlockContext block) {
            WriteHelperTrailer(block, null);
        }

        protected virtual void WriteHelperTrailer(BlockContext block, HelperFooterSpan endSequenceSpan) {
            CurrentHelper.TrailerWritten = true;

            // Write the helper trailer
            if (CurrentHelper.WroteHelperPrefix) {
                block.SourceCodeStart = null;
                block.Writer.WriteEndLambdaDelegate();
                block.Writer.WriteEndConstructor();
                block.Writer.WriteEndStatement();
                WriteBlockToHelperContent(block);
                block.ResetBuffer();
            }

            if (endSequenceSpan != null) {
                block.VisitSpan(endSequenceSpan);
            }

            // If block contains end sequence, write it, otherwise get the code writer to do it
            if (endSequenceSpan != null) {
                block.WriteLinePragma = DesignTimeMode;
                block.MarkStartGeneratedCode();
                block.Writer.WriteSnippet(endSequenceSpan.Content);
                block.MarkEndGeneratedCode();
                block.Writer.InnerWriter.WriteLine();
            }
            else {
                block.Writer.WriteHelperTrailer();
            }
        }

        private void WriteHelper() {
            GeneratedClass.Members.Add(new CodeSnippetTypeMember(CurrentHelper.Content.ToString()));
            _helperStack.Pop();
        }

        private CodeTypeMember CreateTypeMember(BlockContext block) {
            return new CodeSnippetTypeMember(block.Writer.Content) { LinePragma = CreateLinePragma(block) };
        }

        protected virtual CodeSnippetStatement CreateStatement(BlockContext block) {
            string content = block.Writer.Content;
            if (block.SourceCodeStart != null && block.BlockType != BlockType.Markup) {
                content = PadContent(block, content);
            }
            return new CodeSnippetStatement(content) { LinePragma = CreateLinePragma(block) };
        }

        protected virtual CodeLinePragma CreateLinePragma(BlockContext block) {
            if (!block.WriteLinePragma) { return null; }
            if (block.SourceCodeStart != null && block.BlockType != BlockType.Markup) {
                Debug.Assert(block.GeneratedCodeLength != null);
                return CreateLinePragma(block.SourceCodeStart.Value, block.GeneratedCodeStart, block.GeneratedCodeLength.Value);
            }
            return null;
        }

        protected virtual CodeLinePragma CreateLinePragma(SourceLocation sourceLocation, int generatedCodeStart, int generatedCodeLength) {
            if (GenerateLinePragmas) {
                if (DesignTimeMode) {
                    int pragmaId = _nextDesignTimeLinePragma++;
                    AddCodeMapping(pragmaId, sourceLocation, generatedCodeStart, generatedCodeLength);
                    return new CodeLinePragma(SourceFileName, pragmaId);
                }
                else {
                    return new CodeLinePragma(SourceFileName, sourceLocation.LineIndex + 1);
                }
            }
            return null;
        }

        protected virtual void EnsureExpressionHelperVariable() {
            if (!_insertedExpressionVariable) {
                if (DesignTimeMode) {
                    GeneratedClass.Members.Insert(0, new CodeMemberField(typeof(object), "__o") {
                        Attributes = MemberAttributes.Private | MemberAttributes.Static
                    });
                }
                _insertedExpressionVariable = true;
            }
        }

        private string PadContent(BlockContext block, string content) {
            int offset = block.SourceCodeStart.Value.CharacterIndex - block.GeneratedCodeStart;

            if (DesignTimeMode) {
                offset += block.GeneratedColumnOffset;
            }

            if (offset > 0) {
                content = new string(' ', offset) + content;
                block.GeneratedCodeStart += offset;
            }
            return content;
        }

        private void AddCodeMapping(int pragmaId, SourceLocation sourceLocation, int generatedCodeStart, int generatedCodeLength) {
            GeneratedCodeMapping mapping = new GeneratedCodeMapping(
                startLine: sourceLocation.LineIndex + 1,
                startColumn: sourceLocation.CharacterIndex + 1,
                startGeneratedColumn: generatedCodeStart + 1,
                codeLength: generatedCodeLength);

            CodeMappings[pragmaId] = mapping;
        }

        private void WriteBlock(BlockContext block) {
            // Mark the end of generated code if it hasn't been already
            block.MarkEndGeneratedCode();
            // Don't render block if:
            //  * It contains Markup AND it is design-time
            //  * It is a Directive block
            if ((!DesignTimeMode || (block.BlockType != BlockType.Markup)) &&
                block.BlockType != BlockType.Directive) {

                if (block.BlockType == BlockType.Functions) {
                    GeneratedClass.Members.Add(CreateTypeMember(block));
                }
                else if (!InHelper) {
                    GeneratedExecuteMethod.Statements.Add(CreateStatement(block));
                }
                else {
                    WriteBlockToHelperContent(block);
                }
            }
            block.ResetBuffer();
        }

        private void WriteBlockToHelperContent(BlockContext block) {
            Debug.Assert(InHelper);

            // Create a code writer
            CodeWriter writer = CreateCodeWriter();

            // Build the block content
            string content = block.Writer.Content;
            if (block.SourceCodeStart != null && block.BlockType != BlockType.Markup) {
                content = PadContent(block, content);
            }

            // Generate the line pragma
            bool writePragma = false;
            int lineNumber = 0;
            if (block.WriteLinePragma) {
                writePragma = GenerateLinePragmas && block.SourceCodeStart != null && block.BlockType != BlockType.Markup;
                if (writePragma) {
                    lineNumber = block.SourceCodeStart.Value.LineIndex + 1;
                    if (DesignTimeMode) {
                        lineNumber = _nextDesignTimeLinePragma++;
                    }
                    writer.WriteLinePragma(lineNumber, SourceFileName);
                }
            }

            // Write the block content
            writer.WriteSnippet(content);
            if (writePragma) {
                writer.WriteLinePragma(null, SourceFileName);
            }

            // Write this out to the helper content
            CurrentHelper.Content.AppendLine(writer.Content);

            // Configure the design-time pragma
            if (writePragma && DesignTimeMode) {
                Debug.Assert(block.GeneratedCodeLength != null);
                AddCodeMapping(lineNumber, block.SourceCodeStart.Value, block.GeneratedCodeStart, block.GeneratedCodeLength.Value);
            }
        }

        private void EnsureCompileUnitInitialized() {
            if (_generatedCode == null) {
                InitializeCodeCompileUnit();
            }
        }

        private void InitializeCodeCompileUnit() {
            _generatedCode = new CodeCompileUnit();

            _rootNamespace = new CodeNamespace(RootNamespaceName);
            _rootNamespace.Imports.AddRange(Host.NamespaceImports.Select(s => new CodeNamespaceImport(s)).ToArray());
            _generatedCode.Namespaces.Add(_rootNamespace);

            _generatedClass = new CodeTypeDeclaration(ClassName) {
                IsClass = true
            };

            if (!String.IsNullOrEmpty(Host.DefaultBaseClass)) {
                _generatedClass.BaseTypes.Add(new CodeTypeReference(Host.DefaultBaseClass));
            }

            // Dev10 Bug 937438: Generate explicit Parameter-less constructor on Razor generated class
            _generatedClass.Members.Add(new CodeConstructor() { Attributes = MemberAttributes.Public });

            _rootNamespace.Types.Add(_generatedClass);

            _renderMethod = new CodeMemberMethod() {
                Name = Host.GeneratedClassContext.ExecuteMethodName,
                Attributes = MemberAttributes.Override | MemberAttributes.Public
            };

            using (CodeWriter writer = CreateCodeWriter()) {
                writer.WriteHiddenLinePragma();
                if (!String.IsNullOrWhiteSpace(writer.Content)) {
                    _generatedClass.Members.Add(new CodeSnippetTypeMember(writer.Content));
                }
                _generatedClass.Members.Add(_renderMethod);
            }
        }

        protected internal class HelperContext {
            public bool TrailerWritten { get; set; }
            public bool WroteHelperPrefix { get; set; }
            public StringBuilder Content { get; set; }

            public HelperContext() {
                Content = new StringBuilder();
            }
        }

        protected internal class BlockContext {
            public BlockType BlockType { get; private set; }
            public int? GeneratedCodeLength { get; private set; }
            public int GeneratedCodeStart { get; set; }
            public bool HasContent { get; set; }
            public SourceLocation? SourceCodeStart { get; set; }
            public IList<Span> VisitedSpans { get; private set; }
            public CodeWriter Writer { get; private set; }
            public int GeneratedColumnOffset { get; set; }
            public bool WriteLinePragma { get; set; }

            public BlockContext(BlockType type, CodeWriter writer) {
                WriteLinePragma = true;
                BlockType = type;
                Writer = writer;
                VisitedSpans = new List<Span>();
            }

            public void VisitSpan(Span span) {
                VisitedSpans.Add(span);
                if (IsContentSpan(span) && SourceCodeStart == null) {
                    SourceCodeStart = span.Start;
                    MarkStartGeneratedCode();
                }
                else if (span.Kind == SpanKind.Transition) {
                    SourceCodeStart = null;
                }
                HasContent |= IsContentSpan(span);
            }

            public void MarkStartGeneratedCode() {
                GeneratedCodeStart = Writer.Content.Length;
                GeneratedCodeLength = null; // Reset the end point
            }

            public void MarkEndGeneratedCode() {
                if (GeneratedCodeLength == null) {
                    GeneratedCodeLength = Writer.Content.Length - GeneratedCodeStart;
                }
            }

            public void ResetBuffer() {
                Writer.Clear();
                SourceCodeStart = null;
                GeneratedCodeStart = 0;
                GeneratedCodeLength = null;
                GeneratedColumnOffset = 0;
                VisitedSpans.Clear();
                HasContent = false;
            }

            private static bool IsContentSpan(Span span) {
                return span.Kind == SpanKind.Markup || span.Kind == SpanKind.Code;
            }
        }
    }
}
