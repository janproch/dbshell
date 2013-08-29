using System.Collections.Generic;
using System.Linq;
using System.Web.Razor.Parser.SyntaxTree;

namespace System.Web.Razor.Parser {
    internal class VisitorPair : ParserVisitor {
        public ParserVisitor Visitor1 { get; private set; }
        public ParserVisitor Visitor2 { get; private set; }

        public VisitorPair(ParserVisitor visitor1, ParserVisitor visitor2) {
            Visitor1 = visitor1;
            Visitor2 = visitor2;
        }

        public override void VisitStartBlock(BlockType type) {
            Visitor1.VisitStartBlock(type);
            Visitor2.VisitStartBlock(type);
        }

        public override void VisitSpan(Span span) {
            Visitor1.VisitSpan(span);
            Visitor2.VisitSpan(span);
        }

        public override void VisitEndBlock(BlockType type) {
            Visitor1.VisitEndBlock(type);
            Visitor2.VisitEndBlock(type);
        }

        public override void VisitError(RazorError err) {
            Visitor1.VisitError(err);
            Visitor2.VisitError(err);
        }

        public override void OnComplete() {
            Visitor1.OnComplete();
            Visitor2.OnComplete();
        }
    }
}