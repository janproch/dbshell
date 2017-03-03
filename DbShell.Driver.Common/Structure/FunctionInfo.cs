using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.Structure
{
    public class FunctionInfo : ProgrammableInfo
    {
        [XmlElem]
        public string ResultType { get; set; }

        [XmlElem]
        public bool HasTableResult { get; set; }

        public FunctionInfo(DatabaseInfo database)
            : base(database)
        {
        }

        public override DatabaseObjectType ObjectType
        {
            get { return DatabaseObjectType.Function; }
        }

        public FunctionInfo CloneFunction(DatabaseInfo ownerDb = null)
        {
            var res = new FunctionInfo(ownerDb ?? OwnerDatabase);
            res.Assign(this);
            res.ResultType = ResultType;
            res.HasTableResult = HasTableResult;
            return res;
        }

        public override DatabaseObjectInfo CloneObject(DatabaseObjectInfo owner)
        {
            return CloneFunction(owner as DatabaseInfo);
        }
    }
}
