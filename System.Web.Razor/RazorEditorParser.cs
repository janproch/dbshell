using System.CodeDom;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Razor.Parser.SyntaxTree;
using System.Web.Razor.Resources;
using System.Web.Razor.Text;
using Microsoft.Internal.Web.Utils;
using System.Linq;

namespace System.Web.Razor {
    /// <summary>
    /// Parser used by editors to avoid reparsing the entire document on each text change
    /// </summary>
    /// <remarks>
    /// This parser is designed to allow editors to avoid having to worry about incremental parsing.
    /// The CheckForStructureChanges method can be called with every change made by a user in an editor and
    /// the parser will provide a result indicating if it was able to incrementally reparse the document.
    /// 
    /// The general workflow for editors with this parser is:
    /// 0. User edits document
    /// 1. Editor builds TextChange structure describing the edit and providing a reference to the _updated_ text buffer
    /// 2. Editor calls CheckForStructureChanges passing in that change.
    /// 3. Parser determines if the change can be simply applied to an existing parse tree node
    ///   a.  If it can, the Parser updates its parse tree and returns PartialParseResult.Accepted
    ///   b.  If it can not, the Parser starts a background parse task and return PartialParseResult.Rejected
    /// NOTE: Additional flags can be applied to the PartialParseResult, see that enum for more details.  However,
    ///       the Accepted or Rejected flags will ALWAYS be present
    /// 
    /// A change can only be incrementally parsed if a single, unique, Span (see System.Web.Razor.Parser.SyntaxTree) in the syntax tree can
    /// be identified as owning the entire change.  For example, if a change overlaps with multiple spans, the change cannot be
    /// parsed incrementally and a full reparse is necessary.  A Span "owns" a change if the change occurs either a) entirely
    /// within it's boundaries or b) it is a pure insertion (see TextChange) at the end of a Span whose CanGrow flag (see Span) is
    /// true.
    /// 
    /// Even if a single unique Span owner can be identified, it's possible the edit will cause the Span to split or merge with other
    /// Spans, in which case, a full reparse is necessary to identify the extent of the changes to the tree.
    /// 
    /// When the RazorEditorParser returns Accepted, it updates CurrentParseTree immediately.  However, the editor is expected to
    /// update it's own data structures independently.  It can use CurrentParseTree to do this, as soon as the editor returns from
    /// CheckForStructureChanges, but it should (ideally) have logic for doing so without needing the new tree.
    /// 
    /// When Rejected is returned by CheckForStructureChanges, a background parse task has _already_ been started.  When that task
    /// finishes, the DocumentStructureChanged event will be fired containing the new generated code, parse tree and a reference to
    /// the original TextChange that caused the reparse, to allow the editor to resolve the new tree against any changes made since 
    /// calling CheckForStructureChanges.
    /// 
    /// If a call to CheckForStructureChanges occurs while a reparse is already in-progress, the reparse is cancelled IMMEDIATELY
    /// and Rejected is returned without attempting to reparse.  This means that if a conusmer calls CheckForStructureChanges, which
    /// returns Rejected, then calls it again before DocumentParseComplete is fired, it will only recieve one DocumentParseComplete
    /// event, for the second change.
    /// </remarks>
    public class RazorEditorParser : IDisposable {
        private RazorEngineHost _host;
        private string _sourceFileName;
        private Block _currentParseTree;
#if DEBUG
        private CodeCompileUnit _currentCodeCompileUnit;
#endif
        private Span _lastChangeOwner;
        private Span _lastAutoCompleteSpan;
        private bool _parseUnderway = false;
        internal bool LastResultProvisional { get; set; }

        /// <summary>
        /// The current parse tree.
        /// </summary>
        public Block CurrentParseTree {
            get {
                return _currentParseTree;
            }
        }

        private SpinLock _syncLock = new SpinLock(enableThreadOwnerTracking: true);
        private BackgroundParserTask _currentTask;

        /// <summary>
        /// Event fired when a full reparse of the document completes
        /// </summary>
        public event EventHandler<DocumentParseCompleteEventArgs> DocumentParseComplete;

        /// <summary>
        /// Constructs the editor parser.  One instance should be used per active editor.  This
        /// instance _can_ be shared among reparses, but should _never_ be shared between documents.
        /// </summary>
        /// <param name="host">The <see cref="RazorEditorHost"/> which defines the environment in which the generated code will live.  <see cref="RazorEditorHost.DesignTimeMode"/> should be set if design-time code mappings are desired</param>
        /// <param name="sourceFileName">The physical path to use in line pragmas</param>
        public RazorEditorParser(RazorEngineHost host, string sourceFileName) {
            if (host == null) { throw new ArgumentNullException("host"); }
            if (String.IsNullOrEmpty(sourceFileName)) { throw new ArgumentException(CommonResources.Argument_Cannot_Be_Null_Or_Empty, "sourceFileName"); }

            _host = host;
            _sourceFileName = sourceFileName;
        }

        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Since this method is heavily affected by side-effects, particularly calls to CheckForStructureChanges, it should not be made into a property")]
        public virtual string GetAutoCompleteString() {
            if (_lastAutoCompleteSpan != null) {
                return _lastAutoCompleteSpan.AutoCompleteString;
            }
            return null;
        }

