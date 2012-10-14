using System;
using System.Globalization;

namespace DbShell.Driver.Common.CommonDataLayer
{
    public sealed class CdlValueFormatter : ICdlValueFormatter
    {
        string m_text;

        NumberFormatInfo m_numberFormat;
        DataFormatSettings m_settings;

        public CdlValueFormatter(DataFormatSettings settings)
        {
            m_settings = settings;
            m_numberFormat = m_settings.GetNumberFormat();
        }

        #region ICdlValueFormatter Members

        public string GetText()
        {
            return m_text;
        }

        #endregion

        #region ICdlValueWriter Members

        public void SetBoolean(bool value)
        {
            m_text = value ? m_settings.GetTrueValue() : m_settings.GetFalseValue();
        }

        public void SetByte(byte value)
        {
            m_text = value.ToString(m_numberFormat);
        }

        public void SetSByte(sbyte value)
        {
            m_text = value.ToString(m_numberFormat);
        }

        public void SetByteArray(byte[] value)
        {
            m_text = m_settings.FormatBlob(value);
        }

        public void SetDateTime(DateTime value)
        {
            m_text = value.ToString(m_settings.DateTimeFormat, CultureInfo.InvariantCulture);
        }

        public void SetDateTimeEx(DateTimeEx value)
        {
            m_text = value.ToString(m_settings.DateTimeFormat, CultureInfo.InvariantCulture);
        }

        public void SetDateEx(DateEx value)
        {
            m_text = value.ToString(m_settings.DateFormat, CultureInfo.InvariantCulture);
        }

        public void SetTimeEx(TimeEx value)
        {
            m_text = value.ToString(m_settings.TimeFormat, CultureInfo.InvariantCulture);
        }

        public void SetDecimal(decimal value)
        {
            m_text = value.ToString(m_numberFormat);
        }

        public void SetDouble(double value)
        {
            m_text = value.ToString(m_numberFormat);
        }

        public void SetFloat(float value)
        {
            m_text = value.ToString(m_numberFormat);
        }

        public void SetGuid(Guid value)
        {
            m_text = value.ToString();
        }

        public void SetInt16(short value)
        {
            m_text = value.ToString(m_numberFormat);
        }

        public void SetInt32(int value)
        {
            m_text = value.ToString(m_numberFormat);
        }

        public void SetInt64(long value)
        {
            m_text = value.ToString(m_numberFormat);
        }

        public void SetUInt16(ushort value)
        {
            m_text = value.ToString(m_numberFormat);
        }

        public void SetUInt32(uint value)
        {
            m_text = value.ToString(m_numberFormat);
        }

        public void SetUInt64(ulong value)
        {
            m_text = value.ToString(m_numberFormat);
        }

        public void SetString(string value)
        {
            m_text = value;
        }

        //public void SetArray(Array value)
        //{
        //    m_text = CdlArray.ToString(value);
        //}

        public void SetNull()
        {
            m_text = m_settings.GetNullValue();
        }

        #endregion
    }
}
