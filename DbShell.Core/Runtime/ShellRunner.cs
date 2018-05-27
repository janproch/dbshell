using System;
using System.IO;
using System.Threading;
using DbShell.Driver.Common.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace DbShell.Core.Runtime
{
    public class ShellRunner : IDisposable
    {
        private IRunnable _main;
        private ShellContext _context;
        private Thread _thread;
        public Exception Error { get; private set; }
        public bool FinishedOk { get; private set; }
        public IServiceProvider ServiceProvider { get; set; }

        public ShellRunner(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            _context = new ShellContext(serviceProvider);
        }


        public void LoadFile(string file)
        {
            var obj = ShellLoader.LoadFile(file, ServiceProvider);
            LoadObject(obj, Path.GetDirectoryName(file));
        }

        public void LoadString(string content, string folder = null)
        {
            var obj = ShellLoader.LoadString(content, ServiceProvider);
            LoadObject(obj, folder);
        }

        public void LoadObject(object obj, string folder = null)
        {
            if (obj == null)
                throw new Exception("DBSH-00000 Error loading script");

            if (folder != null)
                _context.SetExecutingFolder(folder);

            _main = obj as IRunnable;

            if (_main == null)
                throw new Exception("DBSH-00000 Loaded object doesn't implement IRunnable");
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
                _context.GetLogger<ShellRunner>().LogError(0, err, "DBSH-00198 Exception occured when executing DbShell");
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

#if !NETSTANDARD2_0
        public void Abort()
        {
            if (_thread == null)
            {
                throw new Exception("DBSH-00096 Calling ShellRunner.Abort without valid thread");
            }
            _thread.Abort();
        }
#endif

        public bool IsAsyncFinished
        {
            get { return Error != null || FinishedOk; }
        }
    }
}
