using System;
using System.Data;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.CommonTypeSystem
{
    public class DbTypeNumeric : DbTypeNumber
    {
        int m_precision = 12;
        [XmlAttrib("precision")]
        public int Precision
        {
            get { return m_precision; }
            set { m_precision = value; }
        }

        int m_scale = 3;
        [XmlAttrib("scale")]
        public int Scale
        {
            get { return m_scale; }
            set { m_scale = value; }
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
            get { return DbTypeCode.Numeric; }
        }
        public override Type DotNetType
        {
            get { return typeof(Decimal); }
        }
        public static DbTypeBase Create(int scale, int prec)
        {
            DbTypeNumeric res = new DbTypeNumeric();
            res.Scale = scale;
            res.Precision = prec;
            return res;
        }
        public override string ToString()
        {
            return String.Format("numeric({0},{1})", Precision, Scale);
        }
        public override void SetAutoincrement(bool value) { m_autoincrement = value; }
        public override bool IsAutoIncrement() { return m_autoincrement; }
        public override int GetSize()
        {
            return Precision;
        }
        public override DbType GetProviderType()
        {
            return DbType.Decimal;
        }
        public override string XsdType
        {
            get { return "xs:decimal"; }
        }
        public override TypeStorage DefaultStorage
        {
            get { return TypeStorage.Decimal; }
        }

        public override void SetLength(int value) { Precision = value; }
        public override int GetLength() { return Precision; }

        public override void SetScale(int value) { Scale = value; }
        public override int GetScale() { return Scale; }
    }
}