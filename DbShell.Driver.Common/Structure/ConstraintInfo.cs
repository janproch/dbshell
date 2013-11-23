using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
    public abstract class ConstraintInfo : TableObjectInfo
    {
        [XmlAttrib("constraint_name")]
        public string ConstraintName { get; set; }

        protected ConstraintInfo(TableInfo ownerTable)
            : base(ownerTable)
        {
        }

        public override void Assign(DatabaseObjectInfo source)
        {
            base.Assign(source);
            var src = (ConstraintInfo) source;
            ConstraintName = src.ConstraintName;
        }

        public ConstraintInfo CloneConstraint(TableInfo ownerTable = null)
        {
            return CloneObject(ownerTable) as ConstraintInfo;
        }
    }
}
