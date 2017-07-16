using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DbShell.Driver.Common.Structure
{
    [DataContract]
    public class FunctionInfo : ProgrammableInfo
    {
        [XmlElem]
        [DataMember]
        public string ResultType { get; set; }

        [XmlElem]
        [DataMember]
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
