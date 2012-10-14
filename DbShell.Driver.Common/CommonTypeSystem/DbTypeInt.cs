using System;
using System.Data;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.CommonTypeSystem
{
    public class DbTypeInt : DbTypeNumber
    {
        int m_bytes = 4;
        [XmlAttrib("bytes")]
        public int Bytes
        {
            get { return m_bytes; }
            set { m_bytes = value; }
        }

        bool m_autoincrement = false;
        [XmlAttrib("autoincrement")]
        [IsIdentity]
        public bool Autoincrement
        {
            get { return m_autoincrement; }
            set { m_autoincrement = value; }
        }

        public override DbTypeCode Code
        {
            get { return DbTypeCode.Int; }
        }
        public override Type DotNetType
        {
            get
            {
                if (m_unsigned)
                {
                    switch (m_bytes)
                    {
                        case 1: return typeof(byte);
                        case 2: return typeof(ushort);
                        case 4: return typeof(uint);
                        case 8: return typeof(ulong);

                    }
                }
                else
                {
                    switch (m_bytes)
                    {
                        case 1: return typeof(sbyte);
                        case 2: return typeof(short);
                        case 4: return typeof(int);
                        case 8: return typeof(long);

                    }
                }
                return typeof(int);
            }
        }
        public override TypeStorage DefaultStorage
        {
            get
            {
                if (m_unsigned)
                {
                    switch (m_bytes)
                    {
                        case 1: return TypeStorage.Byte;
                        case 2: return TypeStorage.UInt16;
                        case 4: return TypeStorage.UInt32;
                        case 8: return TypeStorage.UInt64;
                    }
                }
                else
                {
                    switch (m_bytes)
                    {
                        case 1: return TypeStorage.SByte;
                        case 2: return TypeStorage.Int16;
                        case 4: return TypeStorage.Int32;
                        case 8: return TypeStorage.Int64;
                    }
                }
                return TypeStorage.Int32;
            }
        }
        public static DbTypeInt Create(int bytes, bool unsigned)
        {
            DbTypeInt res = new DbTypeInt();
            res.Bytes = bytes;
            res.Unsigned = unsigned;
            return res;
        }

        public override string ToString()
        {
            return "integer";
        }
        public override void SetAutoincrement(bool value) { m_autoincrement = value; }
        public override bool IsAutoIncrement() { return m_autoincrement; }

        public override DbType GetProviderType()
        {
            switch (m_bytes)
            {
                case 2: return DbType.Int16;
                case 4: return DbType.Int32;
                case 8: return DbType.Int64;
            }
            return DbType.Int32;
        }

        public override string XsdType
        {
            get
            {
                if (m_unsigned)
                {
                    switch (m_bytes)
                    {
                        case 1: return "xs:unsignedByte";
                        case 2: return "xs:unsignedShort";
                        case 4: return "xs:unsignedInt";
                        case 8: return "xs:unsignedLong";

                    }
                }
                else
                {
                    switch (m_bytes)
                    {
                        case 1: return "xs:byte";
                        case 2: return "xs:short";
                        case 4: return "xs:int";
                        case 8: return "xs:long";

                    }
                }
                return "xs:int";
            }
        }
    }
}