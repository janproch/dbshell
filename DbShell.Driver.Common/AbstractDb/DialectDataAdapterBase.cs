using System;
using System.Data;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.AbstractDb
{
    public abstract class DialectDataAdapterBase : IDialectDataAdapter
    {
        protected bool m_allowZeroInDate = false;
        protected ILiteralFormatter m_literalFormatter;
        protected IDatabaseFactory m_factory;
        CdlValueHolder m_holder = new CdlValueHolder();

        //string EscapeString(string value);
        //string QuoteString(string value);
        //string EscapeDateTime(DateTime value);
        //string EscapeBinary(byte[] value);
        //string EscapeNumber(object number);
        //string EscapeLogical(bool value);

        public DialectDataAdapterBase(IDatabaseFactory factory)
        {
            m_factory = factory;
            m_literalFormatter = factory.CreateLiteralFormatter();
        }

        protected virtual void ApplyTypeRestrictions(CdlValueHolder holder, DbTypeBase type)
        {
            var stype = type as DbTypeString;
            var htype = holder.GetFieldType();
            if (stype != null && htype == TypeStorage.String)
            {
                string sval = holder.GetString();
                if (stype.Length > 0 && sval.Length > stype.Length)
                {
                    sval = sval.Substring(0, stype.Length);
                    holder.SetString(sval);
                }
            }
            if (htype.IsDateRelated() && !m_allowZeroInDate)
            {
                var dt = holder.GetDateTimeValue();

                if (dt.MakeValidDate())
                {
                    m_holder.SetDateTimeEx(dt);
                }
            }
        }

        #region IDialectDataAdapter Members

        public void AdaptValue(ICdlValueReader reader, DbTypeBase type, ICdlValueWriter writer, ICdlValueConvertor converter)
        {
            if (reader.GetFieldType() == TypeStorage.Null)
            {
                m_holder.SetNull();
            }
            else
            {
                ConvertNotNullValue(reader, type, m_holder, converter);
                ApplyTypeRestrictions(m_holder, type);
            }
            writer.ReadFrom(m_holder);
        }

        protected virtual void ConvertNotNullValue(ICdlValueReader reader, DbTypeBase type, CdlValueHolder valueHolder, ICdlValueConvertor converter)
        {
            converter.ConvertValue(reader, type.DefaultStorage, valueHolder);
        }

        public virtual ICdlReader AdaptReader(IDataReader reader, bool includeHiddenColumns, IDbCommand command = null)
        {
            return new DataReaderAdapter(reader, m_factory, includeHiddenColumns, command);
        }

        public virtual string GetFulltextSearchExpr(string expr, string substring, FulltextSearchParams pars)
        {
            substring = substring.Replace("@", "@@").Replace("%", "@%").Replace("_", "@_");
            return String.Format("({0} LIKE {1} ESCAPE '@')", expr, this.GetSqlLiteral(pars.LikePrefix + substring + pars.LikePostfix, new DbTypeString()));
        }

        public string GetSqlLiteral(ICdlValueReader reader, DbTypeBase type)
        {
            //m_literalFormatter.TargetType = type;
            m_literalFormatter.ReadFrom(reader);
            return m_literalFormatter.GetText();
        }

        public string GetSqlLiteral(object value, DbTypeBase type)
        {
            m_holder.ReadFrom(value);
            return GetSqlLiteral(m_holder, type);
        }

        public virtual string FilterNotDumpableCharacters(string value)
        {
            return value;
        }

        #endregion
    }
}
