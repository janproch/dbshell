using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.DbDiff;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using System.Linq;

namespace DbShell.Driver.Common.Sql
{
    public partial class SqlDumper : ISqlDumper
    {
        protected readonly ISqlOutputStream m_stream;
        protected readonly SqlFormatProperties m_props;
        protected readonly ISqlDialect m_dialect;
        SqlFormatterState m_formatterState = new SqlFormatterState();
        IDialectDataAdapter m_DDA;
        private IDatabaseFactory m_factory;

        public SqlDumper(ISqlOutputStream stream, IDatabaseFactory factory, SqlFormatProperties props)
        {
            m_stream = stream;
            m_props = props;
            m_factory = factory;
            m_DDA = m_factory.CreateDataAdapter();
            m_formatterState.DDA = m_DDA;
            m_dialect = m_factory.CreateDialect();
        }

        public ISqlOutputStream Stream
        {
            get { return m_stream; }
        }

        public SqlFormatProperties FormatProperties
        {
            get { return m_props; }
        }

        public IDatabaseFactory Factory
        {
            get { return m_factory; }
        }

        public virtual void AllowIdentityInsert(NameWithSchema table, bool allow)
        {
        }

        public virtual void EnableConstraints(NameWithSchema table, bool enabled)
        {
        }

        public virtual void RenameDomain(NameWithSchema domain, string newname)
        {
        }
        public virtual void ChangeDomainSchema(NameWithSchema domain, string newschema)
        {
        }

        public ISqlDialect Dialect { get { return m_dialect; } }

        public SqlFormatterState FormatterState
        {
            get { return m_formatterState; }
        }

        public virtual void ReorderColumns(NameWithSchema table, List<string> newColumnOrder)
        {
            PutCmd("/* RECORDER COLUMNS FOR %f (%,i) */", table, newColumnOrder);
        }

        public virtual void AlterDatabaseOptions(string dbname, Dictionary<string, string> options)
        {
        }

        public virtual void CreateView(ViewInfo obj)
        {
            WriteRaw(obj.CreateSql);
            EndCommand();
        }

        public virtual void DropView(ViewInfo obj, bool testIfExists)
        {
            PutCmd("^drop ^view  %f", obj.FullName);
        }

        public virtual void AlterView(ViewInfo obj)
        {
            WriteRaw(Regex.Replace(obj.CreateSql, @"create\s+view", "ALTER VIEW", RegexOptions.IgnoreCase));
            EndCommand();
        }

        public virtual void ChangeViewSchema(ViewInfo obj, string newschema)
        {
            throw new System.NotImplementedException();
        }

        public virtual void RenameView(ViewInfo obj, string newname)
        {
            throw new System.NotImplementedException();
        }

        public virtual void CreateStoredProcedure(StoredProcedureInfo obj)
        {
            WriteRaw(obj.CreateSql);
            EndCommand();
        }

        public virtual void DropStoredProcedure(StoredProcedureInfo obj, bool testIfExists)
        {
            PutCmd("^drop ^procedure  %f", obj.FullName);
        }

        public virtual void AlterStoredProcedure(StoredProcedureInfo obj)
        {
            WriteRaw(Regex.Replace(obj.CreateSql, @"create\s+procedure", "ALTER PROCEDURE", RegexOptions.IgnoreCase));
            EndCommand();
        }

        public virtual void ChangeStoredProcedureSchema(StoredProcedureInfo obj, string newschema)
        {
            throw new System.NotImplementedException();
        }

        public virtual void RenameStoredProcedure(StoredProcedureInfo obj, string newname)
        {
            throw new System.NotImplementedException();
        }

        public virtual void CreateFunction(FunctionInfo obj)
        {
            WriteRaw(obj.CreateSql);
            EndCommand();
        }

        public virtual void DropFunction(FunctionInfo obj, bool testIfExists)
        {
            PutCmd("^drop ^function %f", obj.FullName);
        }

        public virtual void AlterFunction(FunctionInfo obj)
        {
            WriteRaw(Regex.Replace(obj.CreateSql, @"create\s+function", "ALTER FUNCTION", RegexOptions.IgnoreCase));
            EndCommand();
        }

        public virtual void ChangeFunctionSchema(FunctionInfo obj, string newschema)
        {
            throw new System.NotImplementedException();
        }

        public virtual void RenameFunction(FunctionInfo obj, string newname)
        {
            throw new System.NotImplementedException();
        }

        public virtual void CreateTrigger(TriggerInfo obj)
        {
            WriteRaw(obj.CreateSql);
            EndCommand();
        }

        public virtual void DropTrigger(TriggerInfo obj, bool testIfExists)
        {
            PutCmd("^drop ^trigger %f", obj.FullName);
        }

        public virtual void AlterTrigger(TriggerInfo obj)
        {
            WriteRaw(Regex.Replace(obj.CreateSql, @"create\s+trigger", "ALTER TRIGGER", RegexOptions.IgnoreCase));
            EndCommand();
        }

        public virtual void ChangeTriggerSchema(TriggerInfo obj, string newschema)
        {
            throw new NotImplementedException();
        }

