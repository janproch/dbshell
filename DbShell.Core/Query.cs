using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using DbShell.Common;
using DbShell.Core.RazorModels;
using DbShell.Core.Utility;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Core
{
    /// <summary>
    /// Represents query reading data from database. Can be exported to file in the some way as table.
    /// </summary>
    [ContentProperty("Text")]
    public class Query : ElementBase, ITabularDataSource, IListProvider, IEnumerable, IModelProvider
    {
        /// <summary>
        /// Gets or sets the query text.
        /// </summary>
        /// <value>
        /// The query text. This text cannot contain GO separated commands. It should be query returning one result set (eg. table)
        /// </value>
        public string Text { get; set; }

        private TableInfo GetRowFormat()
        {
            using (var conn = Connection.Connect())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = Replace(Text);
                using (var reader = cmd.ExecuteReader(CommandBehavior.KeyInfo | CommandBehavior.SchemaOnly))
                {
                    return reader.GetTableInfo();
                }
            }
        }

        TableInfo ITabularDataSource.GetRowFormat()
        {
            return GetRowFormat();

        }

        ICdlReader ITabularDataSource.CreateReader()
        {
            var dda = Connection.Factory.CreateDataAdapter();
            var conn = Connection.Connect();
            var cmd = conn.CreateCommand();
            cmd.CommandTimeout = 3600;
            cmd.CommandText = Replace(Text);
            var reader = cmd.ExecuteReader();
            var result = dda.AdaptReader(reader);
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

        IEnumerable IListProvider.GetList()
        {
            using (var reader = ((ITabularDataSource)this).CreateReader())
            {
                while (reader.Read())
                {
                    yield return reader;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IListProvider) this).GetList().GetEnumerator();
        }

        object IModelProvider.GetModel()
        {
            return this;
        }

        void IModelProvider.InitializeTemplate(IRazorTemplate template)
        {
            template.TabularData = this;
        }
    }
}
