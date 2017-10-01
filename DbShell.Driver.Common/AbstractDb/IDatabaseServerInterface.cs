using DbShell.Driver.Common.Structure;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.AbstractDb
{
    public class DatabaseOverviewInfo
    {
        public string CustomData1; // to allow hacks :-)

        public string Name;
        public long RowSizeKB;
        public long LogSizeKB;
        public string Collation;
        public string RecoveryModel;
        public string Concurrency;

        public override int GetHashCode()
        {
            unchecked
            {
                return Name.GetHashCode()
                    + RowSizeKB.GetHashCode()
                    + LogSizeKB.GetHashCode()
                    + Collation.GetHashCode()
                    + RecoveryModel.GetHashCode()
                    + Concurrency.GetHashCode();
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is DatabaseOverviewInfo other)
            {
                if (Name != other.Name) return false;
                if (RowSizeKB != other.RowSizeKB) return false;
                if (LogSizeKB != other.LogSizeKB) return false;
                if (Collation != other.Collation) return false;
                if (RecoveryModel != other.RecoveryModel) return false;
                if (Concurrency != other.Concurrency) return false;
                return true;
            }
            return base.Equals(obj);
        }
    }

    public interface IDatabaseServerInterface
    {
        DbConnection Connection { get; set; }
        DatabaseServerVersion GetVersion();
        List<DatabaseOverviewInfo> GetDatabaseList(bool includeDetails, LinkedDatabaseInfo linkedInfo = null);
    }
}
