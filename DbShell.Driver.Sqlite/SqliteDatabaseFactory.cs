using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;

namespace DbShell.Driver.Sqlite
{
    public class SqliteDatabaseFactory : DatabaseFactoryBase
    {
        public static readonly SqliteDatabaseFactory Instance = new SqliteDatabaseFactory();

        public override string[] Identifiers
        {
            get { return new string[] {"sqlite"}; }
        }

        public override DbConnection CreateConnection(string connectionString)
        {
            return new SQLiteConnection(connectionString);
        }

        public override Type[] ConnectionTypes
        {
            get { return new Type[] {typeof (SQLiteConnection)}; }
        }
    }
}
