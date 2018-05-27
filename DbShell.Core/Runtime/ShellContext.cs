using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using DbShell.Driver.Common.Interfaces;

namespace DbShell.Core.Runtime
{
    public class ShellContext : IShellContext, IDisposable
    {
        private ShellContext _parent;
        private int _loggedMessageCount;

        // fields shared with root context
        private Dictionary<string, DatabaseInfo> _dbCache;
        // script scope
        private VariableScope _scope;

        // inherited default values
        private string _executingFolder;
        private string _defaultConnection;
        private string _defaultOutputFolder;

        private List<IDisposable> _disposableItems = new List<IDisposable>();
        private ILogger<ShellContext> _logger;

        // search folders
        private Dictionary<ResolveFileMode, List<string>> _additionalSearchFolders = new Dictionary<ResolveFileMode, List<string>>();

        public ShellContext(IServiceProvider serviceProvider, ShellContext parent = null)
        {
            ServiceProvider = serviceProvider;
            _logger = this.GetLogger<ShellContext>();
            if (parent == null)
            {
                _scope = new VariableScope(null);

                _dbCache = new Dictionary<string, DatabaseInfo>();
            }
            else
            {
                _parent = parent;
                _dbCache = _parent._dbCache;
            }
        }

        public DatabaseInfo GetDatabaseStructure(string connectionKey)
        {
            if (!_dbCache.ContainsKey(connectionKey))
            {
                IConnectionProvider connection = ConnectionProvider.FromString(ServiceProvider, connectionKey);
                _logger.LogInformation("DBSH-00076 Downloading structure for connection {connection}", connection);
                this.Info(String.Format("DBSH-00149 Downloading structure for connection {0}", connection));
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

        private VariableScope Scope
        {
            get
            {
                if (_scope != null) return _scope;
                return _parent.Scope;
            }
        }

        public IServiceProvider ServiceProvider { get; private set; }
        private List<IMessageLogger> _additionalLoggers = new List<IMessageLogger>();

        public void Dispose()
        {
            _disposableItems.ForEach(x => x.Dispose());
            _disposableItems.Clear();
        }

        public object Evaluate(string expression)
        {
            return Scope.Evaluate(expression);
        }

        public void CreateScope()
        {
            if (_scope != null) throw new Exception("DBSH-00210 Scope already created");
            _scope = new VariableScope(Scope);
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
            object obj = ShellLoader.LoadFile(file, ServiceProvider);

            var runnable = obj as IRunnable;
            if (runnable == null)
                throw new Exception(String.Format("DBSH-00059 Included file {0} doesn't contain root element implementing IRunnable", file));

            using (var childContext = CreateChildContext())
            {
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
            SetVariable("BASE_DIRECTORY", folder);
        }

        public string GetExecutingFolder()
        {
            if (_executingFolder != null) return _executingFolder;
            if (_parent != null) return _parent.GetExecutingFolder();
            return null;
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
            return new ShellContext(ServiceProvider, this);
        }

        public void AddDisposableItem(IDisposable disposable)
        {
            _disposableItems.Add(disposable);
        }

        public void LogMessage(LogMessageRecord message)
        {
            if (_parent != null)
            {
                _parent.LogMessage(message);
            }
            else
            {
                if (message.Number == null)
                    message.Number = ++_loggedMessageCount;

                message.SendToSystemLogger(_logger);
            }

            foreach (var logger in _additionalLoggers)
            {
                logger.LogMessage(message);
            }
        }

        public void AddLogger(IMessageLogger logger)
        {
            _additionalLoggers.Add(logger);
        }
    }
}
