namespace DbShell.Driver.Common.AbstractDb
{
    public class GenericDialect : DialectBase
    {
        public static GenericDialect Instance = new GenericDialect();
    }

    public class GenericDatabaseFactory : DatabaseFactoryBase
    {
        public static GenericDatabaseFactory Instance = new GenericDatabaseFactory();
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
