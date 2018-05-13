using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.DbDiff;
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
            PutCmd("^alter ^table %f %k ^trigger ^all", table, enabled ? "enable" : "disable");
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


        public override void ChangeColumn(ColumnInfo oldcol, ColumnInfo newcol, IEnumerable<ConstraintInfo> constraints)
        {
            if (oldcol.Name != newcol.Name)
            {
                PutCmd("^alter ^table %f ^rename ^column %i ^to %i", oldcol.OwnerTable, oldcol.Name, newcol.Name);
            }
            if (!DbDiffTool.EqualTypes(oldcol, newcol, new DbDiffOptions()))
            {
                PutCmd("^alter ^table %f ^alter ^column %i ^type %s", newcol.OwnerTable, newcol.Name, newcol.DataType);
            }
            if (oldcol.NotNull != newcol.NotNull)
            {
                if (newcol.NotNull) PutCmd("^alter ^table %f ^alter ^column %i ^set ^not ^null", newcol.OwnerTable, newcol.Name); 
                else PutCmd("^alter ^table %f ^alter ^column %i ^drop ^not ^null", newcol.OwnerTable, newcol.Name);
            }
            if (oldcol.DefaultValue  != newcol.DefaultValue)
            {
                if (newcol.DefaultValue == null) PutCmd("^alter ^table %f ^alter ^column %i ^drop ^default", newcol.OwnerTable, newcol.Name);
                else PutCmd("^alter ^table %f ^alter ^column %i ^set ^default %s", newcol.OwnerTable, newcol.Name, newcol.DefaultValue);
            }
            this.CreateConstraints(constraints);
        }
    }
}
