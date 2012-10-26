using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Sql;

namespace DbShell.Driver.SqlServer
{
    public class SqlServerSqlDumper : SqlDumper
    {
        public SqlServerSqlDumper(ISqlOutputStream stream, IDatabaseFactory factory, SqlFormatProperties props)
            : base(stream, factory, props)
        {
        }
    }
}
