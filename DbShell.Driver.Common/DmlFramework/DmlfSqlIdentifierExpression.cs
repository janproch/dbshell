using System.Collections.Generic;
using System.Xml;
using DbShell.Driver.Common.AbstractDb;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfSqlIdentifierExpression : DmlfStringValueExpressionBase
    {
        public DmlfSqlIdentifierExpression()
        {
        }

        public DmlfSqlIdentifierExpression(XmlElement xml)
        {
            LoadFromXml(xml);
        }

        public override void GenSql(ISqlDumper dmp)
        {
            dmp.Put("&r"); // dump separator if needed
            dmp.WriteRaw(Value);
        }

        protected override string GetTypeName()
        {
            return "ident";
        }
    }
}