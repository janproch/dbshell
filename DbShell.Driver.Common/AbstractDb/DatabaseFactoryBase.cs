using System;
using System.Data.Common;

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
            return new GenericDialectDataAdapter(this, new SqlFormatProperties());
        }

        public virtual ISqlDumper CreateDumper(ISqlOutputStream stream, SqlFormatProperties props)
        {
            return null;
        }

        public ISqlDialect CreateDialect()
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
    }
}