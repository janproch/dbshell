using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;

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

        public TableInfo GetRowFormat()
        {
            var counts = new List<int>();
            return GetRowFormat(counts);
        }

        private TableInfo GetRowFormat(List<int> counts)
        {
            var table = Source.GetRowFormat();

            var targetTable = table;

            targetTable = new TableInfo(null);
            foreach (var mapItem in ColumnMap)
            {
                var newCols = mapItem.GetOutputColumns(table);
                counts.Add(newCols.Length);
                targetTable.Columns.AddRange(newCols);
            }

            return targetTable;
        }

        public override void EnumChildren(Action<IShellElement> enumFunc)
        {
            base.EnumChildren(enumFunc);

            YieldChild(enumFunc, Source);

            foreach (var item in ColumnMap) YieldChild(enumFunc, item);
        }

        public ICdlReader CreateReader()
        {
            var counts = new List<int>();
            var outputFormat = GetRowFormat(counts);
            return new ColumnMapperReader(Source.CreateReader(), outputFormat, ColumnMap, counts);
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
