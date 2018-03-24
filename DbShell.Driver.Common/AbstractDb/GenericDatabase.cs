using DbShell.Driver.Common.Utility;
using System;

namespace DbShell.Driver.Common.AbstractDb
{
    public class GenericDialect : DialectBase
    {
        internal static readonly GenericDialect InternalInstance = new GenericDialect(GenericDatabaseFactory.InternalInstance);

        protected GenericDialect(GenericDatabaseFactory factory)
            : base(factory)
        {
        }
    }

    public class GenericDatabaseFactory : DatabaseFactoryBase
    {
        internal static readonly GenericDatabaseFactory InternalInstance = new GenericDatabaseFactory(GenericServicesProvider.InternalInstance);

        protected GenericDatabaseFactory(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {
        }

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
        internal readonly static GenericDialectDataAdapter InternalInstance = new GenericDialectDataAdapter(GenericDatabaseFactory.InternalInstance, SqlFormatProperties.Default);

        public GenericDialectDataAdapter(IDatabaseFactory factory, SqlFormatProperties props)
            : base(factory)
        {
        }
    }
}
