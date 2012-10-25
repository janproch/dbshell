using System;
using System.Data;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.CommonDataLayer
{
    public class CdlRecordAdapter : IDataRecord
    {
        ICdlRecord m_record;
        CdlValueConvertor m_convertor;
        CdlValueHolder m_value;

        public ICdlRecord Record
        {
            get { return m_record; }
            set { m_record = value; }
        }

        int m_curField = -1;

        public CdlRecordAdapter()
        {
            m_convertor = new CdlValueConvertor(new DataFormatSettings());
            m_value = new CdlValueHolder();
        }

        private void WantField(int index)
        {
            if (index != m_curField)
            {
                m_curField = index;
                m_record.ReadValue(m_curField);
            }
        }

        #region IDataRecord Members

        public int FieldCount
        {
            get { return m_record.FieldCount; }
        }

        public bool GetBoolean(int i)
        {
            WantField(i);
            m_convertor.ConvertValue(m_record, TypeStorage.Boolean, m_value);
            return m_value.GetBoolean();
        }

        public byte GetByte(int i)
        {
            WantField(i);
            m_convertor.ConvertValue(m_record, TypeStorage.Byte, m_value);
            return m_value.GetByte();
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedError("DBSH-00000");
        }

        public char GetChar(int i)
        {
            throw new NotImplementedError("DBSH-00000");
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedError("DBSH-00000");
        }

        public IDataReader GetData(int i)
        {
            throw new NotImplementedError("DBSH-00000");
        }

        public string GetDataTypeName(int i)
        {
            WantField(i);
            return m_record.GetFieldType().GetDotNetType(false).FullName;
        }

        public DateTime GetDateTime(int i)
        {
            WantField(i);
            m_convertor.ConvertValue(m_record, TypeStorage.DateTime, m_value);
            return m_value.GetDateTime();
        }

        public decimal GetDecimal(int i)
        {
            WantField(i);
            m_convertor.ConvertValue(m_record, TypeStorage.Decimal, m_value);
            return m_value.GetDecimal();
        }

        public double GetDouble(int i)
        {
            WantField(i);
            m_convertor.ConvertValue(m_record, TypeStorage.Double, m_value);
            return m_value.GetDouble();
        }

        public Type GetFieldType(int i)
        {
            WantField(i);
            return m_record.GetFieldType().GetDotNetType(false);
        }

        public float GetFloat(int i)
        {
            WantField(i);
            m_convertor.ConvertValue(m_record, TypeStorage.Float, m_value);
            return m_value.GetFloat();
        }

        public Guid GetGuid(int i)
        {
            WantField(i);
            m_convertor.ConvertValue(m_record, TypeStorage.Guid, m_value);
            return m_value.GetGuid();
        }

        public short GetInt16(int i)
        {
            WantField(i);
            m_convertor.ConvertValue(m_record, TypeStorage.Double, m_value);
            return m_value.GetInt16();
        }

        public int GetInt32(int i)
        {
            WantField(i);
            m_convertor.ConvertValue(m_record, TypeStorage.Double, m_value);
            return m_value.GetInt32();
        }

        public long GetInt64(int i)
        {
            WantField(i);
            m_convertor.ConvertValue(m_record, TypeStorage.Double, m_value);
            return m_value.GetInt64();
        }

        public string GetName(int i)
        {
            return m_record.Structure.Columns[i].Name;
        }

        public int GetOrdinal(string name)
        {
            return m_record.Structure.Columns.GetIndex(name);
        }

        public string GetString(int i)
        {
            WantField(i);
            m_convertor.ConvertValue(m_record, TypeStorage.String, m_value);
            return m_value.GetString();
        }

        public object GetValue(int i)
        {
            WantField(i);
            return m_record.GetValue();
        }

        public int GetValues(object[] values)
        {
            int cnt = Math.Min(values.Length, FieldCount);
            for (int i = 0; i < cnt; i++) values[i] = GetValue(i);
            return cnt;
        }

        public bool IsDBNull(int i)
        {
            WantField(i);
            return m_record.GetFieldType() == TypeStorage.Null;
        }

        public object this[string name]
        {
            get { return GetValue(GetOrdinal(name)); }
        }

        public object this[int i]
        {
            get { return GetValue(i); }
        }

        #endregion
    }
}
