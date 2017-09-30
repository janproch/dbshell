using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.SqlServer;
using DbShell.Driver.Sqlite;
using DbShell.Driver.MySql;

namespace DbShell.Core
{
    public static class CoreLoader
    {
        private static bool _loaded;

        /// <summary>
        /// initializes core
        /// </summary>
        public static void Load()
        {
            if (_loaded) return;
            SqlServerDatabaseFactory.Initialize();
            SqliteDatabaseFactory.Initialize();
            MySqlDatabaseFactory.Initialize();
            _loaded = true;
        }
    }
}
