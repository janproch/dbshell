using System;
using System.Data;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.AbstractDb
{
    public abstract class DialectDataAdapterBase : IDialectDataAdapter
    {
        protected bool m_allowZeroInDate = false;
        protected SqlLiteralFormatter m_literalFormatter;
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
            m_literalFormatter = CreateLiteralFormatter();
        }

        public virtual SqlLiteralFormatter CreateLiteralFormatter()
        {
            return new SqlLiteralFormatter(m_factory);
        }

        //protected virtual void ApplyTypeRestrictions(CdlValueHolder holder, DbTypeBase type, ILogger logger)
        //{
        //    var stype = type as DbTypeString;
        //    var htype = holder.GetFieldType();
        //    if (stype != null && htype == TypeStorage.String)
        //    {
        //        string sval = holder.GetString();
        //        if (stype.Length > 0 && sval.Length > stype.Length)
        //        {
        //            sval = sval.Substring(0, stype.Length);
        //            holder.SetString(sval);
        //        }
        //    }
        //    if (htype.IsDateRelated() && !m_allowZeroInDate)
        //    {
        //        var dt = holder.GetDateTimeValue();
        //        dt.MakeValidDate();
        //        m_holder.SetDateTimeEx(dt);
        //    }
        //}

        #region IDialectDataAdapter Members

        public void AdaptValue(ICdlValueReader reader, DbTypeBase type, ICdlValueWriter writer, ICdlValueConvertor converter)
        {
            if (reader.GetFieldType() == TypeStorage.Null)
            {
                m_holder.SetNull();
            }
            else
            {
                converter.ConvertValue(reader, type.DefaultStorage, m_holder);
                //ApplyTypeRestrictions(m_holder, type, logger);
            }
            writer.ReadFrom(m_holder);
        }

        public virtual ICdlReader AdaptReader(IDataReader reader)
        {
            return new DataReaderAdapter(reader, m_factory);
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
