namespace DbShell.Driver.Common.CommonDataLayer
{
    public sealed class CdlValueConvertor : ICdlValueConvertor
    {
        CdlValueParser m_parser;
        CdlValueFormatter m_formatter;
        CdlValueHolder m_holder1 = new CdlValueHolder();
        CdlValueHolder m_holder2 = new CdlValueHolder();

        public CdlValueConvertor(DataFormatSettings settings)
        {
            m_parser = new CdlValueParser(settings);
            m_formatter = new CdlValueFormatter(settings);
        }

        #region ICdlValueConvertor Members

        public ICdlValueFormatter Formatter { get { return m_formatter; } }
        public ICdlValueParser Parser { get { return m_parser; } }

        public void ConvertValue(ICdlValueReader reader, TypeStorage dsttype, ICdlValueWriter writer)
        {
            var srctype = reader.GetFieldType();
            if (srctype == dsttype)
            {
                // no conversion needed
                writer.ReadFrom(reader);
                return;
            }
            if (srctype.IsNumber() && dsttype.IsNumber())
            {
                if (dsttype.IsInteger())
                {
                    writer.SetIntegerValue(dsttype, reader.GetIntegerValue());
                }
                else
                {
                    writer.SetRealValue(dsttype, reader.GetRealValue());
                }
                return;
            }
            if (srctype.IsDateRelated() && dsttype.IsDateRelated())
            {
                writer.SetDateTimeValue(dsttype, reader.GetDateTimeValue());
                return;
            }
            if (srctype == TypeStorage.Boolean && dsttype.IsNumber())
            {
                bool val = reader.GetBoolean();
                writer.SetIntegerValue(dsttype, val ? 1 : 0);
                return;
            }
            if (srctype.IsNumber() && dsttype == TypeStorage.Boolean)
            {
                long val = reader.GetIntegerValue();
                writer.SetBoolean(val != 0);
                return;
            }
            if (srctype == TypeStorage.String)
            {
                // parse
                m_parser.ParseValue(reader.GetString(), dsttype, writer);
                return;
            }
            if (dsttype == TypeStorage.String)
            {
                // format
                m_formatter.ReadFrom(reader);
                writer.SetString(m_formatter.GetText());
                return;
            }
            {
                // most generic case - format and than parse
                m_formatter.ReadFrom(reader);
                m_parser.ParseValue(m_formatter.GetText(), dsttype, writer);
                return;
            }
        }

        #endregion

        public object ConvertValue(TypeStorage type, object value)
        {
            m_holder1.ReadFrom(value);
            var srctype = m_holder1.GetFieldType();
            if (srctype == type || srctype == TypeStorage.Null) return value;
            ConvertValue(m_holder1, type, m_holder2);
            return m_holder2.BoxTypedValue();
        }
    }
}
