using System;
using System.Xml;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DmlFramework
{
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

        public override void GenSql(ISqlDumper dmp)
        {
            Column.GenSql(dmp);
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
}