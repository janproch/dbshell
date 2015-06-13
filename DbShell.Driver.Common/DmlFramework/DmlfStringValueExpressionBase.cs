using System.Xml;

namespace DbShell.Driver.Common.DmlFramework
{
    public abstract class DmlfStringValueExpressionBase : DmlfExpression
    {
        public string Value { get; set; }

        public override void SaveToXml(XmlElement xml)
        {
            base.SaveToXml(xml);
            if (Value != null) xml.InnerText = Value;
        }

        public override void LoadFromXml(XmlElement xml)
        {
            base.LoadFromXml(xml);
            Value = xml.InnerText;
        }

        public override string ToString()
        {
            return Value;
        }

        public override int GetHashCode()
        {
            if (Value != null) return Value.GetHashCode();
            return 0;
        }

        public override bool DmlfEquals(DmlfBase obj)
        {
            var o = (DmlfStringValueExpressionBase)obj;
            return Value == o.Value;
        }

        public override object EvalExpression(IDmlfNamespace ns)
        {
            return Value;
        }
    }
}