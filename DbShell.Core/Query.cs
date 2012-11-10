using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using DbShell.Common;
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
    public class Query : ElementBase, ITabularDataSource
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
                cmd.CommandText = Context.Replace(Text);
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
            cmd.CommandText = Context.Replace(Text);
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
            return "QUERY:" + Text;
        }
    }
}
