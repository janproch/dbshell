using System.Web.Razor.Parser.SyntaxTree;
using System.Threading;

namespace System.Web.Razor.Parser {
    public abstract class ParserVisitor {
        public CancellationToken? CancelToken { get; set; }

        public virtual void VisitStartBlock(BlockType type) {
            ThrowIfCanceled();
        }

        public virtual void VisitSpan(Span span) {
            ThrowIfCanceled();
        }

        public virtual void VisitEndBlock(BlockType type) {
            ThrowIfCanceled();
        }

        public virtual void VisitError(RazorError err) {
            ThrowIfCanceled();
        }

        public virtual void OnComplete() {
            ThrowIfCanceled();
        }

        public virtual void ThrowIfCanceled() {
            if (CancelToken != null && CancelToken.Value.IsCancellationRequested) {
                throw new OperationCanceledException();
            }
        }
    }
}
