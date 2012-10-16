using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.CommonDataLayer
{
    public class StreamValueWriter : ICdlValueWriter
    {
        BinaryWriter m_stream;
        public StreamValueWriter(BinaryWriter stream)
        {
            m_stream = stream;
        }

        #region IBedValueWriter Members

        public void SetBoolean(bool value)
        {
            m_stream.Write((byte)TypeStorage.Boolean);
            m_stream.Write(value);
        }

        public void SetByte(byte value)
        {
            m_stream.Write((byte)TypeStorage.Byte);
            m_stream.Write(value);
        }

        public void SetSByte(sbyte value)
        {
            m_stream.Write((byte)TypeStorage.SByte);
            m_stream.Write(value);
        }

        public void SetByteArray(byte[] value)
        {
            m_stream.Write((byte)TypeStorage.ByteArray);
            m_stream.Write7BitEncodedInteger(value.Length);
            m_stream.Write(value);
        }

        public void SetDateTime(DateTime value)
        {
            m_stream.Write((byte)TypeStorage.DateTime);
            m_stream.Write(value.ToBinary());
        }

        public void SetDateTimeEx(DateTimeEx value)
        {
            m_stream.Write((byte)TypeStorage.DateTimeEx);
            value.WriteTo(m_stream);
        }

        public void SetDateEx(DateEx value)
        {
            m_stream.Write((byte)TypeStorage.DateEx);
            value.WriteTo(m_stream);
        }

        public void SetTimeEx(TimeEx value)
        {
            m_stream.Write((byte)TypeStorage.TimeEx);
            value.WriteTo(m_stream);
        }

        public void SetDecimal(decimal value)
        {
            m_stream.Write((byte)TypeStorage.Decimal);
            m_stream.Write(value);
        }

        public void SetDouble(double value)
        {
            m_stream.Write((byte)TypeStorage.Double);
            m_stream.Write(value);
        }

        public void SetFloat(float value)
        {
            m_stream.Write((byte)TypeStorage.Float);
            m_stream.Write(value);
        }

        public void SetGuid(Guid value)
        {
            m_stream.Write((byte)TypeStorage.Guid);
            m_stream.Write(value.ToByteArray());
        }

        public void SetInt16(short value)
        {
            m_stream.Write((byte)TypeStorage.Int16);
            m_stream.Write(value);
        }

        public void SetInt32(int value)
        {
            m_stream.Write((byte)TypeStorage.Int32);
            m_stream.Write(value);
        }

        public void SetInt64(long value)
        {
            m_stream.Write((byte)TypeStorage.Int64);
            m_stream.Write(value);
        }

        public void SetUInt16(ushort value)
        {
            m_stream.Write((byte)TypeStorage.UInt16);
            m_stream.Write(value);
        }

        public void SetUInt32(uint value)
        {
            m_stream.Write((byte)TypeStorage.UInt32);
            m_stream.Write(value);
        }

        public void SetUInt64(ulong value)
        {
            m_stream.Write((byte)TypeStorage.UInt64);
            m_stream.Write(value);
        }

        public void SetString(string value)
        {
            m_stream.Write((byte)TypeStorage.String);
            m_stream.Write(value);
        }

        //public void SetArray(Array value)
        //{
        //    m_stream.Write((byte)TypeStorage.Array);
        //    BedArray.WriteToStream(value, m_stream);
        //}

        public void SetNull()
        {
            m_stream.Write((byte)TypeStorage.Null);
        }

        #endregion
    }
}
