using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using DbShell.Driver.Sqlite;

namespace DbShell.Core
{
    public class SqliteStorage : ITabularDataSource, IModelProvider
    {
        [XamlProperty]
        public string Identifier { get; set; }

        [XamlProperty]
        public string Query { get; set; }

        private Driver.Sqlite.SqliteStorage Storage
        {
            get { return Driver.Sqlite.SqliteStorage.GetFromDirectory(Identifier); }
        }

        DataFormatSettings ITabularDataSource.GetSourceFormat(IShellContext context)
        {
            return null;
        }

        TableInfo ITabularDataSource.GetRowFormat(IShellContext context)
        {
            return Storage.Structure;
        }

        ICdlReader ITabularDataSource.CreateReader(IShellContext context)
        {
            return Storage.CreateReader(Query);
        }

        object IModelProvider.GetModel(IShellContext context)
        {
            return this;
        }

        void IModelProvider.InitializeTemplate(IRazorTemplate template, IShellContext context)
        {
            template.TabularData = this;
        }
    }
}
