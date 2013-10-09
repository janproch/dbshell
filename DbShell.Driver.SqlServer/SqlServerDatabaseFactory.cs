using System;
using System.Data.SqlClient;
using System.IO;
using DbShell.Driver.Common.AbstractDb;

namespace DbShell.Driver.SqlServer
{
    public class SqlServerDatabaseFactory : DatabaseFactoryBase
    {
        public static readonly SqlServerDatabaseFactory Instance = new SqlServerDatabaseFactory();

        public override DatabaseAnalyser CreateAnalyser()
        {
            return new SqlServerDatabaseAnalyser();
        }

        internal static string LoadEmbeddedResource(string name)
        {
            using (Stream s = typeof (SqlServerDatabaseFactory).Assembly.GetManifestResourceStream("DbShell.Driver.SqlServer." + name))
            {
                if (s == null)
                    throw new InvalidOperationException("Could not find embedded resource");
                using (var sr = new StreamReader(s))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        public override string[] Identifiers
        {
            get { return new string[] {"sqlserver"}; }
        }

        public override Type[] ConnectionTypes
        {
            get { return new Type[] {typeof (SqlConnection)}; }
        }

        public override System.Data.Common.DbConnection CreateConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }

        public static void Initialize()
        {
            FactoryProvider.RegisterFactory(Instance);
        }

        public override ILiteralFormatter CreateLiteralFormatter()
        {
            return new SqlServerLiteralFormatter(this);
        }

        public override ISqlDialect CreateDialect()
        {
            return new SqlServerDialect();
        }

        public override ISqlDumper CreateDumper(ISqlOutputStream stream, SqlFormatProperties props)
        {
            return new SqlServerSqlDumper(stream, this, props);
        }

        public override IStatisticsProvider CreateStatisticsProvider()
        {
            return new SqlServerStatisticsProvider();
        }

        public override IParsingService CreateParsingService()
        {
            return new SqlServerParsingService();
        }

        public override IBulkInserter CreateBulkInserter()
        {
            return new SqlServerBulkInserter();
        }
    }
}
