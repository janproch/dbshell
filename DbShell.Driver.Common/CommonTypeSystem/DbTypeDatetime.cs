using System;
using System.Data;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.CommonTypeSystem
{
    public class DbTypeDatetime : DbTypeBase
    {
        DbDatetimeSubType m_subType = DbDatetimeSubType.Datetime;
        [XmlAttrib("subtype")]
        public DbDatetimeSubType SubType
        {
            get { return m_subType; }
            set { m_subType = value; }
        }

        bool m_hasTimeZone = false;
        [XmlAttrib("hastimezone")]
        public bool HasTimeZone
        {
            get { return m_hasTimeZone; }
            set { m_hasTimeZone = value; }
        }

        public override DbTypeCode Code
        {
            get { return DbTypeCode.Datetime; }
        }
        public override Type DotNetType
        {
            get { return typeof(DateTime); }
        }
        public override string ToString()
        {
            return "datetime";
        }
        public override DbType GetProviderType()
        {
            return DbType.DateTime;
        }
        public override string XsdType
        {
            get
            {
                switch (m_subType)
                {
                    case DbDatetimeSubType.Interval: return "xs:duration";
                }
                return "xs:dateTime";
            }
        }
        public override TypeStorage DefaultStorage
        {
            get
            {
                switch (m_subType)
                {
                    case DbDatetimeSubType.Date:
                        return TypeStorage.DateEx;
                    case DbDatetimeSubType.Datetime:
                        return TypeStorage.DateTimeEx;
                    case DbDatetimeSubType.Time:
                        return TypeStorage.TimeEx;
                    case DbDatetimeSubType.Year:
                        return TypeStorage.Int16;
                    case DbDatetimeSubType.Interval:
                        return TypeStorage.String;
                }
                return TypeStorage.DateTimeEx;
            }
        }
    }
}