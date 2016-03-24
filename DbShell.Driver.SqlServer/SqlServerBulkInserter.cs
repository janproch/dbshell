using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Utility;
using log4net;

namespace DbShell.Driver.SqlServer
{
    public class SqlServerBulkInserter : BulkInserterBase
    {
        private readonly static ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        protected override void RunBulkCopy(Common.CommonDataLayer.ICdlReader reader)
        {
            var ts = reader.Structure;

            bool forceInserts = false;
            if (ts.Columns.Count == 1)
            {
                // SqlBulkCopy has problems when running on tables with one column
                forceInserts = true; 
            }

            if (DestinationTable.Columns.Any(x => x.DataType?.ToLower()?.Contains("geo") ?? false))
            {
                // SqlBulkCopy deosn't support spatial types
                forceInserts = true;
            }

            if (forceInserts)
            { 
                RunInserts(reader);
                return;
            }
            var dialect = Factory.CreateDialect();
            using (SqlBulkCopy bcp = new SqlBulkCopy((SqlConnection)Connection, SqlBulkCopyOptions.KeepIdentity | SqlBulkCopyOptions.KeepNulls, null))
            {
                bcp.DestinationTableName = dialect.QuoteFullName(DestinationTable.FullName);

                foreach (var item in _columnMap.Items)
                {
                    var map = new SqlBulkCopyColumnMapping(item.Source, item.Target);
                    bcp.ColumnMappings.Add(map);
                }

                //var dst_ts = DestinationTable;

                //if (ts.Columns.Count < dst_ts.Columns.Count)
                //{
                //    int srcindex = 0;
                //    foreach (var src in ts.Columns)
                //    {
                //        SqlBulkCopyColumnMapping map = new SqlBulkCopyColumnMapping(srcindex, dst_ts.Columns.IndexOfIf(col => col.Name == src.Name));
                //        bcp.ColumnMappings.Add(map);
                //        srcindex++;
                //    }
                //}

                //int srcindex = 0;
                //foreach (var src in ts.Columns)
                //{
                //    int dstIndex = dst_ts.Columns.IndexOfIf(col => col.Name == src.Name);
                //    if (dstIndex < 0) continue;
                //    SqlBulkCopyColumnMapping map = new SqlBulkCopyColumnMapping(srcindex, dstIndex);
                //    bcp.ColumnMappings.Add(map);
                //    srcindex++;
                //}

                var readerAda = new CdlReaderAdapter();
                readerAda.Reader = reader;
                try
                {
                    bcp.BulkCopyTimeout = 0;
                    bcp.WriteToServer(readerAda);
                    LogInfo(String.Format("{0} rows inserted into table {1}", readerAda.ReadedRows, DestinationTable.FullName));
                    //ProgressInfo.LogMessage("INSERT", LogLevel.Info, Texts.Get("s_inserted_into_table$table$rows", "table", DestinationTable.FullName, "rows", readerAda.ReadedRows));
                }
                catch (Exception err)
                {
                    LogError($"DBSH-00200 Error inserting into table {DestinationTable.FullName}:{err.Message}");
                    _log.Error($"DBSH-00201 Error inserting into table {DestinationTable.FullName}", err);
                    //ILogger logger = ProgressInfo;
                    //if (err is QueueClosedError) logger = Logging.Root;
                    //logger.LogMessageDetail(
                    //    "INSERT", LogLevel.Error,
                    //    String.Format("{0}", Texts.Get("s_error_inserting_into_table$table", "table", DestinationTable.FullName)), err.ToString());
                    //throw;
                }
                finally
                {
                    readerAda.Close();
                }
            }
        }
    }
}
