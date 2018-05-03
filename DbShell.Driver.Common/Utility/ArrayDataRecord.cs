using System;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.Utility
{
    public class ArrayDataRecord : ICdlRecord, ICdlRecordWriter
    {
        protected object[] _values;
        TableInfo _structure;
        int _curReadField = -1;
        int _curWriteField = -1;
        CdlValueHolder _workingHolder = new CdlValueHolder();
        bool _loadedValue;

        public ArrayDataRecord(TableInfo structure, object[] values)
        {
            _values = values;
            _structure = structure;
        }

        public ArrayDataRecord(TableInfo structure)
        {
            _structure = structure;
            _values = new object[structure.Columns.Count];
        }

        public ArrayDataRecord(ICdlRecord record)
        {
            _values = new object[record.FieldCount];
            _structure = record.Structure;
            record.GetValues(_values);
        }

        public ArrayDataRecord(ICdlRecord record, int[] colindexes, TableInfo changedStructure)
        {
            if (colindexes.Length != changedStructure.Columns.Count) throw new InternalError("DBSH-00050 ArrayDataRecord(): colnames.count != colindexes.count");
            _values = new object[colindexes.Length];
            for (int i = 0; i < colindexes.Length; i++)
            {
                if (colindexes[i] >= 0)
                {
                    _values[i] = record.GetValue(colindexes[i]);
                }
            }
            _structure = changedStructure;
        }

        #region ICdlRecord Members

        public TableInfo Structure
        {
            get { return _structure; }
        }

        public int FieldCount
        {
            get { return _values.Length; }
        }

        public object[] Values
        {
            get { return _values; }
        }

        public int GetOrdinal(string colName)
        {
            return _structure.GetColumnIndex(colName);
        }

        public string GetName(int i)
        {
            return _structure.Columns[i].Name;
        }

        public void ReadValue(int i)
        {
            _curReadField = i;
            _loadedValue = false;
        }

        #endregion

        private void Changed()
        {
            _loadedValue = false;
        }

        private CdlValueHolder WantValue()
        {
            if (!_loadedValue)
            {
                _workingHolder.ReadFrom(_values[_curReadField]);
                _loadedValue = true;
            }
            return _workingHolder;
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
            return _values[_curReadField];
        }

        public int GetValues(object[] data)
        {
            int cnt = Math.Min(data.Length, _values.Length);
            for (int i = 0; i < cnt; i++)
            {
                data[i] = _values[i];
            }
            return cnt;
        }

        #endregion

        #region ICdlRecordWriter Members

        public void SeekValue(int i)
        {
            _curWriteField = i;
        }

        #endregion

        #region ICdlValueWriter Members

        public void SetBoolean(bool value)
        {
            _values[_curWriteField] = value;
            Changed();
        }

        public void SetByte(byte value)
        {
            _values[_curWriteField] = value;
            Changed();
        }

        public void SetSByte(sbyte value)
        {
            _values[_curWriteField] = value;
            Changed();
        }

        public void SetByteArray(byte[] value)
        {
            _values[_curWriteField] = value;
            Changed();
        }

        public void SetDateTime(DateTime value)
        {
            _values[_curWriteField] = value;
            Changed();
        }

        public void SetDateTimeEx(DateTimeEx value)
        {
            _values[_curWriteField] = value;
            Changed();
        }

        public void SetDateEx(DateEx value)
        {
            _values[_curWriteField] = value;
            Changed();
        }

        public void SetTimeEx(TimeEx value)
        {
            _values[_curWriteField] = value;
            Changed();
        }

        public void SetDecimal(decimal value)
        {
            _values[_curWriteField] = value;
            Changed();
        }

        public void SetDouble(double value)
        {
            _values[_curWriteField] = value;
            Changed();
        }

        public void SetFloat(float value)
        {
            _values[_curWriteField] = value;
            Changed();
        }

        public void SetGuid(Guid value)
        {
            _values[_curWriteField] = value;
            Changed();
        }

        public void SetInt16(short value)
        {
            _values[_curWriteField] = value;
            Changed();
        }

        public void SetInt32(int value)
        {
            _values[_curWriteField] = value;
            Changed();
        }

        public void SetInt64(long value)
        {
            _values[_curWriteField] = value;
            Changed();
        }

        public void SetUInt16(ushort value)
        {
            _values[_curWriteField] = value;
            Changed();
        }

        public void SetUInt32(uint value)
        {
            _values[_curWriteField] = value;
            Changed();
        }

        public void SetUInt64(ulong value)
        {
            _values[_curWriteField] = value;
            Changed();
        }

        public void SetString(string value)
        {
            _values[_curWriteField] = value;
            Changed();
        }

        //public void SetArray(Array value)
        //{
        //    _values[_curWriteField] = value;
        //    Changed();
        //}

        public void SetNull()
        {
            _values[_curWriteField] = null;
            Changed();
        }

        #endregion
    }
}
