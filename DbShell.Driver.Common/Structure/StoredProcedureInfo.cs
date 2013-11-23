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
            get { return DatabaseObjectType.StoredProcedure; }
        }

        public StoredProcedureInfo CloneStoredProcedure(DatabaseInfo ownerDb = null)
        {
            var res = new StoredProcedureInfo(ownerDb ?? OwnerDatabase);
            res.Assign(this);
            return res;
        }

        public override DatabaseObjectInfo CloneObject(DatabaseObjectInfo owner)
        {
            return CloneStoredProcedure(owner as DatabaseInfo);
        }
    }
}
