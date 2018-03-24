using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
#if !NETSTANDARD2_0
using System.Windows.Markup;
#endif
using DbShell.Driver.Common.Interfaces;
using DbShell.Core.RazorModels;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Core
{
    /// <summary>
    /// Represents query reading data from database. Can be exported to file in the some way as table.
    /// </summary>
#if !NETSTANDARD2_0
    [ContentProperty("Text")]
#endif
    public class Query : ElementBase, ITabularDataSource, IListProvider, IModelProvider
    {
        /// <summary>
        /// Gets or sets the query text.
        /// </summary>
        /// <value>
        /// The query text. This text cannot contain GO separated commands. It should be query returning one result set (eg. table)
        /// </value>
        [XamlProperty]
        public string Text { get; set; }

        private TableInfo GetRowFormat(IShellContext context)
        {
            using (var conn = GetConnectionProvider(context).Connect())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = context.Replace(Text);
                using (var reader = cmd.ExecuteReader(CommandBehavior.KeyInfo | CommandBehavior.SchemaOnly))
                {
                    return reader.GetTableInfo();
                }
            }
        }

        DataFormatSettings ITabularDataSource.GetSourceFormat(IShellContext context)
        {
            return null;
        }

        TableInfo ITabularDataSource.GetRowFormat(IShellContext context)
        {
            return GetRowFormat(context);

        }

        ICdlReader ITabularDataSource.CreateReader(IShellContext context)
        {
            var connection = GetConnectionProvider(context);
            var dda = connection.Factory.CreateDataAdapter();
            var conn = connection.Connect();
            var cmd = conn.CreateCommand();
            cmd.CommandTimeout = 3600;
            cmd.CommandText = context.Replace(Text);
            var reader = cmd.ExecuteReader();
            var result = dda.AdaptReader(reader, command: cmd);
            result.Disposing += () =>
                {
                    reader.Dispose();
                    conn.Dispose();
                };
            return result;
        }

        public override string ToString()
        {
            return String.Format("[Query {0}]", Text);
        }

        public override string ToStringCtx(IShellContext context)
        {
            return String.Format("[Query {0}]", context.Replace(Text));
        }

        IEnumerable IListProvider.GetList(IShellContext context)
        {
            using (var reader = ((ITabularDataSource)this).CreateReader(context))
            {
                while (reader.Read())
                {
                    yield return reader;
                }
            }
        }

        object IModelProvider.GetModel(IShellContext context)
        {
            return new QueryModel(this, context);
        }

        void IModelProvider.InitializeTemplate(IRazorTemplate template, IShellContext context)
        {
            template.TabularData = this;
        }
    }
}
