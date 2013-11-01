namespace DbShell.Driver.Common.Structure
{
    public abstract class TableObjectInfo : DatabaseObjectInfo
    {
        public TableInfo OwnerTable { get; private set; }

        public TableObjectInfo(TableInfo table)
            : base(table == null ? null : table.OwnerDatabase)
        {
            OwnerTable = table;
        }
    }
}