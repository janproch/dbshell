using System;
using System.Data;
using System.IO;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.CommonDataLayer
{
    public static class CdlValueExtension
    {
        public static void ReadFrom(this ICdlValueWriter writer, IDataRecord record, int index)
        {
            if (record.IsDBNull(index))
            {
                writer.SetNull();
                return;
            }
            Type type = record.GetFieldType(index);
            try
            {
                switch (Type.GetTypeCode(type))
                {
                    case TypeCode.Boolean:
                        writer.SetBoolean(record.GetBoolean(index));
                        break;
                    case TypeCode.Byte:
                        writer.SetByte(record.GetByte(index));
                        break;
                    case TypeCode.Int16:
                        writer.SetInt16(record.GetInt16(index));
                        break;
                    case TypeCode.Int32:
                        writer.SetInt32(record.GetInt32(index));
                        break;
                    case TypeCode.Int64:
                        writer.SetInt64(record.GetInt64(index));
                        break;
                    case TypeCode.SByte:
                        unchecked
                        {
                            writer.SetSByte((sbyte)record.GetByte(index));
                        }
                        break;
                    case TypeCode.UInt16:
                        unchecked
                        {
                            writer.SetUInt16((ushort)record.GetInt16(index));
                        }
                        break;
                    case TypeCode.UInt32:
                        unchecked
                        {
                            writer.SetUInt32((uint)record.GetInt32(index));
                        }
                        break;
                    case TypeCode.UInt64:
                        unchecked
                        {
                            writer.SetUInt64((ulong)record.GetInt64(index));
                        }
                        break;
                    case TypeCode.DateTime:
                        writer.SetDateTime(record.GetDateTime(index));
                        break;
                    case TypeCode.Decimal:
                        writer.SetDecimal(record.GetDecimal(index));
                        break;
                    case TypeCode.Single:
                        writer.SetFloat(record.GetFloat(index));
                        break;
                    case TypeCode.Double:
                        writer.SetDouble(record.GetDouble(index));
                        break;
                    case TypeCode.String:
                        writer.SetString(record.GetString(index));
                        break;
                    default:
                        if (type == typeof(Guid))
                        {
                            writer.SetGuid(record.GetGuid(index));
                        }
                        else if (type == typeof(byte[]))
                        {
                            writer.SetByteArray((byte[])record.GetValue(index));
                        }
                        else
                        {
                            writer.SetString(record.GetValue(index).ToString());
                        }
                        break;
                }
            }
            catch
            {
                try
                {
                    object val = record[index];
                    // try to read from boxed value (not very effective)
                    writer.ReadFrom(val);
                }
                catch
                {
                    try
                    {
                        writer.SetString(record.GetString(index));
                    }
                    catch (Exception err)
                    {
                        // add information to exception
                        try { err.Data["data_type"] = record.GetFieldType(index).FullName; }
                        catch (Exception err2) { err.Data["data_type"] = err2.ToString(); }
                        try { err.Data["data_isnull"] = record.IsDBNull(index).ToString(); }
                        catch (Exception err2) { err.Data["data_isnull"] = err2.ToString(); }
                        throw;
                    }
                }
            }
        }
        public static void ReadFrom(this ICdlValueWriter writer, object value)
        {
            if (value == null || value == DBNull.Value)
            {
                writer.SetNull();
                return;
            }
            var valreader = value as ICdlValueReader;
            if (valreader != null)
            {
                writer.ReadFrom(valreader);
                return;
            }
            Type type = value.GetType();
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Boolean:
                    writer.SetBoolean((bool)value);
                    break;
                case TypeCode.Byte:
                    writer.SetByte((byte)value);
                    break;
                case TypeCode.Int16:
                    writer.SetInt16((short)value);
                    break;
                case TypeCode.Int32:
                    writer.SetInt32((int)value);
                    break;
                case TypeCode.Int64:
                    writer.SetInt64((long)value);
                    break;
                case TypeCode.SByte:
                    writer.SetSByte((sbyte)value);
                    break;
                case TypeCode.UInt16:
                    writer.SetUInt16((ushort)value);
                    break;
                case TypeCode.UInt32:
                    writer.SetUInt32((uint)value);
                    break;
                case TypeCode.UInt64:
                    writer.SetUInt64((ulong)value);
                    break;
                case TypeCode.DateTime:
                    writer.SetDateTime((DateTime)value);
                    break;
                case TypeCode.Decimal:
                    writer.SetDecimal((decimal)value);
                    break;
                case TypeCode.Single:
                    writer.SetFloat((float)value);
                    break;
                case TypeCode.Double:
                    writer.SetDouble((double)value);
                    break;
                case TypeCode.String:
                    writer.SetString((string)value);
                    break;
                default:
                    if (type == typeof(Guid))
                    {
                        writer.SetGuid((Guid)value);
                    }
                    else if (type == typeof(byte[]))
                    {
                        writer.SetByteArray((byte[])value);
                    }
                    else if (type == typeof(DateTimeEx))
                    {
                        writer.SetDateTimeEx((DateTimeEx)value);
                    }
                    else if (type == typeof(DateEx))
                    {
                        writer.SetDateEx((DateEx)value);
                    }
                    else if (type == typeof(TimeEx))
                    {
                        writer.SetTimeEx((TimeEx)value);
                    }
                    else
                    {
                        writer.SetString(value.ToString());
                    }
                    break;
            }
        }

        public static void WriteTo(this ICdlValueReader reader, ICdlValueWriter writer)
        {
            switch (reader.GetFieldType())
            {
                case TypeStorage.Null:
                    writer.SetNull();
                    break;
                case TypeStorage.Boolean:
                    writer.SetBoolean(reader.GetBoolean());
                    break;
                case TypeStorage.Byte:
                    writer.SetByte(reader.GetByte());
                    break;
                case TypeStorage.Int16:
                    writer.SetInt16(reader.GetInt16());
                    break;
                case TypeStorage.Int32:
                    writer.SetInt32(reader.GetInt32());
                    break;
                case TypeStorage.Int64:
                    writer.SetInt64(reader.GetInt64());
                    break;
                case TypeStorage.SByte:
                    writer.SetSByte(reader.GetSByte());
                    break;
                case TypeStorage.UInt16:
                    writer.SetUInt16(reader.GetUInt16());
                    break;
                case TypeStorage.UInt32:
                    writer.SetUInt32(reader.GetUInt32());
                    break;
                case TypeStorage.UInt64:
                    writer.SetUInt64(reader.GetUInt64());
                    break;
                case TypeStorage.Float:
                    writer.SetFloat(reader.GetFloat());
                    break;
                case TypeStorage.Double:
                    writer.SetDouble(reader.GetDouble());
                    break;
                case TypeStorage.Decimal:
                    writer.SetDecimal(reader.GetDecimal());
                    break;
                case TypeStorage.DateTime:
                    writer.SetDateTime(reader.GetDateTime());
                    break;
                case TypeStorage.DateTimeEx:
                    writer.SetDateTimeEx(reader.GetDateTimeEx());
                    break;
                case TypeStorage.DateEx:
                    writer.SetDateEx(reader.GetDateEx());
                    break;
                case TypeStorage.TimeEx:
                    writer.SetTimeEx(reader.GetTimeEx());
                    break;
                case TypeStorage.ByteArray:
                    writer.SetByteArray(reader.GetByteArray());
                    break;
                case TypeStorage.Guid:
                    writer.SetGuid(reader.GetGuid());
                    break;
                case TypeStorage.String:
                    writer.SetString(reader.GetString());
                    break;
            }
        }

        public static void ReadFrom(this ICdlValueWriter writer, ICdlValueReader reader)
        {
            reader.WriteTo(writer);
        }

        public static object BoxTypedValue(this ICdlValueReader reader)
        {
            switch (reader.GetFieldType())
            {
                case TypeStorage.Null:
                    return null;
                case TypeStorage.Boolean:
                    return reader.GetBoolean();
                case TypeStorage.Byte:
                    return reader.GetByte();
                case TypeStorage.Int16:
                    return reader.GetInt16();
                case TypeStorage.Int32:
                    return reader.GetInt32();
                case TypeStorage.Int64:
                    return reader.GetInt64();
                case TypeStorage.SByte:
                    return reader.GetSByte();
                case TypeStorage.UInt16:
                    return reader.GetUInt16();
                case TypeStorage.UInt32:
                    return reader.GetUInt32();
                case TypeStorage.UInt64:
                    return reader.GetUInt64();
                case TypeStorage.Float:
                    return reader.GetFloat();
                case TypeStorage.Double:
                    return reader.GetDouble();
                case TypeStorage.Decimal:
                    return reader.GetDecimal();
                case TypeStorage.DateTime:
                    return reader.GetDateTime();
                case TypeStorage.DateTimeEx:
                    return reader.GetDateTimeEx();
                case TypeStorage.DateEx:
                    return reader.GetDateEx();
                case TypeStorage.TimeEx:
                    return reader.GetTimeEx();
                case TypeStorage.ByteArray:
                    return reader.GetByteArray();
                case TypeStorage.Guid:
                    return reader.GetGuid();
                case TypeStorage.String:
                    return reader.GetString();
                //case TypeStorage.Array:
                //    return reader.GetArray();
            }
            return null;
        }

        public static void ReadValue(this ICdlValueWriter writer, BinaryReader stream)
        {
            TypeStorage storage = (TypeStorage)stream.ReadByte();
            switch (storage)
            {
                case TypeStorage.Null:
                    writer.SetNull();
                    break;
                case TypeStorage.Boolean:
                    writer.SetBoolean(stream.ReadBoolean());
                    break;
                case TypeStorage.Byte:
                    writer.SetByte(stream.ReadByte());
                    break;
                case TypeStorage.Int16:
                    writer.SetInt16(stream.ReadInt16());
                    break;
                case TypeStorage.Int32:
                    writer.SetInt32(stream.ReadInt32());
                    break;
                case TypeStorage.Int64:
                    writer.SetInt64(stream.ReadInt64());
                    break;
                case TypeStorage.SByte:
                    writer.SetSByte(stream.ReadSByte());
                    break;
                case TypeStorage.UInt16:
                    writer.SetUInt16(stream.ReadUInt16());
                    break;
                case TypeStorage.UInt32:
                    writer.SetUInt32(stream.ReadUInt32());
                    break;
                case TypeStorage.UInt64:
                    writer.SetUInt64(stream.ReadUInt64());
                    break;
                case TypeStorage.Float:
                    writer.SetFloat(stream.ReadSingle());
                    break;
                case TypeStorage.Double:
                    writer.SetDouble(stream.ReadDouble());
                    break;
                case TypeStorage.Decimal:
                    writer.SetDecimal(stream.ReadDecimal());
                    break;
                case TypeStorage.DateTime:
                    writer.SetDateTime(DateTime.FromBinary(stream.ReadInt64()));
                    break;
                case TypeStorage.DateTimeEx:
                    writer.SetDateTimeEx(DateTimeEx.FromStream(stream));
                    break;
                case TypeStorage.DateEx:
                    writer.SetDateEx(DateEx.FromStream(stream));
                    break;
                case TypeStorage.TimeEx:
                    writer.SetTimeEx(TimeEx.FromStream(stream));
                    break;
                case TypeStorage.ByteArray:
                    {
                        int len = stream.Read7BitEncodedInteger();
                        writer.SetByteArray(stream.ReadBytes(len));
                    }
                    break;
                case TypeStorage.Guid:
                    writer.SetGuid(new Guid(stream.ReadBytes(16)));
                    break;
                case TypeStorage.String:
                    writer.SetString(stream.ReadString());
                    break;
            }
        }

        public static TypeStorage GetTypeStorage(this Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Boolean:
                    return TypeStorage.Boolean;
                case TypeCode.Byte:
                    return TypeStorage.Byte;
                case TypeCode.Int16:
                    return TypeStorage.Int16;
                case TypeCode.Int32:
                    return TypeStorage.Int32;
                case TypeCode.Int64:
                    return TypeStorage.Int64;
                case TypeCode.SByte:
                    return TypeStorage.SByte;
                case TypeCode.UInt16:
                    return TypeStorage.UInt16;
                case TypeCode.UInt32:
                    return TypeStorage.UInt32;
                case TypeCode.UInt64:
                    return TypeStorage.UInt64;
                case TypeCode.DateTime:
                    return TypeStorage.DateTime;
                case TypeCode.Decimal:
                    return TypeStorage.Decimal;
                case TypeCode.Single:
                    return TypeStorage.Float;
                case TypeCode.Double:
                    return TypeStorage.Double;
                case TypeCode.String:
                    return TypeStorage.String;
                default:
                    if (type == typeof(Guid))
                    {
                        return TypeStorage.Guid;
                    }
                    else if (type == typeof(byte[]))
                    {
                        return TypeStorage.ByteArray;
                    }
                    //else if (type.IsArray)
                    //{
                    //    return TypeStorage.Array;
                    //}
                    else if (type == typeof(DateTimeEx))
                    {
                        return TypeStorage.DateTimeEx;
                    }
                    else if (type == typeof(DateEx))
                    {
                        return TypeStorage.DateEx;
                    }
                    else if (type == typeof(TimeEx))
                    {
                        return TypeStorage.TimeEx;
                    }
                    else
                    {
                        return TypeStorage.Undefined;
                    }
                    break;
            }
        }

        public static TypeStorage GetObjectTypeStorage(object o)
        {
            Type type = o.GetType();
            return type.GetTypeStorage();
        }
        public static bool IsDateRelated(this TypeStorage type)
        {
            switch (type)
            {
                case TypeStorage.DateEx:
                case TypeStorage.DateTime:
                case TypeStorage.DateTimeEx:
                case TypeStorage.TimeEx:
                    return true;
                default:
                    return false;
            }
        }
        public static bool IsInteger(this TypeStorage type)
        {
            switch (type)
            {
                case TypeStorage.Byte:
                case TypeStorage.Int16:
                case TypeStorage.Int32:
                case TypeStorage.Int64:
                case TypeStorage.SByte:
                case TypeStorage.UInt16:
                case TypeStorage.UInt32:
                case TypeStorage.UInt64:
                    return true;
                default:
                    return false;
            }
        }
        public static bool IsNumber(this TypeStorage type)
        {
            switch (type)
            {
                case TypeStorage.Byte:
                case TypeStorage.Int16:
                case TypeStorage.Int32:
                case TypeStorage.Int64:
                case TypeStorage.SByte:
                case TypeStorage.UInt16:
                case TypeStorage.UInt32:
                case TypeStorage.UInt64:
                case TypeStorage.Float:
                case TypeStorage.Double:
                case TypeStorage.Decimal:
                    return true;
                default:
                    return false;
            }
        }
        public static long GetIntegerValue(this ICdlValueReader reader)
        {
            switch (reader.GetFieldType())
            {
                case TypeStorage.Byte:
                    return reader.GetByte();
                case TypeStorage.Int16:
                    return reader.GetInt16();
                case TypeStorage.Int32:
                    return reader.GetInt32();
                case TypeStorage.Int64:
                    return reader.GetInt64();
                case TypeStorage.SByte:
                    return reader.GetSByte();
                case TypeStorage.UInt16:
                    return reader.GetUInt16();
                case TypeStorage.UInt32:
                    return reader.GetUInt32();
                case TypeStorage.UInt64:
                    unchecked
                    {
                        return (long)reader.GetUInt64();
                    }
                case TypeStorage.Float:
                    return (long)reader.GetFloat();
                case TypeStorage.Double:
                    return (long)reader.GetDouble();
                case TypeStorage.Decimal:
                    return (long)reader.GetDecimal();
                default:
                    return 0;
            }
        }
        public static double GetRealValue(this ICdlValueReader reader)
        {
            switch (reader.GetFieldType())
            {
                case TypeStorage.Byte:
                    return reader.GetByte();
                case TypeStorage.Int16:
                    return reader.GetInt16();
                case TypeStorage.Int32:
                    return reader.GetInt32();
                case TypeStorage.Int64:
                    return reader.GetInt64();
                case TypeStorage.SByte:
                    return reader.GetSByte();
                case TypeStorage.UInt16:
                    return reader.GetUInt16();
                case TypeStorage.UInt32:
                    return reader.GetUInt32();
                case TypeStorage.UInt64:
                    return reader.GetUInt64();
                case TypeStorage.Float:
                    return reader.GetFloat();
                case TypeStorage.Double:
                    return reader.GetDouble();
                case TypeStorage.Decimal:
                    return (double)reader.GetDecimal();
                default:
                    return 0;
            }
        }
        public static void SetIntegerValue(this ICdlValueWriter writer, TypeStorage type, long value)
        {
            unchecked
            {
                switch (type)
                {
                    case TypeStorage.Byte:
                        writer.SetByte((byte)value);
                        break;
                    case TypeStorage.Int16:
                        writer.SetInt16((short)value);
                        break;
                    case TypeStorage.Int32:
                        writer.SetInt32((int)value);
                        break;
                    case TypeStorage.Int64:
                        writer.SetInt64((long)value);
                        break;
                    case TypeStorage.SByte:
                        writer.SetSByte((sbyte)value);
                        break;
                    case TypeStorage.UInt16:
                        writer.SetUInt16((ushort)value);
                        break;
                    case TypeStorage.UInt32:
                        writer.SetUInt32((uint)value);
                        break;
                    case TypeStorage.UInt64:
                        writer.SetUInt64((ulong)value);
                        break;
                    case TypeStorage.Float:
                        writer.SetFloat((float)value);
                        break;
                    case TypeStorage.Double:
                        writer.SetDouble((double)value);
                        break;
                    case TypeStorage.Decimal:
                        writer.SetDecimal((decimal)value);
                        break;
                }
            }
        }
        public static void SetRealValue(this ICdlValueWriter writer, TypeStorage type, double value)
        {
            switch (type)
            {
                case TypeStorage.Byte:
                    writer.SetByte((byte)value);
                    break;
                case TypeStorage.Int16:
                    writer.SetInt16((short)value);
                    break;
                case TypeStorage.Int32:
                    writer.SetInt32((int)value);
                    break;
                case TypeStorage.Int64:
                    writer.SetInt64((long)value);
                    break;
                case TypeStorage.SByte:
                    writer.SetSByte((sbyte)value);
                    break;
                case TypeStorage.UInt16:
                    writer.SetUInt16((ushort)value);
                    break;
                case TypeStorage.UInt32:
                    writer.SetUInt32((uint)value);
                    break;
                case TypeStorage.UInt64:
                    writer.SetUInt64((ulong)value);
                    break;
                case TypeStorage.Float:
                    writer.SetFloat((float)value);
                    break;
                case TypeStorage.Double:
                    writer.SetDouble((double)value);
                    break;
                case TypeStorage.Decimal:
                    writer.SetDecimal((decimal)value);
                    break;
            }
        }
        public static DateTimeEx GetDateTimeValue(this ICdlValueReader reader)
        {
            switch (reader.GetFieldType())
            {
                case TypeStorage.DateEx:
                    return new DateTimeEx { DatePart = reader.GetDateEx() };
                case TypeStorage.TimeEx:
                    return new DateTimeEx { TimePart = reader.GetTimeEx() };
                case TypeStorage.DateTime:
                    return new DateTimeEx { AsDateTime = reader.GetDateTime() };
                case TypeStorage.DateTimeEx:
                    return reader.GetDateTimeEx();
                default:
                    return new DateTimeEx();
            }
        }
        public static void SetDateTimeValue(this ICdlValueWriter writer, TypeStorage type, DateTimeEx value)
        {
            switch (type)
            {
                case TypeStorage.DateEx:
                    writer.SetDateEx(value.DatePart);
                    break;
                case TypeStorage.TimeEx:
                    writer.SetTimeEx(value.TimePart);
                    break;
                case TypeStorage.DateTime:
                    writer.SetDateTime(value.AsDateTime);
                    break;
                case TypeStorage.DateTimeEx:
                    writer.SetDateTimeEx(value);
                    break;
            }
        }
    }
}
