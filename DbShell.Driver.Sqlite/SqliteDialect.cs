using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;

namespace DbShell.Driver.Sqlite
{
    public class SqliteDialect : DialectBase
    {
        public SqliteDialect(SqliteDatabaseFactory factory)
            : base(factory)
        {
        }

        public override char QuoteIdentBegin
        {
            get { return '"'; }
        }

        public override char QuoteIdentEnd
        {
            get { return '"'; }
        }

        public override char StringEscapeChar
        {
            get { return '\''; }
        }
    }
}
