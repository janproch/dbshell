using DbShell.Common;
using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace DbShell.RelatedDataSync
{
    [ContentProperty(nameof(Columns))]
    public class Source
    {
        [XamlProperty]
        public ITabularDataSource DataSource { get; set; }

        public List<SourceColumn> Columns { get; private set; } = new List<SourceColumn>();
    }
}
