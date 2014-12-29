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
        [XamlProperty]
        public ITabularDataSource Source { get; set; }

        /// <summary>
        /// Expression to obtain source of copy operation
        /// </summary>
        [XamlProperty]
        public string SourceExpression { get; set; }

        /// <summary>
        /// Target of data operation
        /// </summary>
        /// <value>
        /// Table or data file
        /// </value>
        [XamlProperty]
        public ITabularDataTarget Target { get; set; }

        /// <summary>
        /// Expression to obtain source of copy operation
        /// </summary>
        [XamlProperty]
        public string TargetExpression { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether clean target table before copying
        /// </summary>
        /// <value>
        ///   <c>true</c> if clean target; otherwise, <c>false</c>. Default is <c>false</c>
        /// </value>
        [XamlProperty]
        public bool CleanTarget { get; set; }


        /// <summary>
        /// Gets or sets the column map. If ColumnMap is empty (no mappings are defined), identity column map is used
        /// </summary>
        /// <value>
        /// The column map.
        /// </value>
        [XamlProperty]
        public List<IColumnMapping> ColumnMap { get; set; }

        protected override void DoRun(IShellContext context)
        {
            ITabularDataSource source;
            ITabularDataTarget target;

            if (Source != null && SourceExpression != null) throw new Exception("DBSH-00087 CopyTable: Both Source and SourceExpression are set");
            if (Source == null && SourceExpression == null) throw new Exception("DBSH-00088 CopyTable: None Source and SourceExpression are set");
            if (Target != null && TargetExpression != null) throw new Exception("DBSH-00089 CopyTable: Both Target and TargetExpression are set");
            if (Target == null && TargetExpression == null) throw new Exception("DBSH-00090 CopyTable: None Target and TargetExpression are set");

            if (SourceExpression != null)
            {
                source = (ITabularDataSource) context.Evaluate(SourceExpression);
            }
            else
            {
                source = Source;
            }

            if (TargetExpression != null)
            {
                target = (ITabularDataTarget) context.Evaluate(TargetExpression);
            }
            else
            {
                target = Target;
            }

            var options = new CopyTableTargetOptions
                {
                    TruncateBeforeCopy = CleanTarget,
                };

            var table = source.GetRowFormat(context);

            _log.InfoFormat("Copy table data {0}=>{1}", Source, Target);
            context.OutputMessage(String.Format("Copy table data {0}=>{1}", Source, Target));

            var targetTable = table;
            var counts = new List<int>();
            if (ColumnMap.Count > 0)
            {
                targetTable = new TableInfo(null);
                foreach (var mapItem in ColumnMap)
                {
                    var newCols = mapItem.GetOutputColumns(table, context);
                    counts.Add(newCols.Length);
                    targetTable.Columns.AddRange(newCols);
                }
            }

            using (var reader = source.CreateReader(context))
            {
                using (var writer = target.CreateWriter(targetTable, options, context, source.GetSourceFormat(context)))
                {
                    int rowNumber = 0;
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
                                    map.ProcessMapping(j, rowNumber, reader, outputRecord, context);
                                }
                            }
                            writer.Write(outputRecord);
                        }
                        else
                        {
                            writer.Write(reader);
                        }
                        rowNumber++;
                    }
                }
            }
        }

        //public override void EnumChildren(Action<IShellElement> enumFunc)
        //{
        //    base.EnumChildren(enumFunc);

        //    YieldChild(enumFunc, Source);
        //    YieldChild(enumFunc, Target);

        //    foreach (var item in ColumnMap) YieldChild(enumFunc, item);
        //}

        /// <summary>
        /// Initializes a new instance of the <see cref="CopyTable" /> class.
        /// </summary>
        public CopyTable()
        {
            ColumnMap = new List<IColumnMapping>();
        }
    }
}
