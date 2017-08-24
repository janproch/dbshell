using System;
using System.ComponentModel;
using System.Data;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Utility;
using System.Runtime.Serialization;

namespace DbShell.Driver.Common.CommonTypeSystem
{
    [DataContract]
    public class DbTypeGeneric : DbTypeBase
    {
        string m_sql;
        [DisplayName("SQL")]
        [XmlAttrib("sql")]
        [DataMember]
        public string Sql
        {
            get { return m_sql; }
            set { m_sql = value; }
        }

        public override DbTypeCode Code
        {
            get { return DbTypeCode.Generic; }
        }
        public override Type DotNetType
        {
            get { return typeof(String); }
        }
        public override string ToString()
        {
            return m_sql;
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
            get { return TypeStorage.String; }
        }

        public static DbTypeGeneric Unknown()
        {
            return new DbTypeGeneric { Sql = "unknown" };
        }
    }
}
