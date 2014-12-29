using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Sql;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using log4net;

namespace DbShell.Driver.Common.AbstractDb
{
    public class BulkInserterBase : IBulkInserter
    {
        private readonly static ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public TableInfo DestinationTable { get; set; }

        public int BatchSize { get; set; }
        public string DatabaseName { get; set; }

        public DbConnection Connection { get; set; }
        public CopyTableTargetOptions CopyOptions { get; set; }
        public IDatabaseFactory Factory { get; set; }
        public LinkedDatabaseInfo LinkedInfo { get; set; }
        public DataFormatSettings SourceDataFormat { get; set; }

        public BulkInserterBase()
        {
            BatchSize = 100;
            CopyOptions = new CopyTableTargetOptions();
        }

        #region IBulkInserter Members

        public virtual void Run(ICdlReader reader)
        {
            var toDb = new RecordToDbAdapter(DestinationTable, Factory, SourceDataFormat ?? new DataFormatSettings());
            var adapter = new CdlReaderToDbAdapter(toDb, reader);
            BeforeRun();
            if (CopyOptions.AllowBulkCopy)
            {
                RunBulkCopy(adapter);
            }
            else
            {
                RunInserts(adapter);
            }
            AfterRun();
        }

        #endregion

        protected virtual void BeforeRun()
        {
            if (CopyOptions.TruncateBeforeCopy)
            {
                try
                {
                    Connection.RunScript(dmp => dmp.TruncateTable(DestinationTable.FullName));
                }
                catch (Exception err)
                {
                    //_log.Error(String.Format("Error truncating table {0}", DestinationTable), err);
                    LogError(String.Format("Error truncating table:{0}", err.Message));
                }
            }
            if (CopyOptions.DisableConstraints)
            {
                Connection.RunScript(dmp => dmp.EnableConstraints(DestinationTable.FullName, false));
            }
        }

        protected virtual void AfterRun()
        {
            if (CopyOptions.DisableConstraints)
            {
                Connection.RunScript(dmp => dmp.EnableConstraints(DestinationTable.FullName, true));
            }
        }

        protected bool HasIdentity(ICdlReader reader)
        {
            var ts = reader.Structure;
            var dst_ts = DestinationTable;

            var autoinc = dst_ts.FindAutoIncrementColumn();
            bool hasident = false;
            if (autoinc != null)
            {
                if (ts.Columns.Count != dst_ts.Columns.Count)
                {
                    // determine whether auto-inc column is inserted
                    hasident = ts.Columns.IndexOfIf(col => col.Name == autoinc.Name) >= 0;
                }
                else
                {
                    hasident = true;
                }
            }
            return hasident;
        }

        protected virtual void RunInserts(ICdlReader reader)
        {
            //Connection.SystemConnection.SafeChangeDatabase(DatabaseName);
            var dda = Connection.GetFactory().CreateDataAdapter();
            using (DbCommand inscmd = Connection.CreateCommand())
            {
                List<string> colnames = new List<string>();
                List<string> vals = new List<string>();
                var ts = reader.Structure;
                var dst_ts = DestinationTable;
                foreach (var col in ts.Columns)
                {
                    vals.Add("{" + colnames.Count.ToString() + "}");
                    colnames.Add(col.Name);
                }
                string[] values = new string[colnames.Count];
                NameWithSchema table = DestinationTable.FullName;
                string insertTemplate = SqlDumper.Format(Connection.GetFactory(), "^insert ^into %f (%,i) ^values (%,s)", table, colnames, vals);

                bool hasident = HasIdentity(reader);

                DbTransaction trans = Connection.BeginTransaction();
                inscmd.Transaction = trans;

                int okRowCount = 0, failRowCount = 0;
                List<string> insertErrors = new List<string>();
                try
                {
                    if (hasident) Connection.RunScript(dmp => { dmp.AllowIdentityInsert(table, true); }, trans);
                    try
                    {
                        int rowcounter = 0;
                        while (reader.Read())
                        {
                            rowcounter++;
                            var row = reader;
                            for (int i = 0; i < row.FieldCount; i++)
                            {
                                row.ReadValue(i);
                                values[i] = dda.GetSqlLiteral(row, new DbTypeString());
                            }
                            inscmd.CommandText = String.Format(insertTemplate, values);

                            if (rowcounter > 10000)
                            {
                                // next transaction
                                trans.Commit();
                                trans.Dispose();
                                trans = Connection.BeginTransaction();
                                inscmd.Transaction = trans;
                                rowcounter = 0;
                            }
                            try
                            {
                                inscmd.ExecuteNonQuery();
                                okRowCount++;
                            }
                            catch (Exception err)
                            {
                                if (insertErrors.Count < 10)
                                {
                                    StringBuilder msg = new StringBuilder();
                                    msg.Append(err.Message);
                                    insertErrors.Add(msg.ToString());
                                }
                                failRowCount++;
                            }
                        }
                    }
                    finally
                    {
                        if (hasident) Connection.RunScript(dmp => { dmp.AllowIdentityInsert(table, false); }, trans);
                    }
                    trans.Commit();

                    if (failRowCount > 0)
                    {
                        LogError(String.Format("Error inserting into table {0}, correct inserts {1}, failed inserts {2}", DestinationTable, okRowCount, failRowCount));
                        LogError(insertErrors.CreateDelimitedText("\n"));
                    }
                    else
                    {
                        LogInfo(String.Format("{0} rows successfully inserted into table {1}", okRowCount, DestinationTable));
                    }
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        protected virtual void RunBulkCopy(ICdlReader reader)
        {
            RunInserts(reader);
        }

        public event Action<LogRecord> Log;

        protected void LogInfo(string msg)
        {
            DoLog(new LogRecord
                {
                    Message = msg,
                    Severity = LogSeverity.Info,
                });
        }

        protected void LogError(string msg)
        {
            DoLog(new LogRecord
            {
                Message = msg,
                Severity = LogSeverity.Error,
            });
        }

        protected void DoLog(LogRecord rec)
        {
            switch (rec.Severity)
            {
                case LogSeverity.Info:
                    _log.Info(rec.Message);
                    break;
                case LogSeverity.Error:
                    _log.Error(rec.Message);
                    break;
            }
            if (Log!=null)
            {
                Log(rec);
            }
        }
    }
}
