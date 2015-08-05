using System;
using System.IO;
using System.Threading;
using System.Windows.Markup;
using System.Xml;
using DbShell.Common;
using log4net;

namespace DbShell.Core.Runtime
{
    public class ShellRunner : IDisposable
    {
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IRunnable _main;
        private ShellContext _context;
        private Thread _thread;
        public Exception Error { get; private set; }
        public bool FinishedOk { get; private set; }

        public ShellRunner()
        {
            _context = new ShellContext();
            _context.OnOutputMessage += _context_OnOutputMessage;
        }

        void _context_OnOutputMessage(string obj)
        {
            if (OutputMessage != null) OutputMessage(obj);
        }

        public void LoadFile(string file)
        {
            var obj = ShellLoader.LoadFile(file);
            LoadObject(obj, Path.GetDirectoryName(file));
        }

        public void LoadString(string content, string folder = null)
        {
            var obj = ShellLoader.LoadString(content);
            LoadObject(obj, folder);
        }

        public void LoadObject(object obj, string folder = null)
        {
            if (folder != null) _context.SetExecutingFolder(folder);
            _main = (IRunnable) obj;
        }

        public ShellContext Context
        {
            get { return _context; }
        }

        //public static void ProcessLoadedElement(IShellElement element, IShellElement parent, IShellContext context)
        //{
        //    element.Context = context;
        //    if (element.OwnConnection == null && parent != null && parent.OwnConnection != null)
        //    {
        //        element.OwnConnection = parent.OwnConnection;
        //    }
        //    element.EnumChildren(child => ProcessLoadedElement(child, element, context));
        //}

        public void Run()
        {
            _main.Run(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void OnOutputMessage(string message)
        {
            if (OutputMessage != null) OutputMessage(message);
        }

        public event Action<string> OutputMessage;
        public event Action FinishedAsync;

        public void Start()
        {
            _thread = new Thread(RunInThread);
            _thread.IsBackground = true;
            _thread.Start();
        }

        private void RunInThread()
        {
            try
            {
                Run();
                FinishedOk = true;
            }
            catch (Exception err)
            {
                _log.Error("DBSH-00000 Exception occured when executing DbShell", err);
                Error = err;
            }
            finally
            {
                if (FinishedAsync != null)
                {
                    FinishedAsync();
                }
            }
        }

        public void Abort()
        {
            if (_thread == null)
            {
                throw new Exception("DBSH-00096 Calling ShellRunner.Abort without valid thread");
            }
            _thread.Abort();
        }

        public bool IsAsyncFinished
        {
            get { return Error != null || FinishedOk; }
        }
    }
}
