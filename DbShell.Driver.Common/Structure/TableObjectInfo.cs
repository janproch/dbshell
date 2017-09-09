using System.Runtime.Serialization;

namespace DbShell.Driver.Common.Structure
{
    [DataContract]
    public abstract class TableObjectInfo : DatabaseObjectInfo
    {
        public TableInfo OwnerTable { get; internal set; }

        public TableObjectInfo(TableInfo table)
            : base(table == null ? null : table.OwnerDatabase)
        {
            OwnerTable = table;
        }

        public abstract void SetDummyTable(NameWithSchema name);

        [DataMember]
        public string OwnerTableName => OwnerTable?.Name;

        [DataMember]
        public string OwnerSchemaName => OwnerTable?.Schema;
    }
}