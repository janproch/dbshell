using System.Xml;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfPlaceholderExpression : DmlfStringValueExpressionBase
    {
        public DmlfPlaceholderExpression()
        {
        }

        public DmlfPlaceholderExpression(XmlElement xml)
        {
            LoadFromXml(xml);
        }

        protected override string GetTypeName()
        {
            return "placeholder";
        }

        public override object EvalExpression(IDmlfNamespace ns)
        {
            return ns.GetValue(Value);
        }
    }
}