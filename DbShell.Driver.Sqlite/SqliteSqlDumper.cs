using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Sql;

namespace DbShell.Driver.Sqlite
{
    public class SqliteSqlDumper : SqlDumper
    {
        public SqliteSqlDumper(ISqlOutputStream stream, IDatabaseFactory factory, SqlFormatProperties props)
            : base(stream, factory, props)
        {
        }

        public override void ExtractMonth(Action<ISqlDumper> argument)
        {
            Put("cast(strftime('%%m', ");
            argument(this);
            Put(") as int)");
        }

        public override void ExtractDayOfMonth(Action<ISqlDumper> argument)
        {
            Put("cast(strftime('%%d', ");
            argument(this);
            Put(") as int)");
        }

        public override void ExtractDayOfWeek(Action<ISqlDumper> argument)
        {
            Put("cast(strftime('%%w', ");
            argument(this);
            Put(") as int)");
        }

        public override void ColumnDefinition(Common.Structure.ColumnInfo col, bool includeDefault, bool includeNullable, bool includeCollate)
        {
        }
    }
}
