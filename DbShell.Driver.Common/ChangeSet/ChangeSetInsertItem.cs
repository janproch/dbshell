using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.ChangeSet
{
    public class ChangeSetInsertItem : ChangeSetItem
    {
        [XmlCollection(typeof (ChangeSetValue))]
        public List<ChangeSetValue> Values { get; set; }

        public ChangeSetInsertItem()
        {
            Values = new List<ChangeSetValue>();
        }
    }
}
