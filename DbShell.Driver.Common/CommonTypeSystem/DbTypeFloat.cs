using System;
using System.Data;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.CommonTypeSystem
{
    public class DbTypeFloat : DbTypeNumber
    {
        int m_bytes = 8;
        [XmlAttrib("bytes")]
        public int Bytes
        {
            get { return m_bytes; }
            set { m_bytes = value; }
        }

        bool m_isMoney;
        [XmlAttrib("money")]
        public bool IsMoney
        {
            get { return m_isMoney; }
            set { m_isMoney = value; }
        }

        public override DbTypeCode Code
        {
            get { return DbTypeCode.Float; }
        }
        public override Type DotNetType
        {
            get
            {
                if (IsMoney) return typeof(decimal);
                return typeof(double);
            }
        }

        public static DbTypeBase Create(int bytes)
        {
            DbTypeFloat res = new DbTypeFloat();
            res.Bytes = bytes;
            return res;
        }
        public override string ToString()
        {
            return "float";
        }
        public override DbType GetProviderType()
        {
            if (IsMoney) return DbType.Currency;
            return DbType.Double;
        }
        public override string XsdType
        {
            get
            {
                switch (m_bytes)
                {
                    case 4: return "xs:float";
                    case 8: return "xs:double";
                }
                return "xs:double";
            }
        }
        public override TypeStorage DefaultStorage
        {
            get
            {
                switch (m_bytes)
                {
                    case 4: return TypeStorage.Float;
                    case 8: return TypeStorage.Double;
                }
                return TypeStorage.Double;
            }
        }
    }
}