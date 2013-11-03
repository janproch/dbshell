using System.Collections.Generic;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
    public abstract class ColumnsConstraintInfo : TableObjectInfo
    {
        private List<ColumnReference> _columns = new List<ColumnReference>();

        [XmlCollection(typeof(ColumnReference))]
        public List<ColumnReference> Columns { get { return _columns; } }

        public ColumnsConstraintInfo(TableInfo table)
            :base(table)
        {
            
        }

        protected override void Assign(DatabaseObjectInfo source)
        {
            base.Assign(source);
            var src = (ColumnsConstraintInfo) source;
            foreach(var col in src.Columns)
            {
                Columns.Add(col.Clone());
            }
        }

        public override void AfterLoadLink()
        {
            base.AfterLoadLink();

            foreach (var col in Columns)
            {
                col.AfterLoadLink(OwnerTable);
            }
        }
    }
}