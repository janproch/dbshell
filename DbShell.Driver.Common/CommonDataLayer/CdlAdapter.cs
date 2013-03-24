using System;
using System.Data.Common;
using System.Data;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.CommonDataLayer
{
    public class CdlAdapter
    {
        string m_queryTemplate;
        DbConnection m_conn;
        TableInfo m_structure;
        bool m_isFullTableSelect;
        DbCommand m_currentCommand;
        object m_currentCommandLock = new object();
        IDialectDataAdapter m_dda = GenericDialectDataAdapter.Instance;
        private IDatabaseFactory m_factory;

        public CdlAdapter(DbConnection conn, IDatabaseFactory factory, string queryTemplate, bool isFullTableSelect)
        {
            m_queryTemplate = queryTemplate;
            m_conn = conn;
            m_isFullTableSelect = isFullTableSelect;
            m_factory = factory;
            if (m_factory != null) m_dda = m_factory.CreateDataAdapter();
        }

        private bool HasMetaData { get { return m_structure != null; } }

        private void LoadMetaData(DbDataReader reader)
        {
            m_structure = reader.GetTableInfo();
        }

        private void WantMetadata()
        {
            if (HasMetaData) return;
            using (DbCommand cmd = m_conn.CreateCommand())
            {
                try
                {
                    lock (m_currentCommandLock) m_currentCommand = cmd;
                    cmd.CommandText = m_queryTemplate;
                    using (DbDataReader reader = cmd.ExecuteReader(CommandBehavior.SchemaOnly | CommandBehavior.KeyInfo))
                    {
                        LoadMetaData(reader);
                    }
                }
                finally
                {
                    lock (m_currentCommandLock) m_currentCommand = null;
                }
            }
        }

        public CdlTable LoadTableData(int? start, int? count, string queryInstance)
        {
            int skipcount = 0;
            if (start != null) skipcount = start.Value;

            string sql = queryInstance;

            //if (m_conn.Dialect.DialectCaps.RangeSelect && (skipcount > 0 || count != null))
            //{
            //    sql = m_conn.Dialect.GetRangeSelect(queryInstance, skipcount, count.Value);
            //    skipcount = 0;
            //}
            //else if (m_conn.Dialect.DialectCaps.LimitSelect && count != null)
            //{
            //    sql = m_conn.Dialect.GetLimitSelect(queryInstance, skipcount + count.Value);
            //}

            //WantMetadata();

            using (DbCommand cmd = m_conn.CreateCommand())
            {
                try
                {
                    lock (m_currentCommandLock) m_currentCommand = cmd;
                    cmd.CommandText = sql;
                    CommandBehavior behaviour = CommandBehavior.Default;
                    if (!HasMetaData) behaviour |= CommandBehavior.KeyInfo;
                    using (ICdlReader reader = m_dda.AdaptReader(cmd.ExecuteReader(behaviour)))
                    {
                        if (!HasMetaData) m_structure = reader.Structure;
                        if (m_structure == null) return null;
                        CdlTable res = new CdlTable(m_structure);
                        while (skipcount > 0)
                        {
                            if (!reader.Read()) return res;
                            skipcount--;
                        }

                        while (count == null || res.Rows.Count < count.Value)
                        {
                            if (!reader.Read()) return res;
                            res.AddRow(reader);
                        }

                        return res;
                    }
                }
                catch (Exception err)
                {
                    err.Data["sql"] = sql;
                    m_conn.FillInfo(err.Data);
                    throw;
                }
                finally
                {
                    lock (m_currentCommandLock) m_currentCommand = null;
                }
            }
        }

        public bool IsReadOnly { get { return !m_isFullTableSelect; } }
        public bool AllowDelete { get { return m_isFullTableSelect; } }
        public bool AllowUpdate { get { return m_isFullTableSelect; } }
        public bool AllowInsert { get { return m_isFullTableSelect; } }

        public void SaveChanges(CdlTable table, ISqlDumper dmp)
        {
            if (IsReadOnly) throw new InternalError("DBSH-00008 CdlAdapter is read only, can not save changes");
            SingleTableDataScript script = table.GetBaseModifyScript();
            MultiTableUpdateScript lscript = table.GetLinkedDataScript(m_structure.FullName);
            //if (progress != null)
            //{
            //    //script.ReportCounts(progress);
            //    lscript.ReportCounts(progress);
            //}
            dmp.UpdateData(m_structure, script);
            dmp.UpdateData(lscript);
        }

        public TableInfo GetStructure()
        {
            WantMetadata();
            return m_structure;
        }

        public void CancelLoading()
        {
            lock (m_currentCommandLock)
            {
                if (m_currentCommand != null) m_currentCommand.Cancel();
            }
        }

        public void SaveChanges(CdlTable table)
        {
            using (DbTransaction tran = m_conn.BeginTransaction())
            {
                try
                {
                    m_conn.RunScript(dmp => SaveChanges(table, dmp), tran);
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        public void LoadTableData(string queryInstance, Action<ICdlRecord> forEachRow)
        {
            string sql = queryInstance;
            using (DbCommand cmd = m_conn.CreateCommand())
            {
                try
                {
                    lock (m_currentCommandLock) m_currentCommand = cmd;
                    cmd.CommandText = sql;
                    CommandBehavior behaviour = CommandBehavior.Default;
                    if (!HasMetaData) behaviour |= CommandBehavior.KeyInfo;
                    using (ICdlReader reader = m_dda.AdaptReader(cmd.ExecuteReader(behaviour)))
                    {
                        if (!HasMetaData) m_structure = reader.Structure;
                        if (m_structure == null) return;

                        while (reader.Read())
                        {
                            forEachRow(reader);
                        }
                    }
                }
                catch (Exception err)
                {
                    err.Data["sql"] = sql;
                    m_conn.FillInfo(err.Data);
                    throw;
                }
                finally
                {
                    lock (m_currentCommandLock) m_currentCommand = null;
                }
            }
        }
    }
}
