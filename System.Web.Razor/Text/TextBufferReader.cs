using System.Collections.Generic;
using System.Web.Razor.Resources;
using System.Web.Razor.Utils;

namespace System.Web.Razor.Text {
    public class TextBufferReader : LookaheadTextReader {
        // Need a class for reference equality to support cancelling backtrack.
        private class BacktrackContext {
            public SourceLocation Location { get; set; }
        }

        private Stack<BacktrackContext> _bookmarks = new Stack<BacktrackContext>();
        private SourceLocationTracker _tracker = new SourceLocationTracker();

        internal ITextBuffer InnerBuffer { get; private set; }
        
        public TextBufferReader(ITextBuffer buffer) {
            if (buffer == null) { throw new ArgumentNullException("buffer"); }

            InnerBuffer = buffer;
        }

        public override int Peek() {
            return InnerBuffer.Peek();
        }

        public override int Read() {
            int read = InnerBuffer.Read();
            if (read != -1) {
                _tracker.UpdateLocation((char)read, () => {
                    int i = Peek();
                    if (i == -1) {
                        return '\0';
                    }
                    else {
                        return (char)i;
                    }
                });
            }
            return read;
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                IDisposable disposable = InnerBuffer as IDisposable;
                if (disposable != null) {
                    disposable.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        public override SourceLocation CurrentLocation {
            get { return _tracker.CurrentLocation; }
        }

        public override IDisposable BeginLookahead() {
            BacktrackContext context = new BacktrackContext() { Location = CurrentLocation };
            _bookmarks.Push(context);
            return new DisposableAction(() => {
                EndLookahead(context);
            });
        }

        public override void CancelBacktrack() {
            if(_bookmarks.Count == 0) {
                throw new InvalidOperationException(RazorResources.DoNotBacktrack_Must_Be_Called_Within_Lookahead);
            }
            _bookmarks.Pop();
        }

        private void EndLookahead(BacktrackContext context) {
            if(_bookmarks.Count > 0 && Object.ReferenceEquals(_bookmarks.Peek(), context)) {
                // Backtrack wasn't cancelled, so pop it
                _bookmarks.Pop();

                // Set the new current location
                _tracker.CurrentLocation = context.Location;
                InnerBuffer.Position = context.Location.AbsoluteIndex;
            }
        }
    }
}
