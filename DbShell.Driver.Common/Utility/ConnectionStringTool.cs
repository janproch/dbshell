using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DbShell.Driver.Common.Utility
{
    public static class ConnectionStringTool
    {
        public static string ExtractDatabaseName(string connectionString)
        {
            var m = Regex.Match(connectionString, "(^|;)(initial catalog|database)=([^;]*)($|;)", RegexOptions.IgnoreCase);
            if (m.Success) return m.Groups[3].Value;
            return null;
        }

        public static string ReplaceDatabaseName(string connectionString, string newDatabase)
        {
            return Regex.Replace(connectionString, "(^|;)(initial catalog|database)=([^;]*)($|;)",
                                 m => m.Groups[1].Value + m.Groups[2].Value + "=" + newDatabase + m.Groups[4].Value, RegexOptions.IgnoreCase);
        }

        public static string RemoveDatabaseName(string connectionString)
        {
            connectionString = Regex.Replace(connectionString, "^(initial catalog|database)=([^;]*);", "", RegexOptions.IgnoreCase);
            connectionString = Regex.Replace(connectionString, ";(initial catalog|database)=([^;]*);", ";", RegexOptions.IgnoreCase);
            connectionString = Regex.Replace(connectionString, ";(initial catalog|database)=([^;]*)$", "", RegexOptions.IgnoreCase);
            return connectionString;
        }

        public static bool IsTheSameExceptDatabase(string connectionString1, string connectionString2)
        {
            string repl1 = ReplaceDatabaseName(connectionString1, "GenericDatabase");
            string repl2 = ReplaceDatabaseName(connectionString2, "GenericDatabase");
            return repl1 == repl2;
        }

        public static bool SplitProviderString(string providerString, out string provider, out string connectionString)
        {
            var match = Regex.Match(providerString, @"(.*)\:\/\/(.*)");
            if (match.Success)
            {
                provider = match.Groups[1].Value;
                connectionString = match.Groups[2].Value;
                return true;
            }
            provider = null;
            connectionString = null;
            return false;
        }
    }
}
