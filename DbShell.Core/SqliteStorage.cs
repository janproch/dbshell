using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
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
        
        TableInfo ITabularDataSource.GetRowFormat()
        {
            return Storage.Structure;
        }

        ICdlReader ITabularDataSource.CreateReader()
        {
            return Storage.CreateReader(Query);
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
