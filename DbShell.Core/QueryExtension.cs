#if !NETSTANDARD1_5
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace DbShell.Core
{
    /// <summary>
    /// Provides shortcut access to <see cref="TablesProvider"/> object. Use in Source property in <see cref="ForEach"/> or <see cref="CopyTable"/>.
    /// </summary>
    public class QueryExtension : MarkupExtension
    {
        public string Text;

        public QueryExtension(string text)
        {
            Text = text;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new Query {Text = Text};
        }
    }
}
#endif