using System;
using System.Data;

namespace DbShell.Driver.Common.Utility
{
    public class DataRecordProxy : IDataRecord
    {
        protected IDataRecord m_obj;

        #region IDataRecord Members

        public virtual int FieldCount
        {
            get { return m_obj.FieldCount; ; }
        }

        public bool GetBoolean(int i)
        {
            return m_obj.GetBoolean(i);
        }

        public byte GetByte(int i)
        {
            return m_obj.GetByte(i);
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            return m_obj.GetBytes(i, fieldOffset, buffer, bufferoffset, length);
        }

        public char GetChar(int i)
        {
            return m_obj.GetChar(i);
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            return m_obj.GetChars(i, fieldoffset, buffer, bufferoffset, length);
        }

        public IDataReader GetData(int i)
        {
            return m_obj.GetData(i);
        }

        public string GetDataTypeName(int i)
        {
            return m_obj.GetDataTypeName(i);
        }

        public DateTime GetDateTime(int i)
        {
            return m_obj.GetDateTime(i);
        }

        public decimal GetDecimal(int i)
        {
            return m_obj.GetDecimal(i);
        }

        public double GetDouble(int i)
        {
            return m_obj.GetDouble(i);
        }

        public virtual Type GetFieldType(int i)
        {
            return m_obj.GetFieldType(i);
        }

        public float GetFloat(int i)
        {
            return m_obj.GetFloat(i);
        }

        public Guid GetGuid(int i)
        {
            return m_obj.GetGuid(i);
        }

        public short GetInt16(int i)
        {
            return m_obj.GetInt16(i);
        }

        public int GetInt32(int i)
        {
            return m_obj.GetInt32(i);
        }

        public long GetInt64(int i)
        {
            return m_obj.GetInt32(i);
        }

        public string GetName(int i)
        {
            return m_obj.GetName(i);
        }

        public int GetOrdinal(string name)
        {
            return m_obj.GetOrdinal(name);
        }

        public string GetString(int i)
        {
            return m_obj.GetString(i);
        }

        public object GetValue(int i)
        {
            return m_obj.GetValue(i);
        }

        public int GetValues(object[] values)
        {
            return m_obj.GetValues(values);
        }

        public bool IsDBNull(int i)
        {
            return m_obj.IsDBNull(i);
        }

        public object this[string name]
        {
            get { return m_obj[name]; }
        }

        public object this[int i]
        {
            get { return m_obj[i]; }
        }

        #endregion
    }
}
