using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.DbDiff;
using Pomelo.Data.MySql;
using System;
using System.Data.Common;
using System.IO;
using System.Reflection;

namespace DbShell.Driver.MySql
{
    public class MySqlDatabaseFactory : DatabaseFactoryBase
    {
        public MySqlDatabaseFactory(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {
        }

        public override string[] Identifiers
        {
            get { return new string[] { "mysql" }; }
        }

        public override DbConnection CreateConnection(string connectionString)
        {
            return new MySqlConnection(connectionString);
        }

        public override Type[] ConnectionTypes
        {
            get { return new Type[] { typeof(MySqlConnection) }; }
        }

        public override ISqlDumper CreateDumper(ISqlOutputStream stream, SqlFormatProperties props)
        {
            return new MySqlSqlDumper(stream, this, props);
        }

        //public override ILiteralFormatter CreateLiteralFormatter()
        //{
        //    return new SqliteLiteralFormatter(this);
        //}

        public override ISqlDialect CreateDialect()
        {
            return new MySqlDialect(this);
        }

        public override IDatabaseServerInterface CreateDatabaseServerInterface()
        {
            return new MySqlServerInterface();
        }

        public override DatabaseAnalyser CreateAnalyser()
        {
            return new MySqlDatabaseAnalyser
            {
                Factory = this,
            };
        }

        public override IStatisticsProvider CreateStatisticsProvider()
        {
            return new MySqlStatisticsProvider();
        }

        public override SqlDialectCaps DialectCaps
        {
            get
            {
                var res = base.DialectCaps;
                res.MultiCommand = true;
                res.ForeignKeys = true;
                res.Uniques = false;
                res.MultipleSchema = false;
                res.MultipleDatabase = false;
                res.UncheckedReferences = true;
                res.NestedTransactions = true;
                res.AnonymousPrimaryKey = true;
                res.RangeSelect = true;
                res.AllowDeleteFrom = false;
                res.AllowUpdateFrom = false;
                res.RowId = "rowid";
                res.EnableConstraintsPerTable = false;
                return res;
            }
        }

        internal static string LoadEmbeddedResource(string name)
        {
            using (Stream s = GetAssembly(typeof(MySqlDatabaseFactory)).GetManifestResourceStream("DbShell.Driver.MySql." + name))
            {
                if (s == null)
                    throw new InvalidOperationException("Could not find embedded resource");
                using (var sr = new StreamReader(s))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        private static Assembly GetAssembly(Type type)
        {
#if NETSTANDARD2_0
            return type.GetTypeInfo().Assembly;
#else
            return type.Assembly;
#endif
        }
    }

}
