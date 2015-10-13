using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace DbShell.RelatedDataSync
{
    [ContentProperty(nameof(Columns))]
    public class TargetReference
    {
        [XamlProperty]
        public List<TargetReferenceColumn> Columns { get; private set; } = new List<TargetReferenceColumn>();

        [XamlProperty]
        public string Target { get; set; }

        [XamlProperty]
        public bool IsKey { get; set; }
    }
}
