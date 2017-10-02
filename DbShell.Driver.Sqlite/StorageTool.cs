using System;
using System.Collections.Generic;
#if !NETSTANDARD2_0
using System.Data.SQLite;
#else
using SQLiteDataReader = Microsoft.Data.Sqlite.SqliteDataReader;
#endif
using System.Globalization;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Sqlite
{
    public static class StorageTool
    {
        public enum StorageClass
        {
            Null,
            Integer,
            Real,
            Text,
            Blob,
        }

        public static bool GetValueAsXml(object value, ref string xtype, ref string xdata)
        {
            var holder = new CdlValueHolder();
            holder.ReadFrom(value);
            return GetValueAsXml(holder, ref xtype, ref xdata);
        }

        public static void GetValueAsSqlLiteral(ICdlValueReader rec, out string sqldata)
        {
            var type = rec.GetFieldType();
            if (type == TypeStorage.Null)
            {
                sqldata = "null";
                return;
            }
            switch (type)
            {
                case TypeStorage.Boolean:
                    sqldata = rec.GetBoolean() ? "1" : "0";
                    break;
                case TypeStorage.Byte:
                    sqldata = rec.GetByte().ToString(CultureInfo.InvariantCulture);
                    break;
                case TypeStorage.Int16:
                    sqldata = rec.GetInt16().ToString(CultureInfo.InvariantCulture);
                    break;
                case TypeStorage.Int32:
                    sqldata = rec.GetInt32().ToString(CultureInfo.InvariantCulture);
                    break;
                case TypeStorage.Int64:
                    sqldata = rec.GetInt64().ToString(CultureInfo.InvariantCulture);
                    break;
                case TypeStorage.SByte:
                    sqldata = rec.GetSByte().ToString(CultureInfo.InvariantCulture);
                    break;
                case TypeStorage.UInt16:
                    sqldata = rec.GetUInt16().ToString(CultureInfo.InvariantCulture);
                    break;
                case TypeStorage.UInt32:
                    sqldata = rec.GetUInt32().ToString(CultureInfo.InvariantCulture);
                    break;
                case TypeStorage.UInt64:
                    sqldata = rec.GetUInt64().ToString(CultureInfo.InvariantCulture);
                    break;
                case TypeStorage.DateTime:
                    sqldata = "'" + StringTool.DateTimeToIsoStringExact(rec.GetDateTime()) + "'";
                    break;
                case TypeStorage.DateTimeEx:
                    sqldata = "'" + rec.GetDateTimeEx().ToStringNormalized() + "'";
                    break;
                case TypeStorage.DateEx:
                    sqldata = "'" + rec.GetDateEx().ToStringNormalized() + "'";
                    break;
                case TypeStorage.TimeEx:
                    sqldata = "'" + rec.GetTimeEx().ToStringNormalized() + "'";
                    break;
                case TypeStorage.Decimal:
                    sqldata = rec.GetDecimal().ToString(CultureInfo.InvariantCulture);
                    break;
                case TypeStorage.Float:
                    sqldata = rec.GetFloat().ToString(CultureInfo.InvariantCulture);
                    break;
                case TypeStorage.Double:
                    sqldata = rec.GetDouble().ToString(CultureInfo.InvariantCulture);
                    break;
                case TypeStorage.String:
                    sqldata = "'" + rec.GetString().Replace("'", "''") + "'";
                    break;
                case TypeStorage.Guid:
                    sqldata = "'" + rec.GetGuid().ToString() + "'";
                    break;
                case TypeStorage.ByteArray:
                    {
                        byte[] data = rec.GetByteArray();
                        sqldata = "X'" + StringTool.EncodeHex(data) + "'";
                    }
                    break;
                    //case TypeStorage.Array:
                    //    {
                    //        xtype = "array";
                    //        xdata = CdlArray.ToString(rec.GetArray());
                    //    }
                    //    break;
                default:
                    throw new Exception("DBSH-00166 Unsupported field type:" + type.ToString());
            }
        }

        public static void ReadValue(SQLiteDataReader reader, int index, TypeStorage type, ICdlValueWriter writer)
        {
            switch (type)
            {
                case TypeStorage.Boolean:
                    writer.SetBoolean(reader.GetInt32(index) != 0);
                    break;
                case TypeStorage.Byte:
                    writer.SetByte((byte) reader.GetInt32(index));
                    break;
                case TypeStorage.Int16:
                    writer.SetInt16((short) reader.GetInt32(index));
                    break;
                case TypeStorage.Int32:
                    writer.SetInt32((int) reader.GetInt32(index));
                    break;
                case TypeStorage.Int64:
                    writer.SetInt64((long) reader.GetInt64(index));
                    break;
                case TypeStorage.SByte:
                    writer.SetSByte((sbyte) reader.GetInt32(index));
                    break;
                case TypeStorage.UInt16:
                    writer.SetUInt16((ushort) reader.GetInt32(index));
                    break;
                case TypeStorage.UInt32:
                    writer.SetUInt32((uint) reader.GetInt32(index));
                    break;
                case TypeStorage.UInt64:
                    writer.SetUInt64((ulong) reader.GetInt64(index));
                    break;
                case TypeStorage.DateTime:
                    writer.SetDateTime(DateTime.Parse(reader.GetString(index), CultureInfo.InvariantCulture));
                    //writer.SetDateTime(DateTime.ParseExact(reader.GetString(index), "s", CultureInfo.InvariantCulture));
                    break;
                case TypeStorage.DateTimeEx:
                    writer.SetDateTimeEx(DateTimeEx.ParseNormalized(reader.GetString(index)));
                    break;
                case TypeStorage.DateEx:
                    writer.SetDateEx(DateEx.ParseNormalized(reader.GetString(index)));
                    break;
                case TypeStorage.TimeEx:
                    writer.SetTimeEx(TimeEx.ParseNormalized(reader.GetString(index)));
                    break;
                case TypeStorage.Decimal:
                    {
                        var dtype = reader.GetFieldType(index);
                        decimal value;
                        if (dtype == typeof (string))
                        {
                            value = Decimal.Parse(reader.GetString(index), CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            value = (decimal) reader.GetDouble(index);
                        }
                        writer.SetDecimal(value);
                    }
                    break;
                case TypeStorage.Float:
                    writer.SetFloat((float) reader.GetDouble(index));
                    break;
                case TypeStorage.Double:
                    writer.SetDouble((double) reader.GetDouble(index));
                    break;
                case TypeStorage.String:
                    writer.SetString(reader.GetString(index));
                    break;
                case TypeStorage.Guid:
                    writer.SetGuid(new Guid(reader.GetString(index)));
                    break;
                case TypeStorage.ByteArray:
                    writer.SetByteArray((byte[]) reader.GetValue(index));
                    break;
                case TypeStorage.Null:
                    writer.SetNull();
                    break;
                default:
                    throw new Exception("DBSH-00167 Unsupported field type:" + type.ToString());
            }
        }
    }
}
