using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DbShell.Driver.Common.Structure
{
    public class DatabaseConnectionInfoHolder
    {
        public string ConnectionString;
        public string ProviderString;
        public string ProviderName;
        public LinkedDatabaseInfo LinkedInfo;
        public string ExplicitDatabaseName;
        public string LinkedServerName;
        public string LinkedDatabaseName;
    }

    public class NormalizedDatabaseConnectionInfo
    {
        public NormalizedDatabaseConnectionInfo(DatabaseConnectionInfoHolder holder)
        {
            if (!String.IsNullOrEmpty(holder.ProviderString))
            {
                ConnectionStringTool.SplitProviderString(holder.ProviderString, out ProviderName, out holder.ConnectionString);
            }
            if (!String.IsNullOrEmpty(holder.ProviderName))
            {
                ProviderName = holder.ProviderName;
            }
            if (!String.IsNullOrEmpty(holder.ConnectionString))
            {
                LocalDatabaseName = ConnectionStringTool.ExtractDatabaseName(holder.ConnectionString);
                ServerConnectionString = ConnectionStringTool.RemoveDatabaseName(holder.ConnectionString);
            }

            if (!String.IsNullOrEmpty(holder.LinkedDatabaseName))
            {
                LinkedDatabaseName = holder.LinkedDatabaseName;
            }
            if (!String.IsNullOrEmpty(holder.LinkedServerName))
            {
                LinkedServerName = holder.LinkedServerName;
            }
            if (!String.IsNullOrEmpty(holder.ExplicitDatabaseName))
            {
                LocalDatabaseName = holder.ExplicitDatabaseName;
            }

            if (!String.IsNullOrEmpty(holder.LinkedInfo?.LinkedDatabaseName))
            {
                LinkedDatabaseName = holder.LinkedInfo?.LinkedDatabaseName;
            }
            if (!String.IsNullOrEmpty(holder.LinkedInfo?.LinkedServerName))
            {
                LinkedServerName = holder.LinkedInfo?.LinkedServerName;
            }
            if (!String.IsNullOrEmpty(holder.LinkedInfo?.ExplicitDatabaseName))
            {
                LocalDatabaseName = holder.LinkedInfo?.ExplicitDatabaseName;
            }

            // fix
            if (String.IsNullOrEmpty(LinkedServerName)) LinkedDatabaseName = null;
            if (String.IsNullOrEmpty(LinkedDatabaseName)) LinkedServerName = null;
            if (!String.IsNullOrEmpty(LinkedServerName)) LocalDatabaseName = null;
        }

        public LinkedDatabaseInfo GetLinkedInfo()
        {
            if (LinkedServerName != null) return new LinkedDatabaseInfo(LinkedServerName, LinkedDatabaseName);
            if (LocalDatabaseName != null) return new LinkedDatabaseInfo(LocalDatabaseName);
            return null;
        }

        public readonly string ServerConnectionString;
        public readonly string ProviderName;
        public readonly string LocalDatabaseName;
        public readonly string LinkedServerName;
        public readonly string LinkedDatabaseName;

        public string DbSpecifierString => LocalDatabaseName ?? $"{LinkedServerName}/{LinkedDatabaseName}";
        public string UniqueName => $"{ProviderName}://{ServerConnectionString}/{DbSpecifierString}";
        public override int GetHashCode() => UniqueName.GetHashCode();
        public override string ToString() => UniqueName;

        public override bool Equals(object obj)
        {
            var other = obj as NormalizedDatabaseConnectionInfo;
            if (other != null) return UniqueName == other.UniqueName;
            return false;
        }

        public static bool operator ==(NormalizedDatabaseConnectionInfo a, NormalizedDatabaseConnectionInfo b)
        {
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return ReferenceEquals(a, b);
            return a.UniqueName == b.UniqueName;
        }

        public static bool operator !=(NormalizedDatabaseConnectionInfo a, NormalizedDatabaseConnectionInfo b)
        {
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return !ReferenceEquals(a, b);
            return !(a == b);
        }

    }
}
