using System;
using System.Data;
using DbShell.Driver.Common.CommonDataLayer;

namespace DbShell.Driver.Common.CommonTypeSystem
{
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