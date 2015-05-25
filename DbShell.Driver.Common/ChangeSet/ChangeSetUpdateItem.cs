using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.ChangeSet
{
    public class ChangeSetUpdateItem : ChangeSetItem
    {
        [XmlCollection(typeof (ChangeSetCondition))]
        public List<ChangeSetCondition> Conditions { get; set; }

        [XmlCollection(typeof (ChangeSetValue))]
        public List<ChangeSetValue> Values { get; set; }

        public ChangeSetUpdateItem()
        {
            Conditions = new List<ChangeSetCondition>();
            Values = new List<ChangeSetValue>();
        }
    }
}
