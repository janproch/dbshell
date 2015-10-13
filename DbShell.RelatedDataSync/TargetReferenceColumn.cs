using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace DbShell.RelatedDataSync
{
    public class TargetReferenceColumn
    {
        [XmlProperty]
        public string BaseName { get; set; }

        [XmlProperty]
        public string RefName { get; set; }
    }
}