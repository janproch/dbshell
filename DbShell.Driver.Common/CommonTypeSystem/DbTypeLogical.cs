using System;
using System.Data;
using DbShell.Driver.Common.CommonDataLayer;
using System.Runtime.Serialization;

namespace DbShell.Driver.Common.CommonTypeSystem
{
    [DataContract]
    public class DbTypeLogical : DbTypeBase
    {
        public override DbTypeCode Code
        {
            get { return DbTypeCode.Logical; }
        }
        public override Type DotNetType
        {
            get { return typeof(Boolean); }
        }
        public override string ToString()
        {
            return "logical";
        }
        public override DbType GetProviderType()
        {
            return DbType.Boolean;
        }
        public override string XsdType
        {
            get { return "xs:boolean"; }
        }
        public override TypeStorage DefaultStorage
        {
            get { return TypeStorage.Boolean; }
        }
    }
}