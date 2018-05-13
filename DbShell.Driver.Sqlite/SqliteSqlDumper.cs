using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Sql;
using DbShell.Driver.Common.Structure;

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

        public override void RenameTable(Common.Structure.TableInfo obj, string newname)
        {
            PutCmd("^alter ^table %f ^rename ^to %i", obj.FullName, newname);
        }

        //public override void ColumnDefinition(Common.Structure.ColumnInfo col, bool includeDefault, bool includeNullable, bool includeCollate)
        //{
        //    if (col.AutoIncrement)
        //    {
        //        Put("^integer ^primary ^key ^not ^null ^autoincrement");
        //    }
        //    else
        //    {
        //        Put("%k", col.DataType);
        //    }
        //}

        public override void ColumnDefinition(ColumnInfo col, bool includeDefault, bool includeNullable, bool includeCollate)
        {
            if (col.AutoIncrement && col.CommonType is DbTypeInt)
            {
                Put("^integer ^primary ^key ^autoincrement ^not ^null");
                _primaryKeyWrittenInCreateTable = true;
                return;
            }
            base.ColumnDefinition(col, includeDefault, includeNullable, includeCollate);
        }

        protected override void IdentityDefinition()
        {
        }

        public override void DropTable(Common.Structure.TableInfo obj, bool testIfExists)
        {
            Put("^drop ^table");
            if (testIfExists) Put(" ^if ^exists");
            Put(" %f", obj.FullName);
            EndCommand();
        }

        public override void CreateIndex(IndexInfo ix)
        {
        }

        public override void EnableConstraints(NameWithSchema table, bool enabled)
        {
            PutCmd("^pragma foreign_keys = %k", enabled ? "on" : "off");
        }
    }
}
