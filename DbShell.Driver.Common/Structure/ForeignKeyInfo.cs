using System.Collections.Generic;

namespace DbShell.Driver.Common.Structure
{
    public class ForeignKeyInfo : ColumnsConstraintInfo
    {
        public string ConstraintName;

        private List<ColumnReference> _refColumns = new List<ColumnReference>();

        public TableInfo RefTable { get; set; }
        public List<ColumnReference> RefColumns { get { return _refColumns; } }

        public ForeignKeyInfo(TableInfo table)
            :base(table)
        {
            
        }
    }
}