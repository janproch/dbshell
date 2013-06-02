using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.RazorModels;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Core.Utility
{
    /// <summary>
    /// Table in database
    /// </summary>
    public abstract class TableOrView : ElementBase, ITabularDataSource, ITabularDataTarget, IListProvider, IEnumerable, IModelProvider
    {
        /// <summary>
        /// Table schema, can be ommited (eg. "dbo" on SQL server)
        /// </summary>
        public string Schema { get; set; }

        /// <summary>
        /// Table name
        /// </summary>
        public string Name { get; set; }

        protected abstract TableInfo GetRowFormat();

        protected NameWithSchema GetFullName()
        {
            return new NameWithSchema(Replace(Schema), Replace(Name));
        }

        TableInfo ITabularDataSource.GetRowFormat()
        {
            return GetRowFormat();

        }

        ICdlReader ITabularDataSource.CreateReader()
        {
            var fullName = GetFullName();
            var dda = Connection.Factory.CreateDataAdapter();
            var conn = Connection.Connect();
            var cmd = conn.CreateCommand();
            var dialect = Connection.Factory.CreateDialect();
            cmd.CommandText = "SELECT * FROM " + dialect.QuoteFullName(fullName);
            var reader = cmd.ExecuteReader();
            var result = dda.AdaptReader(reader);
            result.Disposing += () =>
            {
                reader.Dispose();
                conn.Dispose();
            };
            return result;
        }


        bool ITabularDataTarget.AvailableRowFormat
        {
            get { return true; }
        }

        ICdlWriter ITabularDataTarget.CreateWriter(TableInfo rowFormat, CopyTableTargetOptions options)
        {
            return new TableWriter(Connection, GetFullName(), rowFormat, options);
        }

        TableInfo ITabularDataTarget.GetRowFormat()
        {
            return GetRowFormat();
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
            return ((IListProvider)this).GetList().GetEnumerator();
        }

        object IModelProvider.GetModel()
        {
            return this;
        }

        void IModelProvider.InitializeTemplate(IRazorTemplate template)
        {
            template.TabularData = this;
            template.Name = Name;
            template.Schema = Schema;
        }
    }
}
