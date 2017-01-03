using System;
using System.Collections.Generic;
using System.Linq;
using DbShell.Driver.Common.Utility;
using System.Runtime.Serialization;

namespace DbShell.Driver.Common.Structure
{
    [DataContract]
    public abstract class ColumnsConstraintInfo : ConstraintInfo
    {
        private List<ColumnReference> _columns = new List<ColumnReference>();

        [XmlCollection(typeof(ColumnReference))]
        [DataMember]
        public List<ColumnReference> Columns { get { return _columns; } }

        public ColumnsConstraintInfo(TableInfo table)
            :base(table)
        {
            
        }

        public override void Assign(DatabaseObjectInfo source)
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

        public override string ToString()
        {
            string res = String.Format("{0}({1})", ConstraintName, Columns.Select(x => x.Name).CreateDelimitedText(","));
            if (OwnerTable != null && OwnerTable.FullName != null) res = OwnerTable.FullName.ToString() + "." + res;
            return res;
        }
    }
}