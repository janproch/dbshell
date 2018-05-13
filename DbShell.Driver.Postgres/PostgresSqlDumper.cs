using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Sql;
using DbShell.Driver.Common.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Driver.Postgres
{
    public class PostgresSqlDumper : SqlDumper
    {
        public PostgresSqlDumper(ISqlOutputStream stream, IDatabaseFactory factory, SqlFormatProperties props)
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

        protected override void DropRecreatedTempTable(string tmptable)
        {
            PutCmd("^drop ^table %i ^cascade", tmptable);
        }

        public override void RenameTable(Common.Structure.TableInfo obj, string newname)
        {
            PutCmd("^alter ^table %f ^rename ^to %i", obj.FullName, newname);
        }

        public override void RenameColumn(ColumnInfo column, string newcol)
        {
            PutCmd("^alter ^table %f ^rename ^column %i ^to %i", column.OwnerTable, column.Name, newcol);
        }

        public override void DropTable(Common.Structure.TableInfo obj, bool testIfExists)
        {
            Put("^drop ^table");
            if (testIfExists) Put(" ^if ^exists");
            Put(" %f", obj.FullName);
            EndCommand();
        }

        //public override void CreateIndex(IndexInfo ix)
        //{
        //}

        public override void EnableConstraints(NameWithSchema table, bool enabled)
        {
            PutCmd("&alter ^table %f %k ^trigger ^all", table, enabled ? "enable" : "disable");
        }

        public override void ColumnDefinition(ColumnInfo col, bool includeDefault, bool includeNullable, bool includeCollate)
        {
            if (col.AutoIncrement)
            {
                Put("^serial");
                return;
            }
            base.ColumnDefinition(col, includeDefault, includeNullable, includeCollate);
        }
    }
}
