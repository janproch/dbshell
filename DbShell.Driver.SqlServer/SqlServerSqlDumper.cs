using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.DbDiff;
using DbShell.Driver.Common.Sql;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.SqlServer
{
    public class SqlServerSqlDumper : SqlDumper
    {
        public SqlServerSqlDumper(ISqlOutputStream stream, IDatabaseFactory factory, SqlFormatProperties props)
            : base(stream, factory, props)
        {
        }

        public override void AllowIdentityInsert(NameWithSchema table, bool allow)
        {
            PutCmd("^set ^identity_insert %f %k;&n", table, allow ? "on" : "off");
        }

        private void RenameObject(NamedObjectInfo obj, string newname)
        {
            PutCmd("^execute sp_rename '%f', '%s', 'OBJECT'", obj.FullName, newname);
        }

        private void ChangeObjectSchema(NamedObjectInfo obj, string newschema)
        {
            PutCmd("^execute sp_changeobjectowner '%f', '%s'", obj.FullName, newschema);
        }

        public override void RenameView(ViewInfo obj, string newname)
        {
            RenameObject(obj, newname);
        }

        public override void ChangeViewSchema(ViewInfo obj, string newschema)
        {
            ChangeObjectSchema(obj, newschema);
        }

        public override void RenameFunction(FunctionInfo obj, string newname)
        {
            RenameObject(obj, newname);
        }

        public override void ChangeFunctionSchema(FunctionInfo obj, string newschema)
        {
            ChangeObjectSchema(obj, newschema);
        }

        public override void RenameStoredProcedure(StoredProcedureInfo obj, string newname)
        {
            RenameObject(obj, newname);
        }

        public override void ChangeStoredProcedureSchema(StoredProcedureInfo obj, string newschema)
        {
            ChangeObjectSchema(obj, newschema);
        }

        public override void RenameTrigger(TriggerInfo obj, string newname)
        {
            RenameObject(obj, newname);
        }

        public override void ChangeTriggerSchema(TriggerInfo obj, string newschema)
        {
            ChangeObjectSchema(obj, newschema);
        }


        public override void DropTable(TableInfo obj, bool testIfExists)
        {
            if (testIfExists)
            {
                Put("IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'%f') AND type in (N'U'))&n", obj.FullName);
            }
            base.DropTable(obj, testIfExists);
        }

        public override void RenameTable(TableInfo obj, string newname)
        {
            RenameObject(obj, newname);
        }

        public override void ChangeTableSchema(TableInfo obj, string schema)
        {
            ChangeObjectSchema(obj, schema);
        }

        private void DropDefault(ColumnInfo col)
        {
            if (!String.IsNullOrEmpty(col.DefaultConstraint)) PutCmd("^alter ^table %f ^drop ^constraint %i", col.OwnerTable.FullName, col.DefaultConstraint);
        }

        private string GuessDefaultName(ColumnInfo col)
        {
            string defname = col.DefaultConstraint;
            if (defname == null)
            {
                defname = String.Format("DF_{0}_{1}_{2}", col.OwnerTable.FullName.Schema ?? "dbo", col.OwnerTable.FullName.Name, col.Name);
            }
            return defname;
        }

        private void CreateDefault(ColumnInfo col)
        {
            if (col.DefaultValue == null) return;
            string defsql = col.DefaultValue;
            if (defsql != null)
            {
                var defname = GuessDefaultName(col);
                PutCmd("^alter ^table %f ^add ^constraint %i ^default %s for %i", col.OwnerTable.FullName, defname, defsql, col.Name);
            }
        }

        public override void RenameColumn(ColumnInfo column, string newcol)
        {
            PutCmd("^execute sp_rename '%f.%i', '%s', 'COLUMN'", column.OwnerTable.FullName, column.Name, newcol);
        }

        public override void ChangeColumn(ColumnInfo oldcol, ColumnInfo newcol, IEnumerable<ConstraintInfo> constraints)
        {
            if (DbDiffTool.EqualsColumns(oldcol, newcol, false, false))
            {
                DropDefault(oldcol);
                if (oldcol.Name != newcol.Name) RenameColumn(oldcol, newcol.Name);
                CreateDefault(newcol);
            }
            else
            {
                DropDefault(oldcol);
                if (oldcol.Name != newcol.Name) RenameColumn(oldcol, newcol.Name);
                Put("^alter ^table %f ^alter ^column %i ", newcol.OwnerTable.FullName, newcol.Name);
                // remove autoincrement flag
                var newcol2 = newcol.CloneColumn();
                newcol2.SetDummyTable(newcol.OwnerTable.FullName);
                newcol2.AutoIncrement = false;
                ColumnDefinition(newcol2, false, true, true);
                EndCommand();
                CreateDefault(newcol);
                this.CreateConstraints(constraints);
            }
        }

        protected override void IdentityDefinition()
        {
            Put(" ^identity");
        }

        public override void RenameConstraint(ConstraintInfo cnt, string newname)
        {
            if (cnt.ObjectType == DatabaseObjectType.Index) PutCmd("^execute sp_rename '%f.%i', '%s', 'INDEX'", cnt.OwnerTable.FullName, cnt.ConstraintName, newname);
            else PutCmd("^execute sp_rename '%f', '%s', 'OBJECT'", new NameWithSchema(cnt.OwnerTable.FullName.Schema, cnt.ConstraintName), newname);
        }

        public override void CreateIndex(IndexInfo ix)
        {
            Put("^create");
            switch (ix.IndexType)
            {
                case DbIndexType.Fulltext:
                    Put(" ^fulltext");
                    break;
                case DbIndexType.Xml:
                    Put(" ^xml");
                    break;
                case DbIndexType.Spatial:
                    Put(" ^spatial");
                    break;
                case DbIndexType.Clustered:
                    Put(" ^clustered");
                    break;
            }
            if (ix.IsUnique) Put(" ^unique");
            Put(" ^index %i &n^on %f (&>&n", ix.ConstraintName, ix.OwnerTable.FullName);
            bool was = false;
            foreach (var col in ix.Columns.Where(x => x.IsIncluded != true))
            {
                if (was) Put("&n,");
                Put("%i %k", col.RefColumnName, col.IsDescending == true ? "DESC" : "ASC");
                was = true;
            }
            Put("&<&n)");
            was = false;
            if (ix.Columns.Any(x => x.IsIncluded == true))
            {
                Put(" ^include (&>&n");
                foreach (var col in ix.Columns.Where(x => x.IsIncluded == true))
                {
                    if (was) Put("&n,");
                    Put("%i", col.RefColumnName);
                    was = true;
                }
                Put("&<&n)");
            }
            EndCommand();
        }

        public override void DropIndex(IndexInfo ix)
        {
            Put("^drop ^index %i ^on %f", ix.ConstraintName, ix.OwnerTable.FullName);
            EndCommand();
        }

        public override void ExtractMonth(Action<ISqlDumper> argument)
        {
            Put("^datepart(^month, ");
            argument(this);
            Put(")");
        }

        public override void ExtractDayOfMonth(Action<ISqlDumper> argument)
        {
            Put("^datepart(^day, ");
            argument(this);
            Put(")");
        }

        public override void ExtractDayOfWeek(Action<ISqlDumper> argument)
        {
            Put("^datepart(^weekday, ");
            argument(this);
            Put(")");
        }

        public override void PutDayOfWeekLiteral(DayOfWeek value)
        {
            Put("%s", ((int)value) + 1);
        }

        public override void EnableConstraints(NameWithSchema table, bool enabled)
        {
            PutCmd("^alter ^table %f %k ^constraint ^all", table, enabled ? "check" : "nocheck");
        }

        public override void ColumnReadableValue(ColumnInfo column, string alias = null)
        {
            var isGeo = column.DataType.ToLower().Contains("geo");
            if (isGeo) Put("^convert(^nvarchar(^max), ");
            base.ColumnReadableValue(column, alias);
            if (isGeo) Put(")");
        }
    }
}
