using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.Structure
{
    public class IndexInfo : ColumnsConstraintInfo
    {
        public IndexInfo(TableInfo table)
            : base(table)
        {
        }

        public override DatabaseObjectType ObjectType
        {
            get { return DatabaseObjectType.Index; }
        }

        public override void SetDummyTable(NameWithSchema name)
        {
        }
    }
}
