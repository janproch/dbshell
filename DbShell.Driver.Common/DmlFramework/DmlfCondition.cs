using System;
using System.Xml;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DmlFramework
{
    public abstract class DmlfConditionBase : DmlfBase
    {
    }

    public abstract class DmlfUnaryCondition : DmlfConditionBase
    {
        public DmlfExpression Expr { get; set; }

        public override void ForEachChild(Action<IDmlfNode> action)
        {
            base.ForEachChild(action);
            action(Expr);
        }
    }


    public class DmlfNotCondition : DmlfUnaryCondition
    {
        public DmlfConditionBase Expr { get; set; }

        public override void ForEachChild(Action<IDmlfNode> action)
        {
            base.ForEachChild(action);
            action(Expr);
        }

        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            dmp.Put("(^not(");
            Expr.GenSql(dmp, handler);
            dmp.Put("))");
        }
    }

    public class DmlfIsNullCondition : DmlfUnaryCondition
    {
        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            Expr.GenSql(dmp, handler);
            dmp.Put(" ^is ^null");
        }
    }

    public class DmlfIsNotNullCondition : DmlfUnaryCondition
    {
        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            Expr.GenSql(dmp, handler);
            dmp.Put(" ^is ^not ^null");
        }
    }

    public class DmlfLiteralCondition : DmlfConditionBase
    {
        private string _literal;

        public DmlfLiteralCondition(string literal)
        {
            _literal = literal;
        }

        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            dmp.WriteRaw(_literal);
        }
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

    public abstract class DmlfBetweenConditionBase : DmlfConditionBase
    {
        public DmlfExpression Expr { get; set; }
        public DmlfExpression LowerBound { get; set; }
        public DmlfExpression UpperBound { get; set; }

        public override void ForEachChild(Action<IDmlfNode> action)
        {
            base.ForEachChild(action);
            action(Expr);
            action(LowerBound);
            action(UpperBound);
        }

        public override void SaveToXml(XmlElement xml)
        {
            base.SaveToXml(xml);
            if (Expr != null) Expr.SaveToXml(xml.AddChild("Expr"));
            if (LowerBound != null) LowerBound.SaveToXml(xml.AddChild("LowerBound"));
            if (UpperBound != null) UpperBound.SaveToXml(xml.AddChild("UpperBound"));
        }

        public override void LoadFromXml(XmlElement xml)
        {
            base.LoadFromXml(xml);
            var xe = xml.FindElement("Expr");
            if (xe != null) Expr = DmlfExpression.Load(xe);
            var xl = xml.FindElement("LowerBound");
            if (xl != null) LowerBound = DmlfExpression.Load(xl);
            var xu = xml.FindElement("UpperBound");
            if (xu != null) UpperBound = DmlfExpression.Load(xu);
        }

        protected abstract void DumpOperator(ISqlDumper dmp);

        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            Expr.GenSql(dmp, handler);
            DumpOperator(dmp);
            LowerBound.GenSql(dmp, handler);
            dmp.Put(" ^and ");
            UpperBound.GenSql(dmp, handler);
        }
    }

    public class DmlfBetweenCondition : DmlfBetweenConditionBase
    {
        protected override void DumpOperator(ISqlDumper dmp)
        {
            dmp.Put(" ^between ");
        }
    }

    public class DmlfNotBetweenCondition : DmlfBetweenConditionBase
    {
        protected override void DumpOperator(ISqlDumper dmp)
        {
            dmp.Put(" ^not ^between ");
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

    public class DmlfNotEqualCondition : DmlfBinaryCondition
    {
        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            LeftExpr.GenSql(dmp, handler);
            dmp.Put("<>");
            RightExpr.GenSql(dmp, handler);
        }
    }

    public class DmlfGreaterCondition : DmlfBinaryCondition
    {
        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            LeftExpr.GenSql(dmp, handler);
            dmp.Put(">");
            RightExpr.GenSql(dmp, handler);
        }
    }

    public class DmlfGreaterEqualCondition : DmlfBinaryCondition
    {
        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            LeftExpr.GenSql(dmp, handler);
            dmp.Put(">=");
            RightExpr.GenSql(dmp, handler);
        }
    }

    public class DmlfLessCondition : DmlfBinaryCondition
    {
        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            LeftExpr.GenSql(dmp, handler);
            dmp.Put("<");
            RightExpr.GenSql(dmp, handler);
        }
    }

    public class DmlfLessEqualCondition : DmlfBinaryCondition
    {
        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            LeftExpr.GenSql(dmp, handler);
            dmp.Put("<=");
            RightExpr.GenSql(dmp, handler);
        }
    }

    public class DmlfRelationCondition : DmlfBinaryCondition
    {
        public string Relation = "=";

        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            LeftExpr.GenSql(dmp, handler);
            dmp.Put(Relation);
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

    public class DmlfNotLikeCondition : DmlfBinaryCondition
    {
        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            LeftExpr.GenSql(dmp, handler);
            dmp.Put(" ^not ^like ");
            RightExpr.GenSql(dmp, handler);
        }
    }

    public class DmlfInCondition : DmlfBinaryCondition
    {
        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            LeftExpr.GenSql(dmp, handler);
            dmp.Put(" ^in ");
            RightExpr.GenSql(dmp, handler);
        }
    }

    public class DmlfNotInCondition : DmlfBinaryCondition
    {
        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            LeftExpr.GenSql(dmp, handler);
            dmp.Put(" ^not ^in ");
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

        public virtual void GenSqlBegin(ISqlDumper dmp)
        {
            dmp.Put("(");
        }

        public virtual void GenSqlEnd(ISqlDumper dmp)
        {
            dmp.Put(")");
        }

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
            dmp.Put("(1=1)");
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
            dmp.Put("(1=0)");
        }
    }

    public class DmlfFalseCondition : DmlfConditionBase
    {
        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            dmp.Put("(1=0)");
        }
    }

    public class DmlfExistCondition : DmlfConditionBase
    {
        public DmlfSelect Select;

        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            dmp.Put("^exists (");
            Select.GenSql(dmp, handler);
            dmp.Put(")");
        }
    }
}