        /// <summary>
        /// Determines if a change will cause a structural change to the document and if not, applies it to the existing tree.
        /// If a structural change would occur, automatically starts a reparse
        /// </summary>
        /// <remarks>
        /// NOTE: The initial incremental parsing check and actual incremental parsing (if possible) occurs
        /// on the callers thread.  However, if a full reparse is needed, this occurs on a background thread.
        /// </remarks>
        /// <param name="change">The change to apply to the parse tree</param>
        /// <returns>A PartialParseResult value indicating the result of the incremental parse</returns>
        public virtual PartialParseResult CheckForStructureChanges(TextChange change) {
            // Validate the change
            if (change.NewBuffer == null) {
                throw new ArgumentException(String.Format(CultureInfo.CurrentUICulture,
                                                          RazorResources.Structure_Member_CannotBeNull,
                                                          "Buffer",
                                                          "TextChange"), "change");
            }

            // Acquire the sync lock (we need to be fast now, since we're on the UI thread)
            PartialParseResult result = PartialParseResult.Rejected;
            bool lockTaken = false;
            try {
                _syncLock.Enter(ref lockTaken);
                if (lockTaken) {
                    if (!_parseUnderway) {
                        result = TryPartialParse(change);
                    }

                    // Provisional Acceptance means we accept it, but set a flag indicating that we should force
                    // a reparse if the next change is not accepted by the same span that accepted this change.
                    // Rejected or Accepted means we clear the LastResultProvisional flag
                    LastResultProvisional = result.HasFlag(PartialParseResult.Provisional);

                    if (result.HasFlag(PartialParseResult.Rejected)) {
                        _parseUnderway = true;

                        // Queue a reparse to occur on a _background_ thread
                        QueueFullReparse(change);
                    }
#if DEBUG
                    else {
                        if (_currentParseTree != null) {
                            RazorDebugHelpers.WriteDebugTree(_sourceFileName, _currentParseTree, result, change, this, false);
                        }
                        if (_currentCodeCompileUnit != null) {
                            RazorDebugHelpers.WriteGeneratedCode(_sourceFileName, _currentCodeCompileUnit);
                        }
                    }
#endif
                }
            }
            finally {
                if (_syncLock.IsHeldByCurrentThread) {
                    _syncLock.Exit();
                }
            }

            VerifyFlagsAreValid(result);
            return result;
        }

        [Conditional("DEBUG")]
        private static void VerifyFlagsAreValid(PartialParseResult result) {
            Debug.Assert(result.HasFlag(PartialParseResult.Accepted) ||
                         result.HasFlag(PartialParseResult.Rejected),
                         "Partial Parse result does not have either of Accepted or Rejected flags set");
            Debug.Assert(result.HasFlag(PartialParseResult.Rejected) ||
                         !result.HasFlag(PartialParseResult.SpanContextChanged),
                         "Partial Parse result was Accepted AND had SpanContextChanged flag set");
            Debug.Assert(result.HasFlag(PartialParseResult.Rejected) ||
                         !result.HasFlag(PartialParseResult.AutoCompleteBlock),
                         "Partial Parse result was Accepted AND had AutoCompleteBlock flag set");
            Debug.Assert(result.HasFlag(PartialParseResult.Accepted) ||
                         !result.HasFlag(PartialParseResult.Provisional),
                         "Partial Parse result was Rejected AND had Provisional flag set");
        }

        protected internal virtual void QueueFullReparse(TextChange change) {
            if (_currentTask != null) {
                _currentTask.Dispose();
            }
            _currentTask = BackgroundParserTask.CreateAndStart(this, change, _currentParseTree);
        }

