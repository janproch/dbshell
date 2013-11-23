using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
    public abstract class SpecificObjectInfo : NamedObjectInfo
    {
        [XmlElem]
        public string CreateSql { get; set; }

        protected SpecificObjectInfo(DatabaseInfo database)
            : base(database)
        {
        }

        public override void Assign(DatabaseObjectInfo source)
        {
            base.Assign(source);
            var src = (SpecificObjectInfo) source;
            CreateSql = src.CreateSql;
        }

        public SpecificObjectInfo CloneSpecificObject(DatabaseInfo ownerDb = null)
        {
            return CloneObject(ownerDb) as SpecificObjectInfo;
        }
    }
}
