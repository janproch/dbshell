using System;
using System.Data.SqlClient;
using System.IO;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.DbDiff;
using System.Reflection;

namespace DbShell.Driver.SqlServer
{
    public class SqlServerDatabaseFactory : DatabaseFactoryBase
    {
        public static readonly SqlServerDatabaseFactory Instance = new SqlServerDatabaseFactory();

        public override DatabaseAnalyser CreateAnalyser()
        {
            return new SqlServerDatabaseAnalyser
            {
                Factory = this,
            };
        }

        private static Assembly GetAssembly(Type type)
        {
#if NETSTANDARD2_0
            return type.GetTypeInfo().Assembly;
#else
            return type.Assembly;
#endif
        }

        internal static string LoadEmbeddedResource(string name)
        {
            using (Stream s = GetAssembly(typeof(SqlServerDatabaseFactory)).GetManifestResourceStream("DbShell.Driver.SqlServer." + name))
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
            get { return new string[] { "mssql", "sqlserver" }; }
        }

        public override Type[] ConnectionTypes
        {
            get { return new Type[] { typeof(SqlConnection) }; }
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

#if !NETSTANDARD2_0
        public override IParsingService CreateParsingService()
        {
            return new SqlServerParsingService();
        }

        public override IBulkInserter CreateBulkInserter()
        {
            return new SqlServerBulkInserter();
        }
#endif

        public override IDatabaseServerInterface CreateDatabaseServerInterface()
        {
            return new SqlServerInterface();
        }

        public override ISqlTypeProvider CreateSqlTypeProvider()
        {
            return new SqlServerTypeProvider();
        }

        public override IDialectDataAdapter CreateDataAdapter()
        {
            return new SqlServerDialectDataAdapter(this);
        }

        public override SqlDumperCaps DumperCaps
        {
            get
            {
                return new SqlDumperCaps
                {
                    AllFlags = false,

                    CreateTable = true,
                    DropTable = true,
                    //AlterTable = true,
                    RenameTable = true,
                    RecreateTable = true,
                    ChangeTableSchema = true,

                    ChangeColumnType = true,
                    RenameColumn = true,
                    AddColumn = true,
                    DropColumn = true,
                    ChangeColumn = true,
                    ChangeColumnDefaultValue = true,

                    RenameConstraint = true,
                    AddConstraint = true,
                    DropConstraint = true,
                    RenameIndex = true,
                    AddIndex = true,
                    DropIndex = true,

                    CreateDatabase = true,
                    DropDatabase = true,
                    RenameDatabase = true,

                    CreateSchema = true,
                    RenameSchema = true,
                    DropSchema = true,

                    ViewCaps = new ObjectOperationCaps { AllFlags = true, Change = false },
                    StoredProcedureCaps = new ObjectOperationCaps { AllFlags = true, Change = false },
                    FunctionCaps = new ObjectOperationCaps { AllFlags = true, Change = false },
                    TriggerCaps = new ObjectOperationCaps { AllFlags = true, Change = false },
                    DepCaps = new AlterDependencyCaps { AllFlags = true },
                };
            }
        }

        public override SqlDialectCaps DialectCaps
        {
            get
            {
                var res = base.DialectCaps;
                res.MultiCommand = false;
                res.NestedTransactions = true;
                res.ExplicitDropConstraint = false;
                //if (m_version.Is_2005()) res.LimitSelect = true;
                res.Domains = true;
                res.SupportBackup = true;
                res.AllowDeleteFrom = true;
                res.AllowUpdateFrom = true;
                res.MultipleSchema = true;
                return res;
            }
        }

    }
}
