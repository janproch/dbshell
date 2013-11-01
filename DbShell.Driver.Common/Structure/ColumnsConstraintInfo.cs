using System.Collections.Generic;

namespace DbShell.Driver.Common.Structure
{
    public abstract class ColumnsConstraintInfo : TableObjectInfo
    {
        private List<ColumnReference> _columns = new List<ColumnReference>();
        public List<ColumnReference> Columns { get { return _columns; } }

        public ColumnsConstraintInfo(TableInfo table)
            :base(table)
        {
            
        }
    }
}