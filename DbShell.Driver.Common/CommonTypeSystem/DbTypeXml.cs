using System;
using System.Data;
using DbShell.Driver.Common.CommonDataLayer;
using System.Runtime.Serialization;

namespace DbShell.Driver.Common.CommonTypeSystem
{
    [DataContract]
    public class DbTypeXml : DbTypeBase
    {
        public override DbTypeCode Code
        {
            get { return DbTypeCode.Xml; }
        }
        public override Type DotNetType
        {
            get { return typeof(String); }
        }
        public override string ToString()
        {
            return "xml";
        }
        public override DbType GetProviderType()
        {
            return DbType.Xml;
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