using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.CommonDataLayer
{
    public class CdlRecordProxy : ICdlRecord
    {
        protected ICdlRecord RefObject;

        public virtual Structure.TableInfo Structure
        {
            get { return RefObject.Structure; }
        }

        public int FieldCount
        {
            get
            {
                if (RefObject == null && Structure != null)
                {
                    return Structure.ColumnCount;
                }
                return RefObject.FieldCount;
            }
        }

        public int GetOrdinal(string colName)
        {
            return RefObject.GetOrdinal(colName);
        }

        public string GetName(int i)
        {
            return RefObject.GetName(i);
        }

        public int GetValues(object[] values)
        {
            return RefObject.GetValues(values);
        }

        public void ReadValue(int i)
        {
            RefObject.ReadValue(i);
        }

        public TypeStorage GetFieldType()
        {
            return RefObject.GetFieldType();
        }

        public bool GetBoolean()
        {
            return RefObject.GetBoolean();
        }

        public byte GetByte()
        {
            return RefObject.GetByte();
        }

        public sbyte GetSByte()
        {
            return RefObject.GetSByte();
        }

        public byte[] GetByteArray()
        {
            return RefObject.GetByteArray();
        }

        public DateTime GetDateTime()
        {
            return RefObject.GetDateTime();
        }

        public DateTimeEx GetDateTimeEx()
        {
            return RefObject.GetDateTimeEx();
        }

        public DateEx GetDateEx()
        {
            return RefObject.GetDateEx();
        }

        public TimeEx GetTimeEx()
        {
            return RefObject.GetTimeEx();
        }

        public decimal GetDecimal()
        {
            return RefObject.GetDecimal();
        }

        public double GetDouble()
        {
            return RefObject.GetDouble();
        }

        public float GetFloat()
        {
            return RefObject.GetFloat();
        }

        public Guid GetGuid()
        {
            return RefObject.GetGuid();
        }

        public short GetInt16()
        {
            return RefObject.GetInt16();
        }

        public int GetInt32()
        {
            return RefObject.GetInt32();
        }

        public long GetInt64()
        {
            return RefObject.GetInt64();
        }

        public ushort GetUInt16()
        {
            return RefObject.GetUInt16();
        }

        public uint GetUInt32()
        {
            return RefObject.GetUInt32();
        }

        public ulong GetUInt64()
        {
            return RefObject.GetUInt64();
        }

        public string GetString()
        {
            return RefObject.GetString();
        }

        public object GetValue()
        {
            return RefObject.GetValue();
        }
    }
}
