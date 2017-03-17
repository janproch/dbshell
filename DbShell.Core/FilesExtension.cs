#if !NETCOREAPP1_1

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace DbShell.Core
{
    /// <summary>
    /// Provides shortcut access to <see cref="FilesProvider"/> object. Use in Source property in <see cref="ForEach"/>, Source="{Files 'c:/*.csv'}"
    /// </summary>
    public class FilesExtension : MarkupExtension
    {
        /// <summary>
        /// Filter of files, eg. c:\test\*.csv
        /// </summary>
        public string Filter { get; set; }

        public FilesExtension()
        {
        }

        public FilesExtension(string filter)
        {
            Filter = filter;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new FilesProvider
                {
                    Filter = Filter,
                };
        }
    }
}

#endif