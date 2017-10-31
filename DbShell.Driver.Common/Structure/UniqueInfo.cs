using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DbShell.Driver.Common.Structure
{
    [DataContract]
    public class UniqueInfo : ColumnsConstraintInfo
    {
        public UniqueInfo(TableInfo table)
            : base(table)
        {
        }

        public override DatabaseObjectType ObjectType
        {
            get { return DatabaseObjectType.Unique; }
        }

        public override void SetDummyTable(NameWithSchema name)
        {
            var table = new TableInfo(null);
            table.FullName = name;
            table.Uniques.Add(this);
        }

        public UniqueInfo CloneUnique(TableInfo ownTable = null)
        {
            var res = new UniqueInfo(ownTable ?? OwnerTable);
            res.Assign(this);
            return res;
        }

        public override DatabaseObjectInfo CloneObject(DatabaseObjectInfo owner)
        {
            return CloneUnique(owner as TableInfo);
        }
    }
}
