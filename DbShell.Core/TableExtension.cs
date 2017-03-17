#if !NETCOREAPP1_1

using DbShell.Driver.Common.Structure;
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
            var ident = StructuredIdentifier.Parse(name);

            if (ident.Count == 2)
            {
                Schema = ident[0];
                Name = ident[1];
            }
            else
            {
                Name = ident.Last;
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

#endif