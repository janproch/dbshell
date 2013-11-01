using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.Structure
{
    public class StoredProcedureInfo : ProgrammableInfo
    {
        public StoredProcedureInfo(DatabaseInfo database)
            : base(database)
        {
        }

        public override DatabaseObjectType ObjectType
        {
            get { return DatabaseObjectType.Procedure; }
        }
    }
}
