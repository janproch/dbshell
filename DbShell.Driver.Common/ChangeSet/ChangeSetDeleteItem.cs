using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.ChangeSet
{
    public class ChangeSetDeleteItem : ChangeSetItem
    {
        [XmlCollection(typeof(ChangeSetCondition))]
        public List<ChangeSetCondition> Conditions { get; set; }

        public ChangeSetDeleteItem()
        {
            Conditions = new List<ChangeSetCondition>();
        }
    }
}
