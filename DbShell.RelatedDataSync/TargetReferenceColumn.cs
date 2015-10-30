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
        [XamlProperty]
        public string BaseName { get; set; }

        [XamlProperty]
        public string RefName { get; set; }
    }
}