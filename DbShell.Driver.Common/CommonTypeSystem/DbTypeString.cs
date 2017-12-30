using System;
using System.Data;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Utility;
using System.Runtime.Serialization;

namespace DbShell.Driver.Common.CommonTypeSystem
{
    [DataContract]
    public class DbTypeString : DbTypeBase
    {
        public DbTypeString() { }
        public DbTypeString(int length)
        {
            m_length = length;
        }

        int m_length = -1;
        [XmlAttrib("length")]
        [DataMember]
        public int Length
        {
            get { return m_length; }
            set { m_length = value; }
        }

        bool m_isUnicode = false;
        [XmlAttrib("unicode")]
        [DataMember]
        public bool IsUnicode
        {
            get { return m_isUnicode; }
            set { m_isUnicode = value; }
        }

        bool m_isBinary = false;
        [XmlAttrib("binary")]
        [DataMember]
        public bool IsBinary
        {
            get { return m_isBinary; }
            set { m_isBinary = value; }
        }

        bool m_isBit = false;
        [XmlAttrib("bit")]
        [DataMember]
        public bool IsBit
        {
            get { return m_isBit; }
            set { m_isBit = value; }
        }

        bool m_isVarLength = true;
        [XmlAttrib("varlength")]
        [DataMember]
        public bool IsVarLength
        {
            get { return m_isVarLength; }
            set { m_isVarLength = value; }
        }

        public override bool IsBinaryType()
        {
            return IsBinary;
        }

        public override DbTypeCode Code
        {
            get { return DbTypeCode.String; }
        }
        public override Type DotNetType
        {
            get
            {
                if (IsBinary || IsBit) return typeof(byte[]);
                return typeof(String);
            }
        }

        public static DbTypeBase Varchar(int len, bool unicode)
        {
            DbTypeString res = new DbTypeString();
            res.Length = len;
            res.IsVarLength = true;
            res.IsUnicode = unicode;
            return res;
        }
        public static DbTypeBase Varchar(int len)
        {
            return Varchar(len, false);
        }

        public static DbTypeBase Char(int len, bool unicode)
        {
            DbTypeString res = new DbTypeString();
            res.Length = len;
            res.IsVarLength = false;
            res.IsUnicode = unicode;
            return res;
        }
        public static DbTypeBase Char(int len)
        {
            return Char(len, false);
        }

        public string GetStandardSqlName()
        {
            if (IsVarLength)
            {
                if (IsUnicode) return "nvarchar";
                if (IsBinary) return "varbinary";
                if (IsBit) return "varbit";
                return "varchar";
            }
            else
            {
                if (IsUnicode) return "nchar";
                if (IsBinary) return "binary";
                if (IsBit) return "bit";
                return "char";
            }
        }

        public override string ToString()
        {
            string sqlname = GetStandardSqlName();
            return String.Format("{0}({1})", sqlname, Length < 0 ? "max" : Length.ToString());
        }

        public override void SetLength(int value) { Length = value; }
        public override int GetLength() { return Length; }

        public override int GetSize()
        {
            return Length;
        }

        public override DbType GetProviderType()
        {
            return DbType.String;
        }

        public override string XsdType
        {
            get { return "xs:string"; }
        }

        public override TypeStorage DefaultStorage
        {
            get
            {
                if (IsBinary) return TypeStorage.ByteArray;
                return TypeStorage.String;
            }
        }

        public DbTypeBase ConvertToBlobVariant()
        {
            if (IsBinary) return new DbTypeBlob();
            return new DbTypeText { IsUnicode = IsUnicode };
        }
    }
}