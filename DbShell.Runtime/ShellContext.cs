using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DbShell.Common;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;


namespace DbShell.Runtime
{
    public class ShellContext : IShellContext, IDisposable
    {
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
    }
}
