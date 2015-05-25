using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.ChangeSet
{
    public abstract class ChangeSetItem
    {
        [XmlElem]
        public NameWithSchema TargetTable { get; set; }

        [XmlSubElem]
        public LinkedDatabaseInfo LinkedInfo { get; set; }
    }
}