        // Try to parse the change incrementally
        // Partial Parsing succeeds if:
        //  * A single span can be identified which owns the change (i.e. it doesn't overlap multiple spans)
        //  * The span which owns the change has logic to accept it
        // The performance of this method is crucial, since it occurs on the caller's thread (usually a UI thread).
        private PartialParseResult TryPartialParse(TextChange change) {
            PartialParseResult result = PartialParseResult.Rejected;
            if (CurrentParseTree != null && !_parseUnderway) {
                // Try the last change owner
                if (_lastChangeOwner != null && _lastChangeOwner.OwnsChange(change)) {
                    result = _lastChangeOwner.ApplyChange(change);
                    
                    // If the last change was provisional, then the result of this span's attempt to parse partially goes
                    // Otherwise, accept the change if this span accepted it, but if it didn't, just do the standard search.
                    if (LastResultProvisional || result.HasFlag(PartialParseResult.Accepted)) {
                        return result;
                    }
                }

                // Locate the span responsible for this change
                _lastChangeOwner = CurrentParseTree.LocateOwner(change);

                if (LastResultProvisional) {
                    // Last change owner couldn't accept this, so we must do a full reparse
                    result = PartialParseResult.Rejected;
                }
                else if (_lastChangeOwner != null) {
                    result = _lastChangeOwner.ApplyChange(change);
                    if (result.HasFlag(PartialParseResult.AutoCompleteBlock)) {
                        _lastAutoCompleteSpan = _lastChangeOwner;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Disposes of this parser.  Should be called when the editor window is closed and the document is unloaded.
        /// </summary>
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        [SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "_cancelTokenSource", Justification = "The cancellation token is owned by the worker thread, so it is disposed there")]
        [SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "_changeReceived", Justification = "The change received event is owned by the worker thread, so it is disposed there")]
        protected virtual void Dispose(bool disposing) {
            if (disposing) {
                if (_currentTask != null && !_currentTask.IsCancelled) {
                    _currentTask.Dispose();
                }
            }
        }

        protected internal virtual void ProcessChange(CancellationToken cancelToken, TextChange change, Block parseTree) {
            try {
                if (!cancelToken.IsCancellationRequested) {
                    GeneratorResults results = null;
                    RazorTemplateEngine engine = new RazorTemplateEngine(_host);

                    // Seek the buffer to the beginning
                    change.NewBuffer.Position = 0;

                    try {
                        results = engine.GenerateCode(change.NewBuffer, className: null, rootNamespace: null, sourceFileName: _sourceFileName, cancelToken: cancelToken);
                    }
                    catch (OperationCanceledException) {
                        // We've been cancelled, so just return.
                        return;
                    }

                    // Parsing complete! Check if we're still active:
                    bool lockTaken = false;
                    _syncLock.Enter(ref lockTaken);
                    if (lockTaken && !cancelToken.IsCancellationRequested) {
                        // We're still active, check for tree changes, then update the parse tree
                        bool treeStructureChanged = parseTree == null || TreesAreDifferent(parseTree, results.Document, change);

                        Interlocked.Exchange(ref _currentParseTree, results.Document);
                        Interlocked.Exchange(ref _lastChangeOwner, null);
#if DEBUG
                        Interlocked.Exchange(ref _currentCodeCompileUnit, results.GeneratedCode);
#endif
                        _parseUnderway = false;

                        // Done, now exit the lock and fire the event
                        _syncLock.Exit();
                        OnDocumentParseComplete(new DocumentParseCompleteEventArgs() {
                            GeneratorResults = results,
                            SourceChange = change,
                            TreeStructureChanged = treeStructureChanged
                        });
                    }
                }
            }
            finally {
                // Make sure we release the lock if we're holding it
                if (_syncLock.IsHeldByCurrentThread) {
                    _syncLock.Exit();
                }
            }
        }

        private static bool TreesAreDifferent(Block leftTree, Block rightTree, TextChange change) {
            Span changeOwner = leftTree.LocateOwner(change);

            // Apply the change to the tree
            if (changeOwner == null) {
                return true;
            }
            changeOwner.ApplyChange(change, force: true);

            // Now compare the trees
            return !Equals(leftTree, rightTree);
        }

        private void OnDocumentParseComplete(DocumentParseCompleteEventArgs args) {
            Debug.Assert(args != null, "Event arguments cannot be null");
            EventHandler<DocumentParseCompleteEventArgs> handler = DocumentParseComplete;
            if (handler != null) {
                handler(this, args);
            }

#if DEBUG
            RazorDebugHelpers.WriteDebugTree(_sourceFileName, args.GeneratorResults.Document, PartialParseResult.Rejected, args.SourceChange, this, args.TreeStructureChanged);
            RazorDebugHelpers.WriteGeneratedCode(_sourceFileName, args.GeneratorResults.GeneratedCode);
#endif
        }

        private class BackgroundParserTask : IDisposable {
            private static int _activeTaskCount = 0;

            public Task Task { get; private set; }
            public CancellationTokenSource CancelSource { get; private set; }
            public bool IsCancelled { get { return CancelSource.IsCancellationRequested; } }

            private BackgroundParserTask() { }

            [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "This catch clause is intended to catch all exceptions")]
            [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Cancellation Source is disposed when the created object is disposed.")]
            public static BackgroundParserTask CreateAndStart(RazorEditorParser parser, TextChange change, Block parseTree) {
                CancellationTokenSource cancelSource = new CancellationTokenSource();
                BackgroundParserTask task = new BackgroundParserTask() {
                    CancelSource = cancelSource
                };
                CancellationToken token = cancelSource.Token;

                task.Task = Task.Factory.StartNew(() => {
                    try {
                        Interlocked.Increment(ref _activeTaskCount);
                        parser.ProcessChange(token, change, parseTree);
                    }
                    catch (OperationCanceledException) {
                    }
#if DEBUG
                    catch (Exception ex) {
                        if (Debugger.IsAttached) {
                            throw;
                        }
                        Debug.Fail("Unexpected exception thrown by parser task", ex.ToString());
                    }
#else
                    catch (Exception) {

                    }
#endif
                }, token);
                return task;
            }

            public void Dispose() {
                CancelSource.Cancel();
                Task.ContinueWith(t => {
                    Interlocked.Decrement(ref _activeTaskCount);

                    CancelSource.Dispose();
                    t.Dispose();
                });
            }
        }
    }
}
