using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.Structure
{
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
        }
    }
}
