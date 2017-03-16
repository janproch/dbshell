using System;
using System.Data.Common;
using DbShell.Driver.Common.DbDiff;
using DbShell.Driver.Common.Sql;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.AbstractDb
{
    public abstract class DatabaseFactoryBase : IDatabaseFactory
    {
        public virtual DatabaseAnalyser CreateAnalyser()
        {
            throw new NotImplementedError("DBSH-00155");
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
            return new DialectBase(this);
        }

        public virtual SqlDumperCaps DumperCaps
        {
            get { return new SqlDumperCaps(); }
        }

        public virtual SqlDialectCaps DialectCaps
        {
            get
            {
                var res = new SqlDialectCaps(true);
                res.Domains = false;
                res.UncheckedReferences = false;
                res.AnonymousPrimaryKey = false;
                res.NestedTransactions = false;
                res.UseDatabaseAsSchema = false;
                res.RangeSelect = false;
                res.Arrays = false;
                res.SupportBackup = false;
                res.AutoIncrement = true;
                return res;
            }
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

#if !NETCOREAPP1_1
        public virtual IParsingService CreateParsingService()
        {
            return null;
        }
#endif

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