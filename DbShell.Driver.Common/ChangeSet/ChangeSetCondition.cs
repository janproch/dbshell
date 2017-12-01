using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using DbShell.Driver.Common.Utility;
using System.Runtime.Serialization;

namespace DbShell.Driver.Common.ChangeSet
{
    [DataContract]
    public class ChangeSetCondition
    {
        [XmlElem]
        [DataMember]
        public string Column { get; set; }

        [XmlElem]
        [DataMember]
        public string Expression { get; set; }

        [XmlElem]
        [DataMember]
        public string ValueToBeEqual { get; set; }

        public string UsedExpression => ValueToBeEqual != null ? $"='{ValueToBeEqual}'"  : Expression;
    }
}
