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
        protected TableInfo _structure;

        #region IBedRecord Members

        public TableInfo Structure
        {
            get { return _structure; }
        }

        public int FieldCount
        {
            get { return _structure.Columns.Count; }
        }

        public int GetOrdinal(string colName)
        {
            return _structure.GetColumnIndex(colName);
        }

        public string GetName(int i)
        {
            return _structure.Columns[i].Name;
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
            _structure = table;
        }

        public IDataRecord Record
        {
            get { return m_record; }
            set { m_record = value; }
        }

        public new TableInfo Structure
        {
            get { return _structure; }
            set { _structure = value; }
        }
    }

    public class DataReaderAdapter : DataRecordAdapterBase, ICdlReader
    {
        private IDataReader _reader;
        private IDatabaseFactory _factory;
        private bool _includeHiddenColumns;
        private IDbCommand _command;

        public DataReaderAdapter(IDataReader reader, IDatabaseFactory factory, bool includeHiddenColumns, IDbCommand command = null)
        {
            _reader = reader;
            _factory = factory;
            _includeHiddenColumns = includeHiddenColumns;
            _structure = reader.GetTableInfo(_includeHiddenColumns);
            _command = command;
        }

        #region ICdlReader Members

        public void Cancel()
        {
            if (_command != null) _command.Cancel();
        }

        public bool Read()
        {
            if (_reader.Read())
            {
                m_record = _reader;
                return true;
            }
            else
            {
                m_record = null;
                return false;
            }
        }

        public bool NextResult()
        {
            bool res = _reader.NextResult();
            if (res)
            {
                _structure = _reader.GetTableInfo();
            }
            return res;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (Disposing != null) Disposing();
            Disposing = null;
        }

        public event Action Disposing;

        #endregion
    }
}
