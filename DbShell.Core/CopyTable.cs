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
using log4net;

namespace DbShell.Core
{
    /// <summary>
    /// Process, which copies table data (possibly with structure)
    /// </summary>
    public class CopyTable : RunnableBase
    {
        private static ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Source of copy operation
        /// </summary>
        /// <value>
        /// Table or data file
        /// </value>
        public ITabularDataSource Source { get; set; }

        /// <summary>
        /// Target of data operation
        /// </summary>
        /// <value>
        /// Table or data file
        /// </value>
        public ITabularDataTarget Target { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether clean target table before copying
        /// </summary>
        /// <value>
        ///   <c>true</c> if clean target; otherwise, <c>false</c>. Default is <c>false</c>
        /// </value>
        public bool CleanTarget { get; set; }


        /// <summary>
        /// Gets or sets the column map. If ColumnMap is empty (no mappings are defined), identity column map is used
        /// </summary>
        /// <value>
        /// The column map.
        /// </value>
        public List<IColumnMapping> ColumnMap { get; set; }

        protected override void DoRun()
        {
            var options = new CopyTableTargetOptions
                {
                    TruncateBeforeCopy = CleanTarget,
                };

            var table = Source.GetRowFormat();

            _log.InfoFormat("Copy table data {0}=>{1}", Source, Target);

            var targetTable = table;
            var counts = new List<int>();
            if (ColumnMap.Count > 0)
            {
                targetTable = new TableInfo(null);
                foreach (var mapItem in ColumnMap)
                {
                    var newCols = mapItem.GetOutputColumns(table);
                    counts.Add(newCols.Length);
                    targetTable.Columns.AddRange(newCols);
                }
            }

            using (var reader = Source.CreateReader())
            {
                using (var writer = Target.CreateWriter(targetTable, options))
                {
                    while (reader.Read())
                    {
                        if (ColumnMap.Count > 0)
                        {
                            var outputRecord = new ArrayDataRecord(targetTable);
                            int columnIndex = 0;
                            for (int i = 0; i < ColumnMap.Count; i++)
                            {
                                var map = ColumnMap[i];
                                int count = counts[i];
                                for (int j = 0; j < count; j++, columnIndex++)
                                {
                                    outputRecord.SeekValue(columnIndex);
                                    map.ProcessMapping(j, reader, outputRecord);
                                }
                            }
                            writer.Write(outputRecord);
                        }
                        else
                        {
                            writer.Write(reader);
                        }
                    }
                }
            }
        }

        public override void EnumChildren(Action<IShellElement> enumFunc)
        {
            base.EnumChildren(enumFunc);

            YieldChild(enumFunc, Source);
            YieldChild(enumFunc, Target);

            foreach(var item in ColumnMap) YieldChild(enumFunc, item);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CopyTable" /> class.
        /// </summary>
        public CopyTable()
        {
            ColumnMap = new List<IColumnMapping>();
        }
    }
}
