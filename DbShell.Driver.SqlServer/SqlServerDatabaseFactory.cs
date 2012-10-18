using System;
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
            using (Stream s = typeof(SqlServerDatabaseFactory).Assembly.GetManifestResourceStream("DbShell.Driver.SqlServer." + name))
            {
                if (s == null)
                    throw new InvalidOperationException("Could not find embedded resource");
                using (var sr = new StreamReader(s))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}
