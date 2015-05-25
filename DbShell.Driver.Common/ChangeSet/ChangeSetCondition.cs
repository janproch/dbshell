using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.ChangeSet
{
    public class ChangeSetCondition
    {
        [XmlElem]
        public string Column { get; set; }

        [XmlElem]
        public string Expression { get; set; }
    }
}
