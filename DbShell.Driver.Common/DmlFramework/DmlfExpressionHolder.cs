using System.Xml;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfExpressionHolder : DmlfBase
    {
        public DmlfExpression Expr { get; set; }

        public override void SaveToXml(XmlElement xml)
        {
            base.SaveToXml(xml);
            if (Expr != null) Expr.SaveToXml(xml.AddChild("Expr"));
        }

        public override void LoadFromXml(XmlElement xml)
        {
            base.LoadFromXml(xml);
            var xe = xml.FindElement("Expr");
            if (xe != null) Expr = DmlfExpression.Load(xe);
        }

        public override string ToString()
        {
            if (Expr != null) return Expr.ToString();
            return "(null)";
        }

        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            Expr.GenSql(dmp, handler);
        }

        public DmlfColumnRef Column
        {
            get
            {
                var ce = Expr as DmlfColumnRefExpression;
                if (ce != null) return ce.Column;
                return null;
            }
        }

        public DmlfSource Source
        {
            get
            {
                var col = Column;
                if (col != null) return col.Source;
                return null;
            }
        }
    }
}