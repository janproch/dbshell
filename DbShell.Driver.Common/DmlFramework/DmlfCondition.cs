using System;
using System.Xml;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DmlFramework
{
    public abstract class DmlfConditionBase : DmlfBase
    {
    }

    public class DmlfBinaryCondition : DmlfConditionBase
    {
        public DmlfExpression LeftExpr { get; set; }
        public DmlfExpression RightExpr { get; set; }

        public override void ForEachChild(Action<IDmlfNode> action)
        {
            base.ForEachChild(action);
            action(LeftExpr);
            action(RightExpr);
        }

        public override void SaveToXml(XmlElement xml)
        {
            base.SaveToXml(xml);
            if (LeftExpr != null) LeftExpr.SaveToXml(xml.AddChild("LeftExpr"));
            if (RightExpr != null) RightExpr.SaveToXml(xml.AddChild("RightExpr"));
        }

        public override void LoadFromXml(XmlElement xml)
        {
            base.LoadFromXml(xml);
            var xl = xml.FindElement("LeftExpr");
            if (xl != null) LeftExpr = DmlfExpression.Load(xl);
            var xr = xml.FindElement("RightExpr");
            if (xr != null) RightExpr = DmlfExpression.Load(xr);
        }
    }

    public class DmlfEqualCondition : DmlfBinaryCondition
    {
        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            LeftExpr.GenSql(dmp, handler);
            dmp.Put("=");
            RightExpr.GenSql(dmp, handler);
        }
    }

    public class DmlfLikeCondition : DmlfBinaryCondition
    {
        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            LeftExpr.GenSql(dmp, handler);
            dmp.Put(" ^like ");
            RightExpr.GenSql(dmp, handler);
        }
    }

    public abstract class DmlfCompoudCondition : DmlfConditionBase
    {
        public DmlfList<DmlfConditionBase> Conditions { get; set; }
        public DmlfCompoudCondition()
        {
            Conditions = new DmlfList<DmlfConditionBase>();
        }
        public virtual void GenSqlBegin(ISqlDumper dmp) { }
        public virtual void GenSqlEnd(ISqlDumper dmp) { }
        public abstract void GenSqlConjuction(ISqlDumper dmp);
        public abstract void GenSqlEmpty(ISqlDumper dmp);
        public virtual void GenSqlItem(DmlfConditionBase item, ISqlDumper dmp, IDmlfHandler handler)
        {
            item.GenSql(dmp, handler);
        }
        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            if (Conditions.Count == 0)
            {
                GenSqlEmpty(dmp);
            }
            else
            {
                GenSqlBegin(dmp);
                bool was = false;
                foreach (var item in Conditions)
                {
                    if (was) GenSqlConjuction(dmp);
                    GenSqlItem(item, dmp, handler);
                    was = true;
                }
                GenSqlEnd(dmp);
            }
        }
    }

    public class DmlfAndCondition : DmlfCompoudCondition
    {
        public override void GenSqlConjuction(ISqlDumper dmp)
        {
            dmp.Put(" ^and ");
        }
        public override void GenSqlEmpty(ISqlDumper dmp)
        {
            dmp.Put("1=1");
        }
    }

    public class DmlfOrCondition : DmlfCompoudCondition
    {
        public override void GenSqlConjuction(ISqlDumper dmp)
        {
            dmp.Put(" ^or ");
        }
        public override void GenSqlEmpty(ISqlDumper dmp)
        {
            dmp.Put("1=0");
        }
    }

    public class DmlfFalseCondition : DmlfConditionBase
    {
        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            dmp.Put("1=0");
        }
    }
}
