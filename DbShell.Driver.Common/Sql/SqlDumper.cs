using System.Collections.Generic;
using System.Text.RegularExpressions;
using DbShell.Driver.Common.AbstractDb;
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

        public virtual void DropView(ViewInfo obj)
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

        public virtual void DropStoredProcedure(StoredProcedureInfo obj)
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

        public virtual void DropFunction(FunctionInfo obj)
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

        public virtual void CreateTable(TableInfo obj)
        {
            throw new System.NotImplementedException();
        }

        public virtual void DropTable(TableInfo obj)
        {
            throw new System.NotImplementedException();
        }

        public virtual void ChangeTableSchema(NameWithSchema obj, string schema)
        {
            throw new System.NotImplementedException();
        }

        public virtual void RenameTable(NameWithSchema obj, string newname)
        {
            throw new System.NotImplementedException();
        }
    }
}
