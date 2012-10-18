using System;
using System.Data;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.CommonDataLayer
{
    public abstract class DataRecordAdapterBase : CdlValueHolder, ICdlRecord
    {
        protected IDataRecord m_record;
        protected TableInfo m_structure;

        #region IBedRecord Members

        public TableInfo Structure
        {
            get { return m_structure; }
        }

        public int FieldCount
        {
            get { return m_structure.Columns.Count; }
        }

        public int GetOrdinal(string colName)
        {
            return m_structure.Columns.GetIndex(colName);
        }

        public string GetName(int i)
        {
            return m_structure.Columns[i].Name;
        }

        public virtual void ReadValue(int i)
        {
            this.ReadFrom(m_record, i);
        }

        public int GetValues(object[] data)
        {
            int cnt = Math.Min(data.Length, FieldCount);
            for (int i = 0; i < cnt; i++)
            {
                data[i] = this.GetValue(i);
            }
            return cnt;
        }

        #endregion
    }

    public class DataRecordAdapter : DataRecordAdapterBase
    {
        public DataRecordAdapter(IDataRecord record, TableInfo table)
        {
            m_record = record;
            m_structure = table;
        }

        public IDataRecord Record
        {
            get { return m_record; }
            set { m_record = value; }
        }

        public new TableInfo Structure
        {
            get { return m_structure; }
            set { m_structure = value; }
        }
    }

    public class DataReaderAdapter : DataRecordAdapterBase, ICdlReader
    {
        IDataReader m_reader;
        IDatabaseFactory m_factory;

        public bool DisposeReader = true;

        public DataReaderAdapter(IDataReader reader, IDatabaseFactory factory)
        {
            m_reader = reader;
            m_factory = factory;
            m_structure = reader.GetTableInfo();
        }

        #region ICdlReader Members

        public bool Read()
        {
            if (m_reader.Read())
            {
                m_record = m_reader;
                return true;
            }
            else
            {
                m_record = null;
                return false;
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (DisposeReader) m_reader.Dispose();
        }

        #endregion
    }
}
