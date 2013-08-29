using System.Collections.Generic;
using System.Diagnostics;

namespace System.Web.Razor.Parser.SyntaxTree {
    public class SyntaxTreeBuilderVisitor : ParserVisitor {
        private Block _rootBlock = null;
        private Stack<List<SyntaxTreeNode>> _blockStack = new Stack<List<SyntaxTreeNode>>();
        private IList<RazorError> _errorList = null;

        private Span _previous = null;

        public ParserResults Results { get; set; }

        private List<SyntaxTreeNode> CurrentBlock {
            get { return _blockStack.Peek(); }
        }

        public override void VisitStartBlock(BlockType type) {
            base.VisitStartBlock(type);
            _blockStack.Push(new List<SyntaxTreeNode>());
        }

        public override void VisitSpan(Span span) {
            base.VisitSpan(span);
            // Build linked list
            if (_previous != null) {
                _previous.Next = span;
                span.Previous = _previous;
            }
            _previous = span;

            CurrentBlock.Add(span);
        }

        public override void VisitEndBlock(BlockType type) {
            base.VisitEndBlock(type);
            List<SyntaxTreeNode> elems = _blockStack.Pop();
            Block block = new Block(type, elems);
            if (_blockStack.Count == 0) {
                _rootBlock = block;
            }
            else {
                CurrentBlock.Add(block);
            }
        }

        public override void VisitError(RazorError err) {
            base.VisitError(err);
            if (_errorList == null) {
                _errorList = new List<RazorError>();
            }
            _errorList.Add(err);
        }

        public override void OnComplete() {
            base.OnComplete();
            Results = new ParserResults(_rootBlock, _errorList);
        }
    }
}