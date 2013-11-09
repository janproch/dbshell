using System.Collections.Generic;
using System.Text.RegularExpressions;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;

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
            WriteRaw(obj.QueryText);
            EndCommand();
        }

        public virtual void DropView(ViewInfo obj, bool testIfExists)
        {
            PutCmd("^drop ^view  %f", obj.FullName);
        }

        public virtual void AlterView(ViewInfo obj)
        {
            WriteRaw(Regex.Replace(obj.QueryText, @"create\s+view", "ALTER VIEW", RegexOptions.IgnoreCase));
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
            WriteRaw(obj.SqlText);
            EndCommand();
        }

        public virtual void DropStoredProcedure(StoredProcedureInfo obj, bool testIfExists)
        {
            PutCmd("^drop ^procedure  %f", obj.FullName);
        }

        public virtual void AlterStoredProcedure(StoredProcedureInfo obj)
        {
            WriteRaw(Regex.Replace(obj.SqlText, @"create\s+procedure", "ALTER PROCEDURE", RegexOptions.IgnoreCase));
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
            WriteRaw(obj.SqlText);
            EndCommand();
        }

        public virtual void DropFunction(FunctionInfo obj, bool testIfExists)
        {
            PutCmd("^drop ^function %f", obj.FullName);
        }

        public virtual void AlterFunction(FunctionInfo obj)
        {
            WriteRaw(Regex.Replace(obj.SqlText, @"create\s+function", "ALTER FUNCTION", RegexOptions.IgnoreCase));
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

        public virtual void CreateTable(TableInfo table)
        {
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
        }

        protected virtual void CreateForeignKeyCore(ForeignKeyInfo fk)
        {
            if (fk.ConstraintName != null) Put("^constraint %i ", fk.ConstraintName);
            Put("^foreign ^key (");
            ColumnRefs(fk.Columns);
            Put(") ^references %f", fk.RefTable);
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
            Put("%i", colref.Name);
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
            if (col.Length != 0)
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

        public virtual void DropForeignKey(ForeignKeyInfo fk)
        {
            PutCmd("^alter ^table %f ^drop ^constraint %i", fk.OwnerTable.FullName, fk.ConstraintName);
        }

        public virtual void CreateForeignKey(ForeignKeyInfo fk)
        {
            Put("^alter ^table %f ^add ", fk.OwnerTable);
            CreateForeignKeyCore(fk);
            EndCommand();
        }
        public virtual void DropPrimaryKey(PrimaryKeyInfo fk)
        {
            PutCmd("^alter ^table %f ^drop ^constraint %i", fk.OwnerTable.FullName, fk.ConstraintName);
        }
        public virtual void CreatePrimaryKey(PrimaryKeyInfo pk)
        {
            Put("^alter ^table %f ^add ^constraint %i ^primary ^key", pk.OwnerTable, pk.ConstraintName);
            WriteRaw(" (");
            ColumnRefs(pk.Columns);
            WriteRaw(")");
            EndCommand();
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
