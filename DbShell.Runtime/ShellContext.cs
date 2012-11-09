using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Markup;
using DbShell.Common;
using DbShell.Core;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using log4net;


namespace DbShell.Runtime
{
    public class ShellContext : IShellContext, IDisposable
    {
        private static ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Dictionary<IConnectionProvider, DatabaseInfo> _dbCache = new Dictionary<IConnectionProvider, DatabaseInfo>();
        private ScriptEngine _engine;
        private List<ScriptScope> _scopeStack = new List<ScriptScope>();

        public ShellContext()
        {
            _engine = Python.CreateEngine();
            _scopeStack.Add(_engine.CreateScope());
        }

        public DbShell.Driver.Common.Structure.DatabaseInfo GetDatabaseStructure(IConnectionProvider connection)
        {
            if (!_dbCache.ContainsKey(connection))
            {
                _log.InfoFormat("Downloading structure for connection {0}", connection);
                var analyser = connection.Factory.CreateAnalyser();
                using (var conn = connection.Connect())
                {
                    analyser.Run(conn, conn.Database);
                    _dbCache[connection] = analyser.Result;
                }
            }
            return _dbCache[connection];
        }

        private ScriptScope Scope
        {
            get { return _scopeStack.Last(); }
        }

        public void Dispose()
        {
        }

        public object Evaluate(string expression)
        {
            return _engine.Execute(expression, Scope);
        }


        public void SetVariable(string name, object value)
        {
            Scope.SetVariable(name, value);
        }

        public void EnterScope()
        {
            _scopeStack.Add(_engine.CreateScope(Scope));
        }

        public void LeaveScope()
        {
            _scopeStack.RemoveAt(_scopeStack.Count - 1);
        }

        private string ReplaceMatch(Match m)
        {
            return Evaluate(m.Groups[1].Value).SafeToString();
        }

        public string Replace(string replaceString)
        {
            if (replaceString == null) return null;
            return Regex.Replace(replaceString, @"\$\{([^\}]+)\}", ReplaceMatch);
        }

        public void IncludeFile(string file, IShellElement parent)
        {
            using (var fr = new FileInfo(file).OpenRead())
            {
                object obj = XamlReader.Load(fr);
                var runnable = obj as IRunnable;
                if (runnable == null) throw new Exception(String.Format("DBSH-00000 Included file {0} doesn't contain root element implementing IRunnable", file));
                var shellElem = obj as IShellElement;
                if (shellElem != null) ShellRunner.ProcessLoadedElement(shellElem, parent, this);
                runnable.Run();
            }
        }
    }
}
