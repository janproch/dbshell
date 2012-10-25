using System;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.Utility
{
    public class ArrayDataRecord : ICdlRecord, ICdlRecordWriter
    {
        object[] m_values;
        TableInfo m_structure;
        int m_curReadField = -1;
        int m_curWriteField = -1;
        CdlValueHolder m_workingHolder = new CdlValueHolder();
        bool m_loadedValue;

        public ArrayDataRecord(TableInfo structure, object[] values)
        {
            m_values = values;
            m_structure = structure;
        }

        public ArrayDataRecord(TableInfo structure)
        {
            m_structure = structure;
            m_values = new object[structure.Columns.Count];
        }

        public ArrayDataRecord(ICdlRecord record)
        {
            m_values = new object[record.FieldCount];
            m_structure = record.Structure;
            record.GetValues(m_values);
        }

        public ArrayDataRecord(ICdlRecord record, int[] colindexes, TableInfo changedStructure)
        {
            if (colindexes.Length != changedStructure.Columns.Count) throw new InternalError("DBSH-00000 ArrayDataRecord(): colnames.count != colindexes.count");
            m_values = new object[colindexes.Length];
            for (int i = 0; i < colindexes.Length; i++)
            {
                if (colindexes[i] >= 0)
                {
                    m_values[i] = record.GetValue(colindexes[i]);
                }
            }
            m_structure = changedStructure;
        }

        #region ICdlRecord Members

        public TableInfo Structure
        {
            get { return m_structure; }
        }

        public int FieldCount
        {
            get { return m_values.Length; }
        }

        public int GetOrdinal(string colName)
        {
            return m_structure.Columns.GetIndex(colName);
        }

        public string GetName(int i)
        {
            return m_structure.Columns[i].Name;
        }

        public void ReadValue(int i)
        {
            m_curReadField = i;
            m_loadedValue = false;
        }

        #endregion

        private void Changed()
        {
            m_loadedValue = false;
        }

        private CdlValueHolder WantValue()
        {
            if (!m_loadedValue)
            {
                m_workingHolder.ReadFrom(m_values[m_curReadField]);
                m_loadedValue = true;
            }
            return m_workingHolder;
        }

        #region ICdlValueReader Members

        public TypeStorage GetFieldType()
        {
            var val = WantValue();
            return val.GetFieldType();
        }

        public bool GetBoolean()
        {
            var val = WantValue();
            return val.GetBoolean();
        }

        public byte GetByte()
        {
            var val = WantValue();
            return val.GetByte();
        }

        public sbyte GetSByte()
        {
            var val = WantValue();
            return val.GetSByte();
        }

        public byte[] GetByteArray()
        {
            var val = WantValue();
            return val.GetByteArray();
        }

        public DateTime GetDateTime()
        {
            var val = WantValue();
            return val.GetDateTime();
        }

        public DateTimeEx GetDateTimeEx()
        {
            var val = WantValue();
            return val.GetDateTimeEx();
        }

        public DateEx GetDateEx()
        {
            var val = WantValue();
            return val.GetDateEx();
        }

        public TimeEx GetTimeEx()
        {
            var val = WantValue();
            return val.GetTimeEx();
        }

        public decimal GetDecimal()
        {
            var val = WantValue();
            return val.GetDecimal();
        }

        public double GetDouble()
        {
            var val = WantValue();
            return val.GetDouble();
        }

        public float GetFloat()
        {
            var val = WantValue();
            return val.GetFloat();
        }

        public Guid GetGuid()
        {
            var val = WantValue();
            return val.GetGuid();
        }

        public short GetInt16()
        {
            var val = WantValue();
            return val.GetInt16();
        }

        public int GetInt32()
        {
            var val = WantValue();
            return val.GetInt32();
        }

        public long GetInt64()
        {
            var val = WantValue();
            return val.GetInt64();
        }

        public ushort GetUInt16()
        {
            var val = WantValue();
            return val.GetUInt16();
        }

        public uint GetUInt32()
        {
            var val = WantValue();
            return val.GetUInt32();
        }

        public ulong GetUInt64()
        {
            var val = WantValue();
            return val.GetUInt64();
        }

        public string GetString()
        {
            var val = WantValue();
            return val.GetString();
        }

        //public Array GetArray()
        //{
        //    var val = WantValue();
        //    return val.GetArray();
        //}

        public object GetValue()
        {
            return m_values[m_curReadField];
        }

        public int GetValues(object[] data)
        {
            int cnt = Math.Min(data.Length, m_values.Length);
            for (int i = 0; i < cnt; i++)
            {
                data[i] = m_values[i];
            }
            return cnt;
        }

        #endregion

        #region ICdlRecordWriter Members

        public void SeekValue(int i)
        {
            m_curWriteField = i;
        }

        #endregion

        #region ICdlValueWriter Members

        public void SetBoolean(bool value)
        {
            m_values[m_curWriteField] = value;
            Changed();
        }

        public void SetByte(byte value)
        {
            m_values[m_curWriteField] = value;
            Changed();
        }

        public void SetSByte(sbyte value)
        {
            m_values[m_curWriteField] = value;
            Changed();
        }

        public void SetByteArray(byte[] value)
        {
            m_values[m_curWriteField] = value;
            Changed();
        }

        public void SetDateTime(DateTime value)
        {
            m_values[m_curWriteField] = value;
            Changed();
        }

        public void SetDateTimeEx(DateTimeEx value)
        {
            m_values[m_curWriteField] = value;
            Changed();
        }

        public void SetDateEx(DateEx value)
        {
            m_values[m_curWriteField] = value;
            Changed();
        }

        public void SetTimeEx(TimeEx value)
        {
            m_values[m_curWriteField] = value;
            Changed();
        }

        public void SetDecimal(decimal value)
        {
            m_values[m_curWriteField] = value;
            Changed();
        }

        public void SetDouble(double value)
        {
            m_values[m_curWriteField] = value;
            Changed();
        }

        public void SetFloat(float value)
        {
            m_values[m_curWriteField] = value;
            Changed();
        }

        public void SetGuid(Guid value)
        {
            m_values[m_curWriteField] = value;
            Changed();
        }

        public void SetInt16(short value)
        {
            m_values[m_curWriteField] = value;
            Changed();
        }

        public void SetInt32(int value)
        {
            m_values[m_curWriteField] = value;
            Changed();
        }

        public void SetInt64(long value)
        {
            m_values[m_curWriteField] = value;
            Changed();
        }

        public void SetUInt16(ushort value)
        {
            m_values[m_curWriteField] = value;
            Changed();
        }

        public void SetUInt32(uint value)
        {
            m_values[m_curWriteField] = value;
            Changed();
        }

        public void SetUInt64(ulong value)
        {
            m_values[m_curWriteField] = value;
            Changed();
        }

        public void SetString(string value)
        {
            m_values[m_curWriteField] = value;
            Changed();
        }

        //public void SetArray(Array value)
        //{
        //    m_values[m_curWriteField] = value;
        //    Changed();
        //}

        public void SetNull()
        {
            m_values[m_curWriteField] = null;
            Changed();
        }

        #endregion
    }
}
