using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.DbDiff;

namespace DbShell.Driver.SqlServer
{
    public class SqlServerDialect : DialectBase
    {
        public SqlServerDialect()
            : base(SqlServerDatabaseFactory.Instance)
        {
        }

        public override char QuoteIdentBegin
        {
            get { return '['; }
        }

        public override char QuoteIdentEnd
        {
            get { return ']'; }
        }

        public override char StringEscapeChar
        {
            get { return '\''; }
        }

        public override Type SpecificTypeEnum
        {
            get { return typeof(SqlTypeCode); }
        }

        public override Common.CommonTypeSystem.DbTypeBase CreateCommonType(Common.Structure.ColumnInfo column)
        {
            return SqlServerDatabaseAnalyser.AnalyseType(column.DataType, column.Length, column.Precision, column.Scale);
        }

        //    public override string QuoteIdentifier(string ident)
        //    {
        //        if (ident != null && ident.StartsWith("#")) return ident;
        //        return base.QuoteIdentifier(ident);
        //    }
    }
}
