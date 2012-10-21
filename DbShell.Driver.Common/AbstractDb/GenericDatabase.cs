using System;

namespace DbShell.Driver.Common.AbstractDb
{
    public class GenericDialect : DialectBase
    {
        public static GenericDialect Instance = new GenericDialect();
    }

    public class GenericDatabaseFactory : DatabaseFactoryBase
    {
        public static GenericDatabaseFactory Instance = new GenericDatabaseFactory();

        public override string[] Identifiers
        {
            get { return new string[] {}; }
        }

        public override System.Data.Common.DbConnection CreateConnection(string connectionString)
        {
            throw new System.NotImplementedException();
        }

        public override System.Type[] ConnectionTypes
        {
            get { return new Type[] {}; }
        }
    }

    public class GenericDialectDataAdapter : DialectDataAdapterBase
    {
        public static readonly GenericDialectDataAdapter Instance = new GenericDialectDataAdapter(GenericDatabaseFactory.Instance, SqlFormatProperties.Default);

        public GenericDialectDataAdapter(IDatabaseFactory factory, SqlFormatProperties props)
            : base(factory)
        {
        }
    }
}
