namespace DbShell.Driver.Common.Structure
{
    public class PrimaryKeyInfo : ColumnsConstraintInfo
    {
        public string ConstraintName;

        public PrimaryKeyInfo(TableInfo table)
            :base(table)
        {
            
        }
    }
}