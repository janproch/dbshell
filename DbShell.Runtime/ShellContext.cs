using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Driver.Common.Structure;

namespace DbShell.Runtime
{
    public class ShellContext : IShellContext, IDisposable
    {
        private Dictionary<IConnectionProvider, DatabaseInfo> _dbCache = new Dictionary<IConnectionProvider, DatabaseInfo>();

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

        public void Dispose()
        {
        }
    }
}
