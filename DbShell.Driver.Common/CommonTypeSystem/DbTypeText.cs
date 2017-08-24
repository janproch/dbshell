using System;
using System.Data;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Utility;
using System.Runtime.Serialization;

namespace DbShell.Driver.Common.CommonTypeSystem
{
    [DataContract]
    public class DbTypeText : DbTypeBase
    {
        DbSizeType m_size = DbSizeType.Normal;
        [XmlAttrib("size")]
        [DataMember]
        public DbSizeType Size
        {
            get { return m_size; }
            set { m_size = value; }
        }

        bool m_isUnicode = false;
        [XmlAttrib("unicode")]
        [DataMember]
        public bool IsUnicode
        {
            get { return m_isUnicode; }
            set { m_isUnicode = value; }
        }

        public override DbTypeCode Code
        {
            get { return DbTypeCode.Text; }
        }
        public override Type DotNetType
        {
            get { return typeof(String); }
        }
        public override string ToString()
        {
            return "text";
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
    }
}