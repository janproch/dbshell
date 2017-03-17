using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
#if !NETCOREAPP1_1
using System.Windows.Markup;
#endif
using DbShell.Common;
using DbShell.Core.RazorModels;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Core
{
    /// <summary>
    /// Represents query reading scalar value from database
    /// </summary>
#if !NETCOREAPP1_1
    [ContentProperty("Text")]
#endif
    public class QueryValue : RunnableBase
    {
        /// <summary>
        /// Gets or sets the query text.
        /// </summary>
        [XamlProperty]
        public string Text { get; set; }

        /// <value>
        /// The variable name to be set
        /// </value>
        [XamlProperty]
        public string Name { get; set; }

        protected override void DoRun(IShellContext context)
        {
            using (var conn = GetConnectionProvider(context).Connect())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = context.Replace(Text);
                object value = cmd.ExecuteScalar();
                context.SetVariable(context.Replace(Name), value);
            }
        }
    }
}