        public virtual void RenameTrigger(TriggerInfo obj, string newname)
        {
            throw new NotImplementedException();
        }

        public virtual void CreateTable(TableInfo tableSrc)
        {
            var table = tableSrc.CloneTable();
            table.AfterLoadLink();
            Put("^create ^table %f ( &>&n", table.FullName);
            bool first = true;
            foreach (var col in table.Columns)
            {
                if (!first) Put(", &n");
                first = false;
                Put("%i ", col.Name);
                ColumnDefinition(col, true, true, true);
            }
            if (table.PrimaryKey != null)
            {
                if (!first) Put(", &n");
                first = false;
                if (table.PrimaryKey.ConstraintName != null)
                {
                    Put("^constraint %i", table.PrimaryKey.ConstraintName);
                }
                Put(" ^primary ^key (%,i)", table.PrimaryKey.Columns);
            }
            foreach (var cnt in table.ForeignKeys)
            {
                if (!first) Put(", &n");
                first = false;
                CreateForeignKeyCore(cnt);
            }
            Put("&<&n)");
            EndCommand();
        }

        protected virtual void CreateForeignKeyCore(ForeignKeyInfo fk)
        {
            if (fk.ConstraintName != null) Put("^constraint %i ", fk.ConstraintName);
            Put("^foreign ^key (");
            ColumnRefs(fk.Columns);
            Put(") ^references %f", fk.RefTableFullName);
            if (fk.RefColumns != null)
            {
                WriteRaw("(");
                ColumnRefs(fk.RefColumns);
                WriteRaw(")");
            }
            string ondelete = fk.OnDeleteAction.SqlName();
            string onupdate = fk.OnUpdateAction.SqlName();
            if (ondelete != null) Put(" ^on ^delete %k", ondelete);
            if (onupdate != null) Put(" ^on ^update %k", onupdate);
        }

        protected virtual void ColumnRef(ColumnReference colref)
        {
            Put("%i", colref.RefColumnName);
            //WriteRaw(QuoteIdentifier(colref.Name, null));
        }

        protected virtual void ColumnRefs(IEnumerable<ColumnReference> colrefs)
        {
            bool was = false;
            foreach (var colref in colrefs)
            {
                if (was) WriteRaw(",");
                ColumnRef(colref);
                was = true;
            }
        }

        public virtual void ColumnDefinition(ColumnInfo col, bool includeDefault, bool includeNullable, bool includeCollate)
        {
            if (col.ComputedExpression != null)
            {
                Put("^as %s", col.ComputedExpression);
                if (col.IsPersisted) Put(" ^persisted");
                return;
            }

            Put("%k", col.DataType);
            if (col.Length != 0 && (col.CommonType == null || col.CommonType is DbTypeString))
            {
                if (col.Length == -1 || col.Length > 8000) Put("(^max)");
                else Put("(%s)", col.Length);
            }
            if (col.Precision > 0 && col.CommonType is DbTypeNumeric)
            {
                Put("(%s,%s)", col.Precision, col.Scale);
            }
            if (col.AutoIncrement)
            {
                Put(" ^identity");
            }
            WriteRaw(" ");
            if (includeNullable)
            {
                Put(col.NotNull ? "^not ^null" : "^null");
            }
            if (includeDefault && col.DefaultValue != null)
            {
                ColumnDefinition_Default(col);
            }
        }

        private void ColumnDefinition_Default(ColumnInfo col)
        {
            string defsql = col.DefaultValue;
            if (col.DefaultConstraint != null)
            {
                Put(" ^constraint %i ^default %s ", col.DefaultConstraint, defsql);
            }
            else
            {
                Put(" ^default %s ", defsql);
            }
        }

        protected virtual void DropConstraint(ConstraintInfo cnt)
        {
            PutCmd("^alter ^table %f ^drop ^constraint %i", cnt.OwnerTable.FullName, cnt.ConstraintName);
        }

        public virtual void DropForeignKey(ForeignKeyInfo fk)
        {
            DropConstraint(fk);
        }

        public virtual void CreateForeignKey(ForeignKeyInfo fk)
        {
            Put("^alter ^table %f ^add ", fk.OwnerTable);
            CreateForeignKeyCore(fk);
            EndCommand();
        }
        public virtual void DropPrimaryKey(PrimaryKeyInfo pk)
        {
            DropConstraint(pk);
        }
        public virtual void CreatePrimaryKey(PrimaryKeyInfo pk)
        {
            Put("^alter ^table %f ^add ^constraint %i ^primary ^key", pk.OwnerTable, pk.ConstraintName);
            WriteRaw(" (");
            ColumnRefs(pk.Columns);
            WriteRaw(")");
            EndCommand();
        }

        public virtual void DropIndex(IndexInfo ix)
        {
            throw new NotImplementedException();
        }

        public virtual void CreateIndex(IndexInfo ix)
        {
            throw new NotImplementedException();
        }

        public virtual void DropUnique(UniqueInfo uq)
        {
            DropConstraint(uq);
        }

