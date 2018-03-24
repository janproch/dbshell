using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using DbShell.Driver.Common.Interfaces;

namespace DbShell.Core
{
    /// <summary>
    /// Remaps input data using given column map
    /// </summary>
    public class ColumnMapper : ElementBase, ITabularDataSource, IModelProvider
    {
        /// <summary>
        /// Gets or sets the column map
        /// </summary>
        /// <value>
        /// The column map.
        /// </value>
        [XamlProperty]
        public List<IColumnMapping> ColumnMap { get; set; }

        /// <summary>
        /// Data source to be transformed
        /// </summary>
        [XamlProperty]
        public ITabularDataSource Source { get; set; }

        public ColumnMapper()
        {
            ColumnMap = new List<IColumnMapping>();
        }

        public TableInfo GetRowFormat(IShellContext context)
        {
            var counts = new List<int>();
            return GetRowFormat(counts, context);
        }

        private TableInfo GetRowFormat(List<int> counts, IShellContext context)
        {
            var table = Source.GetRowFormat(context);

            var targetTable = table;

            targetTable = new TableInfo(null);
            foreach (var mapItem in ColumnMap)
            {
                var newCols = mapItem.GetOutputColumns(table, context);
                counts.Add(newCols.Length);
                targetTable.Columns.AddRange(newCols);
            }

            return targetTable;
        }

        //public override void EnumChildren(Action<IShellElement> enumFunc)
        //{
        //    base.EnumChildren(enumFunc);

        //    YieldChild(enumFunc, Source);

        //    foreach (var item in ColumnMap) YieldChild(enumFunc, item);
        //}

        ICdlReader ITabularDataSource.CreateReader(IShellContext context)
        {
            var counts = new List<int>();
            var outputFormat = GetRowFormat(counts, context);
            return new ColumnMapperReader(Source.CreateReader(context), outputFormat, ColumnMap, counts, context);
        }

        DataFormatSettings ITabularDataSource.GetSourceFormat(IShellContext context)
        {
            return null;
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
