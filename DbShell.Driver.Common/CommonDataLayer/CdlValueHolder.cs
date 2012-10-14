using System;
using System.Diagnostics;

namespace DbShell.Driver.Common.CommonDataLayer
{
    public class CdlValueHolder : ICdlValueReader, ICdlValueWriter
    {
        protected TypeStorage m_type = TypeStorage.Null;

        protected byte[] m_byteArrayVal;
        protected DateTime m_dateTimeVal;
        protected DateTimeEx m_dateTimeExVal;
        protected decimal m_decimalVal;
        protected double m_doubleVal;
        protected float m_floatVal;
        protected Guid m_guidVal;
        protected string m_stringVal;
        protected long m_intVal;
        protected Array m_arrayVal;

        #region ICdlValueReader Members

        public TypeStorage GetFieldType()
        {
            return m_type;
        }

        public bool GetBoolean()
        {
#if DEBUG
            Debug.Assert(m_type == TypeStorage.Boolean);
#endif
            return m_intVal != 0;
        }

        public byte GetByte()
        {
#if DEBUG
            Debug.Assert(m_type == TypeStorage.Byte);
#endif
            unchecked
            {
                return (byte)m_intVal;
            }
        }

        public sbyte GetSByte()
        {
#if DEBUG
            Debug.Assert(m_type == TypeStorage.SByte);
#endif
            unchecked
            {
                return (sbyte)m_intVal;
            }
        }

        public byte[] GetByteArray()
        {
#if DEBUG
            Debug.Assert(m_type == TypeStorage.ByteArray);
#endif
            return m_byteArrayVal;
        }

        public DateTime GetDateTime()
        {
#if DEBUG
            Debug.Assert(m_type == TypeStorage.DateTime);
#endif
            return m_dateTimeVal;
        }

        public DateTimeEx GetDateTimeEx()
        {
#if DEBUG
            Debug.Assert(m_type == TypeStorage.DateTimeEx);
#endif
            return m_dateTimeExVal;
        }

        public TimeEx GetTimeEx()
        {
#if DEBUG
            Debug.Assert(m_type == TypeStorage.TimeEx);
#endif
            return m_dateTimeExVal.TimePart;
        }

        public DateEx GetDateEx()
        {
#if DEBUG
            Debug.Assert(m_type == TypeStorage.DateEx);
#endif
            return m_dateTimeExVal.DatePart;
        }

        public decimal GetDecimal()
        {
#if DEBUG
            Debug.Assert(m_type == TypeStorage.Decimal);
#endif
            return m_decimalVal;
        }

        public double GetDouble()
        {
#if DEBUG
            Debug.Assert(m_type == TypeStorage.Double);
#endif
            return m_doubleVal;
        }

        public float GetFloat()
        {
#if DEBUG
            Debug.Assert(m_type == TypeStorage.Float);
#endif
            return m_floatVal;
        }

        public Guid GetGuid()
        {
#if DEBUG
            Debug.Assert(m_type == TypeStorage.Guid);
#endif
            return m_guidVal;
        }

        public short GetInt16()
        {
#if DEBUG
            Debug.Assert(m_type == TypeStorage.Int16);
#endif
            unchecked
            {
                return (short)m_intVal;
            }
        }

        public int GetInt32()
        {
#if DEBUG
            Debug.Assert(m_type == TypeStorage.Int32);
#endif
            unchecked
            {
                return (int)m_intVal;
            }
        }

        public long GetInt64()
        {
#if DEBUG
            Debug.Assert(m_type == TypeStorage.Int64);
#endif
            unchecked
            {
                return (long)m_intVal;
            }
        }

        public ushort GetUInt16()
        {
#if DEBUG
            Debug.Assert(m_type == TypeStorage.UInt16);
#endif
            unchecked
            {
                return (ushort)m_intVal;
            }
        }

        public uint GetUInt32()
        {
#if DEBUG
            Debug.Assert(m_type == TypeStorage.UInt32);
#endif
            unchecked
            {
                return (uint)m_intVal;
            }
        }

