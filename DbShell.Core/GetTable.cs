using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace DbShell.Core
{
    public class GetTable : MarkupExtension
    {
        public GetTable()
        {

        }

        public GetTable(string name)
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
