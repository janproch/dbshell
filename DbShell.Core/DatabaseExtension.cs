using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace DbShell.Core
{
    /// <summary>
    /// Provides shortcut access to <see cref="DatabaseProvider"/> object. Use in Source property in <see cref="Razor"/>, Model="{Database}"
    /// </summary>
    public class DatabaseExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new DatabaseProvider();
        }
    }
}
