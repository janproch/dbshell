using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace DbShell.RelatedDataSync
{
    [ContentProperty(nameof(Name))]
    public class ColumnName
    {
        public string Name { get; set; }
    }
}
