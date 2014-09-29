using System;
using System.Data.Common;
using DbShell.Driver.Common.Sql;

namespace DbShell.Driver.Common.AbstractDb
{
    public abstract class DatabaseFactoryBase : IDatabaseFactory
    {
        public virtual DatabaseAnalyser CreateAnalyser()
        {
            return null;
        }

        public virtual IDialectDataAdapter CreateDataAdapter()
        {
            return new GenericDialectDataAdapter(this, SqlFormatProperties.Default);
        }

        public virtual ISqlDumper CreateDumper(ISqlOutputStream stream, SqlFormatProperties props)
        {
            return new SqlDumper(stream, this, props);
        }

        public virtual ISqlDialect CreateDialect()
        {
            return new DialectBase();
        }

        public abstract string[] Identifiers { get; }

        public abstract DbConnection CreateConnection(string connectionString);

        public abstract Type[] ConnectionTypes { get; }

        public virtual IBulkInserter CreateBulkInserter()
        {
            return new BulkInserterBase();
        }

        public virtual ILiteralFormatter CreateLiteralFormatter()
        {
            return new LiteralFormatterBase(this);
        }

        public virtual IStatisticsProvider CreateStatisticsProvider()
        {
            return null;
        }

        public virtual IParsingService CreateParsingService()
        {
            return null;
        }

        public virtual IDatabaseServerInterface CreateDatabaseServerInterface()
        {
            return null;
        }

        public virtual ISqlTypeProvider CreateSqlTypeProvider()
        {
            return new SqlTypeProviderBase();
        }
    }
}