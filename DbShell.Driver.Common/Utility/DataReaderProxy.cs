using System.Data;

namespace DbShell.Driver.Common.Utility
{
    public class DataReaderProxy : DataRecordProxy, IDataReader
    {
        new IDataReader m_obj;

        public DataReaderProxy(IDataReader obj)
        {
            m_obj = obj;
            base.m_obj = obj;
        }

        #region IDataReader Members

        public void Close()
        {
            m_obj.Close();
        }

        public int Depth
        {
            get { return m_obj.Depth; }
        }

        public DataTable GetSchemaTable()
        {
            return m_obj.GetSchemaTable();
        }

        public bool IsClosed
        {
            get { return m_obj.IsClosed; }
        }

        public bool NextResult()
        {
            return m_obj.NextResult();
        }

        public bool Read()
        {
            return m_obj.Read();
        }

        public int RecordsAffected
        {
            get { return m_obj.RecordsAffected; }
        }

        #endregion

        #region IDisposable Members

        public virtual void Dispose()
        {
            m_obj.Dispose();
        }

        #endregion
    }
}
