using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace DbShell.RelatedDataSync
{
    [ContentProperty(nameof(Columns))]
    public class Target
    {
        [XamlProperty]
        public string TableSchema { get; set; }

        [XamlProperty]
        public string TableName { get; set; }

        [XamlProperty]
        public string PrimarySource { get; set; }

        public List<TargetColumn> Columns { get; private set; } = new List<TargetColumn>();
    }
}
