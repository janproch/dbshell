using System;
using System.Linq;
using System.ComponentModel;
using System.Globalization;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.CommonDataLayer
{
    public enum DataFormatBlobMode { InfoText, Hexa, Base64 }

    public enum OnDataErrorMode
    {
        [Description("s_propagate_to_higher_level")]
        Propagate,
        [Description("s_use_defaut_value")]
        UseDefault,
        [Description("s_use_null")]
        UseNull,
    }

    public class DataFormatSettings
    {
        string m_dateFormat = "yyyy-MM-dd";
        public string DateFormat
        {
            get { return m_dateFormat; }
            set { m_dateFormat = value; }
        }

        string m_timeFormat = "HH:mm:ss";
        public string TimeFormat
        {
            get { return m_timeFormat; }
            set { m_timeFormat = value; }
        }

        string m_dateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        public string DateTimeFormat
        {
            get { return m_dateTimeFormat; }
            set { m_dateTimeFormat = value; }
        }

        string m_decimalSeparator = ".";
        public string DecimalSeparator
        {
            get { return m_decimalSeparator; }
            set { m_decimalSeparator = value; }
        }

        string[] m_nullValues = new string[] { "(NULL)" };
        public string NullValues
        {
            get { return String.Join(", ", m_nullValues); }
            set { m_nullValues = (from s in value.Split(',') select s.Trim()).ToArray(); }
        }

        string[] m_trueValues = new string[] { "true", "yes", "1", "on" };
        public string TrueValues
        {
            get { return String.Join(", ", m_trueValues); }
            set { m_trueValues = (from s in value.Split(',') select s.Trim()).ToArray(); }
        }


        string[] m_falseValues = new string[] { "false", "no", "0", "off" };
        public string FalseValues
        {
            get { return String.Join(", ", m_falseValues); }
            set { m_falseValues = (from s in value.Split(',') select s.Trim()).ToArray(); }
        }

        string m_blobInfo = "(BLOB)";
        public string BlobInfo
        {
            get { return m_blobInfo; }
            set { m_blobInfo = value; }
        }

        DataFormatBlobMode m_blobMode = DataFormatBlobMode.Base64;
        public DataFormatBlobMode BlobMode
        {
            get { return m_blobMode; }
            set { m_blobMode = value; }
        }

        int m_hexBytesOnLine = 0;
        public int HexBytesOnLine
        {
            get { return m_hexBytesOnLine; }
            set { m_hexBytesOnLine = value; }
        }

        bool m_logAllErrors = false;
        public bool LogAllErrors
        {
            get { return m_logAllErrors; }
            set { m_logAllErrors = value; }
        }

        OnDataErrorMode m_onErrorMode = OnDataErrorMode.Propagate;
        public OnDataErrorMode OnErrorMode
        {
            get { return m_onErrorMode; }
            set { m_onErrorMode = value; }
        }

        int m_defaultNumber;
        public int DefaultNumber
        {
            get { return m_defaultNumber; }
            set { m_defaultNumber = value; }
        }

        bool m_defautlLogical;
        public bool DefautlLogical
        {
            get { return m_defautlLogical; }
            set { m_defautlLogical = value; }
        }

        DateTimeEx m_defaultDateTime = new DateTimeEx(2000, 1, 1, 0, 0, 0);
        public DateTimeEx DefaultDateTime
        {
            get { return m_defaultDateTime; }
            set { m_defaultDateTime = value; }
        }

        public string[] GetNullValues() { return m_nullValues; }
        public string[] GetTrueValues() { return m_trueValues; }
        public string[] GetFalseValues() { return m_falseValues; }

        public string GetTrueValue()
        {
            if (m_trueValues.Length > 0) return m_trueValues[0]; return "true";
        }
        public string GetFalseValue()
        {
            if (m_falseValues.Length > 0) return m_falseValues[0]; return "false";
        }
        public string GetNullValue()
        {
            if (m_nullValues.Length > 0) return m_nullValues[0]; return "(NULL)";
        }

        public NumberFormatInfo GetNumberFormat()
        {
            var res = new NumberFormatInfo();
            res.NumberDecimalSeparator = DecimalSeparator;
            return res;
        }

        public string FormatBlob(byte[] data)
        {
            switch (BlobMode)
            {
                case DataFormatBlobMode.InfoText:
                    return BlobInfo;
                case DataFormatBlobMode.Base64:
                    return Convert.ToBase64String(data) + "=";
                case DataFormatBlobMode.Hexa:
                    if (HexBytesOnLine > 0) return StringTool.EncodeHex(data, HexBytesOnLine);
                    else return StringTool.EncodeHex(data);
            }
            return "";
        }

        public bool? ParseBoolean(string text)
        {
            foreach (string val in m_trueValues) if (String.Compare(text, val, true) == 0) return true;
            foreach (string val in m_falseValues) if (String.Compare(text, val, true) == 0) return false;
            return null;
        }

        public void WriteErrorDefault(TypeStorage type, ICdlValueWriter writer)
        {
            if (type.IsNumber()) writer.SetIntegerValue(type, m_defaultNumber);
            else if (type.IsDateRelated()) writer.SetDateTimeValue(type, m_defaultDateTime);
            else if (type == TypeStorage.Boolean) writer.SetBoolean(m_defautlLogical);
            else writer.SetNull();
        }
    }
}
