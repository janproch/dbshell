using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace DbShell.Core
{
    /// <summary>
    /// Provides shortcut access to <see cref="TablesProvider"/> object. Use in Source property in <see cref="ForEach"/>, Source="{Tables}"
    /// </summary>
    public class TablesExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new TablesProvider();
        }
    }
}