        public virtual void CreateUnique(UniqueInfo uq)
        {
            Put("^alter ^table %f ^add ^constraint %i ^unique", uq.OwnerTable, uq.ConstraintName);
            WriteRaw(" (");
            ColumnRefs(uq.Columns);
            WriteRaw(")");
            EndCommand();
        }

        public virtual void DropCheck(CheckInfo ch)
        {
            DropConstraint(ch);
        }

        public virtual void CreateCheck(CheckInfo ch)
        {
            PutCmd("^alter ^table %f ^add ^constraint %i ^check (%s)", ch.OwnerTable, ch.ConstraintName, ch.Definition);
        }

        public virtual void RenameConstraint(ConstraintInfo constraint, string newname)
        {
            throw new System.NotImplementedException();
        }

        public virtual void CreateColumn(ColumnInfo column, IEnumerable<ConstraintInfo> constraints)
        {
            Put("^alter ^table %f ^add %i ", column.OwnerTable, column.Name);
            ColumnDefinition(column, true, true, true);
            InlineConstraints(constraints);
            EndCommand();
        }

        protected virtual void InlineConstraints(IEnumerable<ConstraintInfo> constrains)
        {
            if (constrains == null) return;
            foreach (var cnt in constrains)
            {
                if (cnt is PrimaryKeyInfo)
                {
                    if (cnt.ConstraintName != null && !m_dialect.DialectCaps.AnonymousPrimaryKey)
                    {
                        Put(" ^constraint %i", cnt.ConstraintName);
                    }
                    Put(" ^primary ^key ");
                }
            }
        }

        public virtual void DropColumn(ColumnInfo column)
        {
            PutCmd("^alter ^table %f ^drop ^column %i", column.OwnerTable.FullName, column.Name);
        }

        public virtual void RenameColumn(ColumnInfo column, string newcol)
        {
            throw new System.NotImplementedException();
        }

        public virtual void ChangeColumn(ColumnInfo oldcol, ColumnInfo newcol, IEnumerable<ConstraintInfo> constraints)
        {
            throw new System.NotImplementedException();
        }

        private static List<int> GetColumnMap(TableInfo oldTable, TableInfo newTable)
        {
            List<int> columnMap = new List<int>();

            foreach (var col in newTable.Columns)
            {
                columnMap.Add(oldTable.Columns.IndexOfIf(c => c.GroupId == col.GroupId));
            }

            return columnMap;
        }

        public static string TempTableNameOverride;
        private static string GenerateTempTableName(int id)
        {
            if (TempTableNameOverride != null) return TempTableNameOverride;
            return "temp_table_" + id.ToString() + "_" + DateTime.UtcNow.ToFileTime().ToString();
        }

        public static int _lastAlterTableId = 0;
        public virtual void RecreateTable(TableInfo oldTable, TableInfo newTable)
        {
            if (oldTable.GroupId != newTable.GroupId) throw new InternalError("DAE-00040 Recreate is not possible: oldTable.GroupId != newTable.GroupId");
            var columnMap = GetColumnMap(oldTable, newTable);
            int id = System.Threading.Interlocked.Increment(ref _lastAlterTableId);
            string tmptable = GenerateTempTableName(id);

            // remove constraints
            //DropConstraints(oldTable.GetReferencedFrom(), DropFlags.None);
            this.DropConstraints(oldTable.Constraints);

            RenameTable(oldTable, tmptable);

            var old = oldTable.CloneTable();
            old.FullName = new NameWithSchema(oldTable.FullName.Schema, tmptable);

            CreateTable(newTable);

            var idcol = newTable.FindAutoIncrementColumn();
            bool hasident = idcol != null && columnMap[idcol.ColumnOrder] >= 0;
            if (hasident) AllowIdentityInsert(newTable.FullName, true);
            PutCmd("^insert ^into %f (%,i) select %,s ^from %f", newTable.FullName,
                from c in newTable.Columns
                where columnMap[c.ColumnOrder] >= 0
                select c.Name,
                from dstindex in
                    (
                    from i in PyList.Range(newTable.Columns.Count)
                    where columnMap[i] >= 0
                    select i
                    )
                let srcindex = columnMap[dstindex]
                select
                    (srcindex < 0
                    // srcindex < 0 should not occur thanks to filtering
                    ? Format("^null ^as %i", newTable.Columns[dstindex].Name)
                    : Format("^%i ^as %i", old.Columns[srcindex].Name, newTable.Columns[dstindex].Name)),
                old.FullName);
            if (hasident) AllowIdentityInsert(newTable.FullName, false);

            // newTable.Constraints are allready created
            //CreateConstraints(newTable.GetReferencedFrom());

            PutCmd("^drop ^table %i", tmptable);
        }

        public AlterProcessorCaps AlterCaps
        {
            get { return m_factory.CreateDialect().DumperCaps; }
        }

        public virtual void DropTable(TableInfo obj, bool testIfExists)
        {
            PutCmd("^drop ^table %f", obj.FullName);
        }

        public virtual void ChangeTableSchema(TableInfo obj, string schema)
        {
            throw new System.NotImplementedException();
        }

        public virtual void RenameTable(TableInfo obj, string newname)
        {
            throw new System.NotImplementedException();
        }
    }
}
