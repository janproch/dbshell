using System;
using System.Xml;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DmlFramework
{
    public abstract class DmlfExpression : DmlfBase
    {
        public static DmlfExpression Load(XmlElement xml)
        {
            string type = xml.GetAttribute("type");
            switch (type)
            {
                case "col":
                    return new DmlfColumnRefExpression(xml);
                case "val":
                    return new DmlfSqlValueExpression(xml);
                case "str":
                    return new DmlfStringExpression(xml);
                case "lit":
                    return new DmlfLiteralExpression(xml);
            }
            throw new InternalError("DBSH-00041 Unkown DMLF expression type:" + type);
        }

        public override void SaveToXml(XmlElement xml)
        {
            base.SaveToXml(xml);
            xml.SetAttribute("type", GetTypeName());
        }

        protected abstract string GetTypeName();
    }

    public class DmlfColumnRefExpression : DmlfExpression
    {
        public DmlfColumnRef Column { get; set; }

        public DmlfColumnRefExpression() { }
        public DmlfColumnRefExpression(XmlElement xml)
        {
            LoadFromXml(xml);
        }

        public override void ForEachChild(Action<IDmlfNode> action)
        {
            base.ForEachChild(action);
            action(Column);
        }

        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            Column.GenSql(dmp, handler);
        }

        public override void SaveToXml(XmlElement xml)
        {
            base.SaveToXml(xml);
            if (Column != null) Column.SaveProperties(xml);
        }

        public override void LoadFromXml(XmlElement xml)
        {
            base.LoadFromXml(xml);
            Column = new DmlfColumnRef();
            Column.LoadProperties(xml);
        }

        public override string ToString()
        {
            if (Column != null) return Column.ToString();
            return "(null)";
        }

        protected override string GetTypeName()
        {
            return "col";
        }

        public override int GetHashCode()
        {
            if (Column != null) return Column.GetHashCode();
            return 0;
        }

        public override bool DmlfEquals(DmlfBase obj)
        {
            var o = (DmlfColumnRefExpression)obj;
            return Column == o.Column;
        }
    }

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
    }

    public class DmlfSqlValueExpression : DmlfStringValueExpressionBase
    {
        public DmlfSqlValueExpression() { }
        public DmlfSqlValueExpression(XmlElement xml)
        {
            LoadFromXml(xml);
        }

        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            dmp.WriteRaw(Value);
        }

        protected override string GetTypeName()
        {
            return "val";
        }
    }

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
