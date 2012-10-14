using System;
using System.Collections.Generic;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.CommonDataLayer
{
    public enum TypeStorage : byte
    {
        Null = 0,
        Byte = 1,
        Int16 = 2,
        Int32 = 3,
        Int64 = 4,
        SByte = 5,
        UInt16 = 6,
        UInt32 = 7,
        UInt64 = 8,
        String = 9,
        Boolean = 10,
        DateTime = 11,
        Decimal = 12,
        Float = 13,
        Double = 14,
        Guid = 15,
        ByteArray = 16,
        DateTimeEx = 17,
        DateEx = 18,
        TimeEx = 19,
        Undefined = 255,
    }

    public interface ICdlValueReader
    {
        TypeStorage GetFieldType();

        bool GetBoolean();
        byte GetByte();
        sbyte GetSByte();
        byte[] GetByteArray();
        DateTime GetDateTime();
        DateTimeEx GetDateTimeEx();
        DateEx GetDateEx();
        TimeEx GetTimeEx();
        decimal GetDecimal();
        double GetDouble();
        float GetFloat();
        Guid GetGuid();
        short GetInt16();
        int GetInt32();
        long GetInt64();
        ushort GetUInt16();
        uint GetUInt32();
        ulong GetUInt64();
        string GetString();
        object GetValue();
    }

    public interface ICdlValueWriter
    {
        void SetBoolean(bool value);
        void SetByte(byte value);
        void SetSByte(sbyte value);
        void SetByteArray(byte[] value);
        void SetDateTime(DateTime value);
        void SetDateTimeEx(DateTimeEx value);
        void SetDateEx(DateEx value);
        void SetTimeEx(TimeEx value);
        void SetDecimal(decimal value);
        void SetDouble(double value);
        void SetFloat(float value);
        void SetGuid(Guid value);
        void SetInt16(short value);
        void SetInt32(int value);
        void SetInt64(long value);
        void SetUInt16(ushort value);
        void SetUInt32(uint value);
        void SetUInt64(ulong value);
        void SetString(string value);
        void SetNull();
    }

    public interface ICdlRecordWriter : ICdlValueWriter
    {
        void SeekValue(int i);
    }

    public interface ICdlRecord : ICdlValueReader
    {
        TableInfo Structure { get; }
        int FieldCount { get; }
        int GetOrdinal(string colName);
        string GetName(int i);
        int GetValues(object[] values); // quick read all record values

        void ReadValue(int i);
    }

    public interface ICdlReader : ICdlRecord, IDisposable
    {
        bool Read();
    }

    public interface ICdlValueParser
    {
        void ParseValue(string text, TypeStorage type, ICdlValueWriter writer);
    }

    public interface ICdlValueFormatter : ICdlValueWriter
    {
        string GetText();
    }

    public interface ICdlValueConvertor
    {
        void ConvertValue(ICdlValueReader reader, TypeStorage type, ICdlValueWriter writer);
        ICdlValueParser Parser { get; }
        ICdlValueFormatter Formatter { get; }
    }

    public interface IRowCollection<RowType> : IEnumerable<RowType>
        where RowType : class, ICdlRecord
    {
        RowType this[int index] { get; }
        int Count { get; }
    }

    public interface IInMemoryTable<RowType>
        where RowType : class, ICdlRecord
    {
        TableInfo Structure { get; }
        IRowCollection<RowType> Rows { get; }
    }
}
