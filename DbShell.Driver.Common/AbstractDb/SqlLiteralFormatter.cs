using System;
using System.Globalization;
using System.Text;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.AbstractDb
{
    public class SqlLiteralFormatter : ICdlValueFormatter
    {
        protected string m_text;
        private IDatabaseFactory _factory;

        #region ICdlValueWriter Members

        public SqlLiteralFormatter(IDatabaseFactory factory)
        {
            _factory = factory;
        }

        public virtual void SetBoolean(bool value)
        {
            m_text = value ? "1" : "0";
        }

        public virtual void SetByte(byte value)
        {
            m_text = value.ToString(CultureInfo.InvariantCulture);
        }

        public virtual void SetSByte(sbyte value)
        {
            m_text = value.ToString(CultureInfo.InvariantCulture);
        }

        public virtual void SetByteArray(byte[] value)
        {
            if (value.Length == 0) m_text = "''";
            else m_text = "0x" + StringTool.EncodeHex(value);
        }

        public virtual void SetDateTime(DateTime value)
        {
            m_text = "'" + value.ToString("s") + "'";
        }

        public virtual void SetDateTimeEx(DateTimeEx value)
        {
            m_text = "'" + value.ToStringNormalized() + "'";
        }

        public virtual void SetDateEx(DateEx value)
        {
            m_text = "'" + value.ToStringNormalized() + "'";
        }

        public virtual void SetTimeEx(TimeEx value)
        {
            m_text = "'" + value.ToStringNormalized() + "'";
        }

        public virtual void SetDecimal(decimal value)
        {
            m_text = value.ToString(CultureInfo.InvariantCulture);
        }

        public virtual void SetDouble(double value)
        {
            m_text = value.ToString(CultureInfo.InvariantCulture);
        }

        public virtual void SetFloat(float value)
        {
            m_text = value.ToString(CultureInfo.InvariantCulture);
        }

        public virtual void SetGuid(Guid value)
        {
            m_text = "'" + value.ToString() + "'";
        }

        public virtual void SetInt16(short value)
        {
            m_text = value.ToString(CultureInfo.InvariantCulture);
        }

        public virtual void SetInt32(int value)
        {
            m_text = value.ToString(CultureInfo.InvariantCulture);
        }

        public virtual void SetInt64(long value)
        {
            m_text = value.ToString(CultureInfo.InvariantCulture);
        }

        public virtual void SetUInt16(ushort value)
        {
            m_text = value.ToString(CultureInfo.InvariantCulture);
        }

        public virtual void SetUInt32(uint value)
        {
            m_text = value.ToString(CultureInfo.InvariantCulture);
        }

        public virtual void SetUInt64(ulong value)
        {
            m_text = value.ToString(CultureInfo.InvariantCulture);
        }

        public virtual void SetString(string value)
        {
            StringBuilder sb = new StringBuilder(value.Length + 10);
            sb.Append('\'');
            EscapeString(value, sb);
            sb.Append('\'');
            m_text = sb.ToString();
        }

        //public virtual void SetArray(Array value)
        //{
        //    SetString(CdlArray.ToString(value));
        //}

        public virtual void SetNull()
        {
            m_text = "NULL";
        }

        #endregion

        #region ICdlValueFormatter Members

        public string GetText()
        {
            return m_text;
        }

        #endregion

        public virtual void EscapeString(string value, StringBuilder sb)
        {
            _factory.CreateDialect().EscapeString(value, sb);
        }
    }
}
