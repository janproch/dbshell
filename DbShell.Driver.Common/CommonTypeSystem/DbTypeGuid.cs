using System;
using System.Data;
using DbShell.Driver.Common.CommonDataLayer;

namespace DbShell.Driver.Common.CommonTypeSystem
{
    public class DbTypeGuid : DbTypeBase
    {
        public override DbTypeCode Code
        {
            get { return DbTypeCode.Guid; }
        }
        public override Type DotNetType
        {
            get { return typeof(String); }
        }
        public override string ToString()
        {
            return "guid";
        }
        public override DbType GetProviderType()
        {
            return DbType.Guid;
        }
        public override string XsdType
        {
            get { return "xs:string"; }
        }
        public override TypeStorage DefaultStorage
        {
            get { return TypeStorage.Guid; }
        }
    }
}