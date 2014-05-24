using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfDelete : DmlfBase
    {
        [XmlSubElem]
        public DmlfSource DeleteTarget { get; set; }

        [XmlSubElem]
        public List<DmlfFromItem> From { get; set; }

        [XmlSubElem]
        public DmlfWhere Where { get; set; }
    }
}
