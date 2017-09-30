using DbShell.Driver.Common.AbstractDb;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Driver.MySql
{
    public class MySqlDialect : DialectBase
    {
        public MySqlDialect(IDatabaseFactory factory) : base(factory)
        {
        }

        public override char QuoteIdentBegin
        {
            get { return '`'; }
        }

        public override char QuoteIdentEnd
        {
            get { return '`'; }
        }

        public override char StringEscapeChar
        {
            get { return '\''; }
        }

        public override Common.CommonTypeSystem.DbTypeBase CreateCommonType(Common.Structure.ColumnInfo column)
        {
            return MySqlDatabaseAnalyser.AnalyseType(column.DataType, column.Length, column.Precision, column.Scale);
        }
    }
}
