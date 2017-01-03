using System.Runtime.Serialization;
using System.Web.Script.Serialization;

namespace DbShell.Driver.Common.Structure
{
    [DataContract]
    public abstract class TableObjectInfo : DatabaseObjectInfo
    {
        public TableInfo OwnerTable { get; private set; }

        public TableObjectInfo(TableInfo table)
            : base(table == null ? null : table.OwnerDatabase)
        {
            OwnerTable = table;
        }

        public abstract void SetDummyTable(NameWithSchema name);
    }
}