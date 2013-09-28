using System.Collections.Generic;

namespace DbShell.Driver.Common.Structure
{
    public enum ForeignKeyAction
    {
        Undefined,
        NoAction,
        Cascade,
        Restrict,
        SetNull
    };

    public class ForeignKeyInfo : ColumnsConstraintInfo
    {
        public string ConstraintName;
        public ForeignKeyAction OnUpdateAction;
        public ForeignKeyAction OnDeleteAction;

        private List<ColumnReference> _refColumns = new List<ColumnReference>();

        public TableInfo RefTable { get; set; }
        public List<ColumnReference> RefColumns { get { return _refColumns; } }

        public ForeignKeyInfo(TableInfo table)
            :base(table)
        {
            
        }
    }
}