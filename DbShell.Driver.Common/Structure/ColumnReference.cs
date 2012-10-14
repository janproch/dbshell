namespace DbShell.Driver.Common.Structure
{
    public class ColumnReference
    {
        public ColumnInfo RefColumn { get; set; }

        public string Name
        {
            get
            {
                if (RefColumn == null) return null;
                return RefColumn.Name;
            }
        }
        //public string ColumnName { get; set; }
    }
}