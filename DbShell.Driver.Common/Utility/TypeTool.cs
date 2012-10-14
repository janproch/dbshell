using System;
using System.Data;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.Utility
{
    public static class TypeTool
    {
        //public static Type TypeFromName(string name)
        //{
        //    switch (name)
        //    {
        //        case "int": return typeof(Int32);
        //        case "numeric": return typeof(Decimal);
        //        case "varchar": return typeof(String);
        //        case "nvarchar": return typeof(String);
        //        case "image": return typeof(byte[]);
        //    }
        //    return Type.GetType(name);
        //}

        public static DbType GetProviderType(DbTypeBase type)
        {
            return GetProviderType(type.DotNetType);
        }

        public static DbType GetProviderType(Type type)
        {
            if (type == typeof(String))
                return DbType.String;
            if (type == typeof(Double))
                return DbType.Double;
            if (type == typeof(Int16))
                return DbType.Int16;
            if (type == typeof(Int32))
                return DbType.Int32;
            if (type == typeof(Int64))
                return DbType.Int64;
            if (type == typeof(Single))
                return DbType.Single;
            if (type == typeof(Boolean))
                return DbType.Boolean;
            if (type == typeof(Decimal))
                return DbType.Decimal;
            if (type == typeof(DateTime))
                return DbType.DateTime;
            if (type == typeof(Byte[]))
                return DbType.Binary;
            if (type == typeof(Guid))
                return DbType.Guid;
            return DbType.String;
        }

        public static DbTypeBase GetDatAdminType(this Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Boolean:
                    return new DbTypeLogical();
                case TypeCode.Byte:
                    return new DbTypeInt { Bytes = 1, Unsigned = true };
                case TypeCode.DateTime:
                    return new DbTypeDatetime();
                case TypeCode.Decimal:
                    return new DbTypeNumeric();
                case TypeCode.Double:
                    return new DbTypeFloat { Bytes = 8 };
                case TypeCode.Int16:
                    return new DbTypeInt { Bytes = 2 };
                case TypeCode.Int32:
                    return new DbTypeInt { Bytes = 4 };
                case TypeCode.Int64:
                    return new DbTypeInt { Bytes = 8 };
                case TypeCode.SByte:
                    return new DbTypeInt { Bytes = 1 };
                case TypeCode.UInt16:
                    return new DbTypeInt { Bytes = 2, Unsigned = true };
                case TypeCode.UInt32:
                    return new DbTypeInt { Bytes = 4, Unsigned = true };
                case TypeCode.UInt64:
                    return new DbTypeInt { Bytes = 8, Unsigned = true };
                case TypeCode.Single:
                    return new DbTypeFloat { Bytes = 4 };
                case TypeCode.String:
                    return new DbTypeString();
            }
            if (type == typeof(DateTimeEx))
                return new DbTypeDatetime();
            if (type == typeof(DateEx))
                return new DbTypeDatetime { SubType = DbDatetimeSubType.Date };
            if (type == typeof(TimeEx))
                return new DbTypeDatetime { SubType = DbDatetimeSubType.Time };
            if (type == typeof(Byte[]))
                return new DbTypeBlob();
            if (type == typeof(Guid))
                return new DbTypeGuid();
            if (type.FullName.ToLower().Contains("datetime")) return new DbTypeDatetime();
            if (type.IsArray) return new DbTypeArray { ElementType = type.GetElementType().GetDatAdminType() };
            return new DbTypeString();
        }

        public static DbTypeBase GetDatAdminType(this TypeStorage type)
        {
            switch (type)
            {
                case TypeStorage.Boolean:
                    return new DbTypeLogical();
                case TypeStorage.Byte:
                    return new DbTypeInt { Bytes = 1, Unsigned = true };
                case TypeStorage.SByte:
                    return new DbTypeInt { Bytes = 1, Unsigned = false };
                case TypeStorage.ByteArray:
                    return new DbTypeBlob();
                case TypeStorage.DateEx:
                    return new DbTypeDatetime { SubType = DbDatetimeSubType.Date };
                case TypeStorage.DateTime:
                    return new DbTypeDatetime();
                case TypeStorage.DateTimeEx:
                    return new DbTypeDatetime();
                case TypeStorage.Decimal:
                    return new DbTypeNumeric();
                case TypeStorage.Double:
                    return new DbTypeFloat { Bytes = 8 };
                case TypeStorage.Float:
                    return new DbTypeFloat { Bytes = 4 };
                case TypeStorage.Guid:
                    return new DbTypeGuid();
                case TypeStorage.Int16:
                    return new DbTypeInt { Bytes = 2, Unsigned = false };
                case TypeStorage.Int32:
                    return new DbTypeInt { Bytes = 4, Unsigned = false };
                case TypeStorage.Int64:
                    return new DbTypeInt { Bytes = 8, Unsigned = false };
                case TypeStorage.UInt16:
                    return new DbTypeInt { Bytes = 2, Unsigned = true };
                case TypeStorage.UInt32:
                    return new DbTypeInt { Bytes = 4, Unsigned = true };
                case TypeStorage.UInt64:
                    return new DbTypeInt { Bytes = 8, Unsigned = true };
                case TypeStorage.String:
                    return new DbTypeString();
                case TypeStorage.TimeEx:
                    return new DbTypeDatetime { SubType = DbDatetimeSubType.Time };
            }
            return new DbTypeString();
        }

        public static Type GetDotNetType(this TypeStorage type, bool allowDAExtensions)
        {
            switch (type)
            {
                case TypeStorage.Boolean:
                    return typeof(bool);
                case TypeStorage.Byte:
                    return typeof(byte);
                case TypeStorage.SByte:
                    return typeof(sbyte);
                case TypeStorage.ByteArray:
                    return typeof(byte[]);
                case TypeStorage.DateEx:
                    return allowDAExtensions ? typeof(DateEx) : typeof(DateTime);
                case TypeStorage.DateTime:
                    return typeof(DateTime);
                case TypeStorage.DateTimeEx:
                    return allowDAExtensions ? typeof(DateTimeEx) : typeof(DateTime);
                case TypeStorage.Decimal:
                    return typeof(decimal);
                case TypeStorage.Double:
                    return typeof(double);
                case TypeStorage.Float:
                    return typeof(float);
                case TypeStorage.Guid:
                    return typeof(Guid);
                case TypeStorage.Int16:
                    return typeof(short);
                case TypeStorage.Int32:
                    return typeof(int);
                case TypeStorage.Int64:
                    return typeof(long);
                case TypeStorage.UInt16:
                    return typeof(ushort);
                case TypeStorage.UInt32:
                    return typeof(uint);
                case TypeStorage.UInt64:
                    return typeof(ulong);
                case TypeStorage.String:
                    return typeof(string);
                case TypeStorage.TimeEx:
                    return allowDAExtensions ? typeof(TimeEx) : typeof(DateTime);
                case TypeStorage.Null:
                    return typeof(DBNull);
                //case TypeStorage.Array:
                //    throw new InternalError("DAE-00055 TypeTool.GetDotNetType: Type array has not .NET representation");
            }
            return typeof(string);
        }
    }
}
