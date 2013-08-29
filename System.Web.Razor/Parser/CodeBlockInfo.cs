using System.Web.Razor.Parser.SyntaxTree;
using System.Web.Razor.Text;

namespace System.Web.Razor.Parser {
    public class CodeBlockInfo {
        public string Name { get; set; }
        public SourceLocation Start { get; set; }
        public Span TransitionSpan { get; set; }
        public Span InitialSpan { get; set; }
        public bool IsTopLevel { get; set; }
        public BlockType BlockType { get; set; }

        public CodeBlockInfo(string name, SourceLocation start, bool isTopLevel)
            : this(name, start, isTopLevel, null, null) {
        }

        public CodeBlockInfo(string name, SourceLocation start, bool isTopLevel, Span transitionSpan, Span initialSpan) {
            Name = name;
            Start = start;
            IsTopLevel = isTopLevel;
            TransitionSpan = transitionSpan;
            InitialSpan = initialSpan;
        }

        public void ResumeSpans(ParserContext context) {
            if (TransitionSpan != null) {
                context.OutputSpan(TransitionSpan);
            }
            if (InitialSpan != null) {
                context.ResumeSpan(InitialSpan);
            }
        }
    }
}
