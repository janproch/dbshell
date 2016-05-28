using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Sql;
using DbShell.Driver.Common.Utility;
using DbShell.Driver.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;

namespace DbShell.LocalDb
{
    public abstract class LocalDbItemBase : RunnableBase
    {
        /// <summary>
        /// sync model name
        /// </summary>
        [XamlProperty]
        public string LocalDbFile { get; set; }

        protected string GetLocalDbFile(IShellContext context)
        {
            return context.Replace(LocalDbFile);
        }

        protected SQLiteConnection OpenConnection(IShellContext context)
        {
            var conn = new SQLiteConnection("Synchronous=Full;Data Source=" + GetLocalDbFile(context));
            conn.Open();
            return conn;
        }

        public string GenerateSql(Action<ISqlDumper> dmpFunc)
        {
            var sw = new StringWriter();
            var sqlo = new SqlOutputStream(SqliteDatabaseFactory.Instance.CreateDialect(), sw, new SqlFormatProperties());
            var dmp = SqliteDatabaseFactory.Instance.CreateDumper(sqlo, new SqlFormatProperties());
            dmpFunc(dmp);
            return sw.ToString();
        }
    }
}
