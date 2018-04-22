using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Interfaces;
using DbShell.Driver.Common.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Driver.Sqlite
{
    public class SqliteStorageSubset : ITabularDataSource, IModelProvider
    {
        public string Identifier { get; set; }

        public string Query { get; set; }

        public int[] ColumnSubset { get; set; }

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
            return Storage.Structure.CreateColumnSubset(ColumnSubset);
        }

        ICdlReader ITabularDataSource.CreateReader(IShellContext context)
        {
            return Storage.CreateReader(Query, ColumnSubset);
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
