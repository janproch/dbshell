using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Markup;

namespace DbShell.Core
{
    /// <summary>
    /// Provides shortcut access to <see cref="Table"/> object. Use in XAML attribute as Source="{Table dbo.Genres}" .
    /// </summary>
    public class TableExtension : MarkupExtension
    {
        public TableExtension()
        {

        }

        public TableExtension(string name)
        {
            var m = Regex.Match(name, @"([^\.]+)\.(.*)");
            if (m.Success)
            {
                Schema = m.Groups[1].Value;
                Schema = m.Groups[2].Value;
            }
            else
            {
                Name = name;
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new Table {Name = Name};
        }

        /// <summary>
        /// Gets or sets the table name.
        /// </summary>
        /// <value>
        /// The table name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the table schema.
        /// </summary>
        /// <value>
        /// The table schema.
        /// </value>
        public string Schema { get; set; }
    }
}
