using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace DbShell.Core
{
    public class TableExtension : MarkupExtension
    {
        public TableExtension()
        {

        }

        public TableExtension(string name)
        {
            Name = name;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new Table {Name = Name};
        }

        public string Name { get; set; }
    }
}
