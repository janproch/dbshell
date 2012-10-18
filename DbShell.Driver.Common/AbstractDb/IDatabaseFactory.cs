namespace DbShell.Driver.Common.AbstractDb
{
    public interface IDatabaseFactory
    {
        DatabaseAnalyser CreateAnalyser();
        IDialectDataAdapter CreateDataAdapter();
        ISqlDumper CreateDumper(ISqlOutputStream stream, SqlFormatProperties props);
        ISqlDialect CreateDialect();
    }

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
    }
}
