using System.Xml;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfStringExpression : DmlfStringValueExpressionBase, IExplicitXmlPersistent
    {
        public DmlfStringExpression() { }
        public DmlfStringExpression(XmlElement xml)
        {
            LoadFromXml(xml);
        }

        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            dmp.Put("%v", Value);
        }

        protected override string GetTypeName()
        {
            return "str";
        }
    }
}