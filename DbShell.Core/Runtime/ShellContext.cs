using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Markup;
using DbShell.Common;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using log4net;

namespace DbShell.Core.Runtime
{
    public class ShellContext : IShellContext, IDisposable
    {
        private ShellContext _parent;
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // fields shared with root context
        private Dictionary<string, DatabaseInfo> _dbCache;
        private readonly ScriptEngine _engine;

        // script scope
        private ScriptScope _scope;

        // inherited default values
        private string _executingFolder;
        private string _defaultConnection;
        private string _defaultOutputFolder;

        // search folders
        private Dictionary<ResolveFileMode, List<string>> _additionalSearchFolders = new Dictionary<ResolveFileMode, List<string>>();

        public ShellContext(ShellContext parent = null)
        {
            if (parent==null)
            {
                _engine = Python.CreateEngine();
                _scope = _engine.CreateScope();

                _dbCache = new Dictionary<string, DatabaseInfo>();
            }
            else
            {
                _parent = parent;

                _engine = _parent._engine;
                _dbCache = _parent._dbCache;
            }
        }

        public DatabaseInfo GetDatabaseStructure(string connectionKey)
        {
            if (!_dbCache.ContainsKey(connectionKey))
            {
                IConnectionProvider connection = ConnectionProvider.FromString(connectionKey);
                _log.InfoFormat("DBSH-00076 Downloading structure for connection {0}", connection);
                OutputMessage(String.Format("DBSH-00000 Downloading structure for connection {0}", connection));
                var analyser = connection.Factory.CreateAnalyser();
                using (var conn = connection.Connect())
                {
                    analyser.Connection = conn;
                    analyser.FullAnalysis();
                    _dbCache[connectionKey] = analyser.Structure;
                }
            }
            return _dbCache[connectionKey];
        }

        public void PutDatabaseInfoCache(string providerKey, DatabaseInfo db)
        {
            _dbCache[providerKey] = db;
        }

        public void SetDefaultOutputFolder(string value)
        {
            _defaultOutputFolder = value;
        }

        public string GetDefaultOutputFolder()
        {
            if (_defaultOutputFolder != null) return _defaultOutputFolder;
            if (_parent != null) return _parent.GetDefaultOutputFolder();
            return null;
        }

        private ScriptScope Scope
        {
            get
            {
                if (_scope != null) return _scope;
                return _parent.Scope;
            }
        }

        public void Dispose()
        {
        }

        public object Evaluate(string expression)
        {
            return _engine.Execute(expression, Scope);
        }

        public void CreateScope()
        {
            if (_scope != null) throw new Exception("DBSH-0000 Scope already created");
            _scope = _engine.CreateScope(Scope);
        }

        public object GetVariable(string name)
        {
            return Scope.GetVariable(name);
        }

        public void SetVariable(string name, object value)
        {
            Scope.SetVariable(name, value);
        }

        private string ReplaceMatch(Match m)
        {
            return Evaluate(m.Groups[1].Value).SafeToString();
        }

        public string Replace(string replaceString, string replacePattern = null)
        {
            if (replaceString == null) return null;
            return Regex.Replace(replaceString, replacePattern ?? @"\$\{([^\}]+)\}", ReplaceMatch);
        }

        public void IncludeFile(string file)
        {
            using (var fr = new FileInfo(file).OpenRead())
            {
                object obj = XamlReader.Load(fr);
                var runnable = obj as IRunnable;
                if (runnable == null) throw new Exception(String.Format("DBSH-00059 Included file {0} doesn't contain root element implementing IRunnable", file));
                //var shellElem = obj as IShellElement;
                //if (shellElem != null) ShellRunner.ProcessLoadedElement(shellElem, parent, this);
                var childContext = CreateChildContext();
                childContext.SetExecutingFolder(Path.GetDirectoryName(file));
                SetExecutingFolder(Path.GetDirectoryName(file));
                runnable.Run(childContext);
            }
        }

        private string SearchExistingFile(string file, ResolveFileMode mode, params string[] folders)
        {
            foreach (string folder in folders)
            {
                if (folder == null) continue;
                string fn = Path.Combine(folder, file);
                if (System.IO.File.Exists(fn)) return fn;
            }
            var additionalFoldersCtx = this;
            while (additionalFoldersCtx != null)
            {
                if (additionalFoldersCtx._additionalSearchFolders.ContainsKey(mode))
                {
                    foreach (string folder in additionalFoldersCtx._additionalSearchFolders[mode])
                    {
                        string fn = Path.Combine(folder, file);
                        if (System.IO.File.Exists(fn)) return fn;
                    }
                }
                additionalFoldersCtx = additionalFoldersCtx._parent;
            }
            if (System.IO.File.Exists(file)) return file;

            var allFolders = new List<string>(folders);
            if (_additionalSearchFolders.ContainsKey(mode))
            {
                allFolders.AddRange(_additionalSearchFolders[mode]);
            }
            throw new Exception(String.Format("DBSH-00063 Could not find file {0}, searched in folders {1}", file, allFolders.CreateDelimitedText(";")));
        }

        public string ResolveFile(string file, ResolveFileMode mode)
        {
            switch (mode)
            {
                case ResolveFileMode.DbShell:
                    return SearchExistingFile(file, mode, GetExecutingFolder());
                case ResolveFileMode.Template:
                    return SearchExistingFile(file, mode, GetTemplatesFolder(), GetExecutingFolder());
                case ResolveFileMode.Input:
                    return SearchExistingFile(file, mode, GetExecutingFolder());
                case ResolveFileMode.Output:
                    var outputFolder = GetDefaultOutputFolder();
                    if (outputFolder != null) return Path.Combine(outputFolder, file);
                    return file;
            }
            return file;
        }

        private string GetDbShellFolder()
        {
            var asm = System.Reflection.Assembly.GetEntryAssembly();
            if (asm == null) return null;
            string file = asm.Location;
            return Path.GetDirectoryName(Path.GetDirectoryName(file));
        }

        private string GetTemplatesFolder()
        {
            string folder = GetDbShellFolder();
            if (folder == null) return null;
            return Path.Combine(folder, "Templates");
        }

        //private string GetExecutingFolder()
        //{
        //    string file = GetExecutingFile();
        //    if (file != null) return Path.GetDirectoryName(file);
        //    return null;
        //}

        public void SetExecutingFolder(string folder)
        {
            _executingFolder = folder;
        }

        public string GetExecutingFolder()
        {
            if (_executingFolder != null) return _executingFolder;
            if (_parent != null) return _parent.GetExecutingFolder();
            return null;
        }

        public event Action<string> OnOutputMessage;

        public void OutputMessage(string message)
        {
            if (OnOutputMessage != null) OnOutputMessage(message);
        }

        public void AddSearchFolder(ResolveFileMode mode, string folder)
        {
            if (!_additionalSearchFolders.ContainsKey(mode))
            {
                _additionalSearchFolders[mode] = new List<string>();
            }
            _additionalSearchFolders[mode].Add(folder);
        }

        public void SetDefaultConnection(string connection)
        {
            _defaultConnection = connection;
        }

        public string GetDefaultConnection()
        {
            if (_defaultConnection != null) return _defaultConnection;
            if (_parent != null) return _parent.GetDefaultConnection();
            return null;
        }


        //public IConnectionProvider DefaultConnection { get; set; }
        //public string DefaultOutputFolder { get; set; }

        public IShellContext CreateChildContext()
        {
            return new ShellContext(this);
        }
    }
}
