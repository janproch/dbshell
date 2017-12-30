using System;
using System.ComponentModel;
using System.Data;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Utility;
using System.Runtime.Serialization;

namespace DbShell.Driver.Common.CommonTypeSystem
{
    [DataContract]
    public class DbTypeBlob : DbTypeBase
    {
        DbSizeType m_size = DbSizeType.Normal;
        [DisplayName("s_size")]
        [XmlAttrib("size")]
        [DataMember]
        public DbSizeType Size
        {
            get { return m_size; }
            set { m_size = value; }
        }

        public override DbTypeCode Code
        {
            get { return DbTypeCode.Blob; }
        }
        public override Type DotNetType
        {
            get { return typeof(Byte[]); }
        }
        public override string ToString()
        {
            return "blob";
        }
        public override DbType GetProviderType()
        {
            return DbType.Binary;
        }
        public override string XsdType
        {
            get { return "xs:base64Binary"; }
        }
        public override TypeStorage DefaultStorage
        {
            get { return TypeStorage.ByteArray; }
        }
        public override bool IsBinaryType()
        {
            return true;
        }
    }
}