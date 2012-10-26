using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace DbShell.Core
{
    public class FileExtension : MarkupExtension
    {
        public FileExtension()
        {

        }

        public FileExtension(string name)
        {
            Name = name;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new File {Name = Name};
        }

        public string Name { get; set; }
    }
}
