using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.DbDiff;
using DbShell.Driver.Common.Structure;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Reflection;
using System.Text;

namespace DbShell.Driver.Postgres
{
    public class PostgresDatabaseFactory : DatabaseFactoryBase
    {
        public PostgresDatabaseFactory(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {
        }

        public override string[] Identifiers
        {
            get { return new string[] { "postgres" }; }
        }

        public override DbConnection CreateConnection(string connectionString)
        {
            return new NpgsqlConnection(connectionString);
        }

        public override Type[] ConnectionTypes
        {
            get { return new Type[] { typeof(NpgsqlConnection) }; }
        }

        public override ISqlDumper CreateDumper(ISqlOutputStream stream, SqlFormatProperties props)
        {
            return new PostgresSqlDumper(stream, this, props);
        }

        //public override ILiteralFormatter CreateLiteralFormatter()
        //{
        //    return new PostgresLiteralFormatter(this);
        //}

        public override ISqlDialect CreateDialect()
        {
            return new PostgresDialect(this);
        }

        public override IDatabaseServerInterface CreateDatabaseServerInterface()
        {
            return new PostgreSqlServerInterface();
        }

        public override DatabaseAnalyser CreateAnalyser()
        {
            return new PostgresAnalyser
            {
                Factory = this,
            };
        }

        public override SqlDialectCaps DialectCaps
        {
            get
            {
                var res = base.DialectCaps;

                res.MultiCommand = true;
                res.ForeignKeys = true;
                res.Uniques = true;
                res.MultipleSchema = true;
                res.MultipleDatabase = true;
                res.NestedTransactions = true;
                res.AnonymousPrimaryKey = true;
                res.RangeSelect = true;
                res.AllowDeleteFrom = false;
                res.AllowUpdateFrom = false;
                res.SupportsKeyInfo = true;
                res.EnableConstraintsPerTable = true;
                return res;
            }
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
                    CreateDatabase = true,
                    DropDatabase = true,
                    RenameColumn = true,
                    ChangeColumnType = true,
                    ChangeColumnDefaultValue = true,
                    AddColumn = true,
                    DropColumn = true,
                    ChangeColumn = true,
                    RenameTable = true,
                    AddConstraint = true,
                    DropConstraint = true,
                    AddIndex = true,
                    DropIndex = true,
                };
            }
        }

        internal static string LoadEmbeddedResource(string name)
        {
            using (Stream s = GetAssembly(typeof(PostgresDatabaseFactory)).GetManifestResourceStream("DbShell.Driver.Postgres." + name))
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
