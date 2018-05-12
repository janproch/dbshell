using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DbShell.Test.EngineProviders
{
    public static class EngineProviderFactory
    {
        public static IDatabaseEngineProvider GetProvider(string engine)
        {
            switch (engine)
            {
                case "mssql":
                    return new SqlServerEngineProvider();
                case "sqlite":
                    return new SqliteEngineProvider();
                case "mysql":
                    return new MySqlEngineProvider();
            }
            return null;
        }

        public static void RunEmbeddedScript(IDatabaseEngineProvider provider, string name)
        {
            using (var conn = provider.OpenConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = LoadEmbeddedResource(name);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static string LoadEmbeddedResource(string name)
        {
            string requestedName = typeof(EngineProviderFactory).Namespace + "." + name;
            using (Stream s = typeof(EngineProviderFactory).Assembly.GetManifestResourceStream(requestedName))
            {
                if (s == null)
                {
                    throw new InvalidOperationException("Could not find embedded resource " + requestedName +", available:" 
                        + string.Join(",", typeof(EngineProviderFactory).Assembly.GetManifestResourceNames()));
                }
                using (var sr = new StreamReader(s))
                {
                    return sr.ReadToEnd();
                }
            }
        }

    }
}
