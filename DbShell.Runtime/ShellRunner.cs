using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Markup;
using System.Xml;
using DbShell.Common;
using DbShell.Core;

namespace DbShell.Runtime
{
    public class ShellRunner : IDisposable
    {
        private IRunnable _main;
        private ShellContext _context;
        private string _rootFolder;
        public IConnectionProvider DefaultConnection;
        private Thread _thread;
        public Exception Error { get; private set; }
        public bool FinishedOk { get; private set; }

        public void LoadFile(string file)
        {
            CoreLoader.Load();
            using (var fr = new FileInfo(file).OpenRead())
            {
                object obj = XamlReader.Load(fr);
                LoadObject(obj, Path.GetDirectoryName(file));
            }
        }

        public void LoadString(string content, string folder = null)
        {
            using (var fr = new StringReader(content))
            {
                using (var reader = XmlReader.Create(fr))
                {
                    object obj = XamlReader.Load(reader);
                    LoadObject(obj, folder);
                }
            }
        }

        public void LoadObject(object obj, string folder = null)
        {
            _rootFolder = folder;
            if (_context != null) throw new Exception("Load function already called");
            _main = (IRunnable)obj;
            _context = new ShellContext(this);
            var element = _main as IShellElement;
            if (element != null) ProcessLoadedElement(element, null, _context, DefaultConnection);
        }

        public ShellContext Context
        {
            get { return _context; }
        }

        public static void ProcessLoadedElement(IShellElement element, IShellElement parent, IShellContext context, IConnectionProvider defaultConnection)
        {
            element.Context = context;
            if (element.Connection == null && parent != null && parent.Connection != null)
            {
                element.Connection = parent.Connection;
            }
            if (element.Connection == null && defaultConnection != null)
            {
                element.Connection = defaultConnection;
            }
            element.EnumChildren(child => ProcessLoadedElement(child, element, context, defaultConnection));
        }

        public void Run()
        {
            if (_context == null) throw new Exception("Load function not called");
            if (_rootFolder != null) _context.PushExecutingFolder(_rootFolder);
            _main.Run();
            if (_rootFolder != null) _context.PopExecutingFolder();
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
            _thread = new Thread(RunFromThread);
            _thread.Start();
        }

        private void RunFromThread()
        {
            try
            {
                Run();
                FinishedOk = true;
            }
            catch (Exception err)
            {
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
                throw new Exception("DBSH-00000 Calling ShellRunner.Abort without valid thread");
            }
            _thread.Abort();
        }

        public bool IsAsyncFinished
        {
            get { return Error != null || FinishedOk; }
        }

        //public void WaitForFinish()
        //{
        //    if (_thread == null)
        //    {
        //        throw new Exception("DBSH-00000 Calling ShellRunner.WaitToFinish without valid thread");
        //    }
        //    _thread.Join();
        //}
    }
}
