namespace DbShell.Driver.Common.Structure
{
    public class TableObjectInfo : DatabaseObjectInfo
    {
        public TableInfo OwnerTable { get; private set; }

        public TableObjectInfo(TableInfo table)
            : base(table == null ? null : table.OwnerDatabase)
        {
            OwnerTable = table;
        }
    }
}