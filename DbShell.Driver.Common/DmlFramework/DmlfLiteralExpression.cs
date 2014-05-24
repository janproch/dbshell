using System.Xml;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfLiteralExpression : DmlfExpression
    {
        public object Value { get; set; }

        public DmlfLiteralExpression () { }
        public DmlfLiteralExpression(XmlElement xml)
        {
            LoadFromXml(xml);
        }

        public override void SaveToXml(XmlElement xml)
        {
            base.SaveToXml(xml);
            CdlTool.SaveValueToXml(Value, xml);
        }

        public override void LoadFromXml(XmlElement xml)
        {
            base.LoadFromXml(xml);
            Value = CdlTool.LoadValueFromXml(xml);
        }

        public override string ToString()
        {
            return Value.SafeToString();
        }

        public override int GetHashCode()
        {
            if (Value != null) return Value.GetHashCode();
            return 0;
        }

        public override bool DmlfEquals(DmlfBase obj)
        {
            var o = (DmlfLiteralExpression)obj;
            string xtype1 = "", xdata1 = "";
            string xtype2 = "", xdata2 = "";
            bool b1 = CdlTool.GetValueAsXml(Value, ref xtype1, ref xdata1);
            bool b2 = CdlTool.GetValueAsXml(Value, ref xtype2, ref xdata2);
            if (b1 != b2) return false;
            if (xtype1 != xtype2) return false;
            if (xdata1 != xdata2) return false;
            return true;
        }

        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            dmp.Put("%v", Value);
        }

        protected override string GetTypeName()
        {
            return "lit";
        }
    }
}