        public ulong GetUInt64()
        {
#if DEBUG
            Debug.Assert(m_type == TypeStorage.UInt64);
#endif
            unchecked
            {
                return (ulong)m_intVal;
            }
        }

        public string GetString()
        {
#if DEBUG
            Debug.Assert(m_type == TypeStorage.String);
#endif
            return m_stringVal;
        }

//        public Array GetArray()
//        {
//#if DEBUG
//            Debug.Assert(m_type == TypeStorage.Array);
//#endif
//            return m_arrayVal;
//        }

        public object GetValue()
        {
            return this.BoxTypedValue();
        }

        #endregion

        #region ICdlValueWriter Members

        public void SetBoolean(bool value)
        {
            m_intVal = value ? 1 : 0;
            m_type = TypeStorage.Boolean;
        }

        public void SetByte(byte value)
        {
            m_intVal = value;
            m_type = TypeStorage.Byte;
        }

        public void SetSByte(sbyte value)
        {
            m_intVal = value;
            m_type = TypeStorage.SByte;
        }

        public void SetByteArray(byte[] value)
        {
            m_byteArrayVal = value;
            m_type = TypeStorage.ByteArray;
        }

        public void SetDateTime(DateTime value)
        {
            m_dateTimeVal = value;
            m_type = TypeStorage.DateTime;
        }

        public void SetDateTimeEx(DateTimeEx value)
        {
            m_dateTimeExVal = value;
            m_type = TypeStorage.DateTimeEx;
        }

        public void SetTimeEx(TimeEx value)
        {
            m_dateTimeExVal.TimePart = value;
            m_type = TypeStorage.TimeEx;
        }

        public void SetDateEx(DateEx value)
        {
            m_dateTimeExVal.DatePart = value;
            m_type = TypeStorage.DateEx;
        }

        public void SetDecimal(decimal value)
        {
            m_decimalVal = value;
            m_type = TypeStorage.Decimal;
        }

        public void SetDouble(double value)
        {
            m_doubleVal = value;
            m_type = TypeStorage.Double;
        }

        public void SetFloat(float value)
        {
            m_floatVal = value;
            m_type = TypeStorage.Float;
        }

        public void SetGuid(Guid value)
        {
            m_guidVal = value;
            m_type = TypeStorage.Guid;
        }

        public void SetInt16(short value)
        {
            m_intVal = value;
            m_type = TypeStorage.Int16;
        }

        public void SetInt32(int value)
        {
            m_intVal = value;
            m_type = TypeStorage.Int32;
        }

        public void SetInt64(long value)
        {
            m_intVal = value;
            m_type = TypeStorage.Int64;
        }

        public void SetUInt16(ushort value)
        {
            m_intVal = value;
            m_type = TypeStorage.UInt16;
        }

        public void SetUInt32(uint value)
        {
            m_intVal = value;
            m_type = TypeStorage.UInt32;
        }

        public void SetUInt64(ulong value)
        {
            unchecked
            {
                m_intVal = (long)value;
                m_type = TypeStorage.UInt64;
            }
        }

        public void SetString(string value)
        {
            m_stringVal = value;
            m_type = TypeStorage.String;
        }

        //public void SetArray(Array value)
        //{
        //    m_arrayVal = value;
        //    m_type = TypeStorage.Array;
        //}

        public void SetNull()
        {
            m_type = TypeStorage.Null;
        }

        #endregion
    }

    //public sealed class WorkingCdlValueHolder : CdlValueHolder
    //{
    //    [ThreadStatic]
    //    private static WorkingCdlValueHolder m_instance;
    //    [ThreadStatic]
    //    private static WorkingCdlValueHolder m_instance2;

    //    public static WorkingCdlValueHolder Instance
    //    {
    //        get
    //        {
    //            if (m_instance == null) m_instance = new WorkingCdlValueHolder();
    //            return m_instance;
    //        }
    //    }
    //    public static WorkingCdlValueHolder Instance2
    //    {
    //        get
    //        {
    //            if (m_instance2 == null) m_instance2 = new WorkingCdlValueHolder();
    //            return m_instance2;
    //        }
    //    }

    //    public object Owner { get; set; }
    //}
}
