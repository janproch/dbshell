using System;
using System.Globalization;
using System.Linq;
using System.Xml;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DmlFramework
{
    public abstract class DmlfConditionBase : DmlfBase
    {
        public virtual bool EvalCondition(IDmlfNamespace ns)
        {
            throw new InternalError("DBSH-00156 Eval not implemented:" + GetType().FullName);
        }
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


    public class DmlfNotCondition : DmlfConditionBase
    {
        public DmlfConditionBase Expr { get; set; }

        public override void ForEachChild(Action<IDmlfNode> action)
        {
            base.ForEachChild(action);
            action(Expr);
        }

        public override void GenSql(ISqlDumper dmp)
        {
            dmp.Put("(^not(");
            Expr.GenSql(dmp);
            dmp.Put("))");
        }

        public override bool EvalCondition(IDmlfNamespace ns)
        {
            return !Expr.EvalCondition(ns);
        }
    }

    public class DmlfIsNullCondition : DmlfUnaryCondition
    {
        public override void GenSql(ISqlDumper dmp)
        {
            Expr.GenSql(dmp);
            dmp.Put(" ^is ^null");
        }

        public override bool EvalCondition(IDmlfNamespace ns)
        {
            object value = Expr.EvalExpression(ns);
            return value == null || value == DBNull.Value;
        }
    }

    public class DmlfIsNotNullCondition : DmlfUnaryCondition
    {
        public override void GenSql(ISqlDumper dmp)
        {
            Expr.GenSql(dmp);
            dmp.Put(" ^is ^not ^null");
        }

        public override bool EvalCondition(IDmlfNamespace ns)
        {
            object value = Expr.EvalExpression(ns);
            return value != null && value != DBNull.Value;
        }
    }

    public class DmlfLiteralCondition : DmlfConditionBase
    {
        private string _literal;

        public DmlfLiteralCondition(string literal)
        {
            _literal = literal;
        }

        public override void GenSql(ISqlDumper dmp)
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

        public override void GenSql(ISqlDumper dmp)
        {
            Expr.GenSql(dmp);
            DumpOperator(dmp);
            LowerBound.GenSql(dmp);
            dmp.Put(" ^and ");
            UpperBound.GenSql(dmp);
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
        public override void GenSql(ISqlDumper dmp)
        {
            LeftExpr.GenSql(dmp);
            dmp.Put("=");
            RightExpr.GenSql(dmp);
        }

        public override bool EvalCondition(IDmlfNamespace ns)
        {
            return DmlfRelationCondition.EvalRelation(LeftExpr, RightExpr, "=", ns);
        }
    }

    public class DmlfNotEqualCondition : DmlfBinaryCondition
    {
        public override void GenSql(ISqlDumper dmp)
        {
            LeftExpr.GenSql(dmp);
            dmp.Put("<>");
            RightExpr.GenSql(dmp);
        }

        public override bool EvalCondition(IDmlfNamespace ns)
        {
            return DmlfRelationCondition.EvalRelation(LeftExpr, RightExpr, "<>", ns);
        }
    }

    public class DmlfGreaterCondition : DmlfBinaryCondition
    {
        public override void GenSql(ISqlDumper dmp)
        {
            LeftExpr.GenSql(dmp);
            dmp.Put(">");
            RightExpr.GenSql(dmp);
        }

        public override bool EvalCondition(IDmlfNamespace ns)
        {
            return DmlfRelationCondition.EvalRelation(LeftExpr, RightExpr, ">", ns);
        }
    }

    public class DmlfGreaterEqualCondition : DmlfBinaryCondition
    {
        public override void GenSql(ISqlDumper dmp)
        {
            LeftExpr.GenSql(dmp);
            dmp.Put(">=");
            RightExpr.GenSql(dmp);
        }

        public override bool EvalCondition(IDmlfNamespace ns)
        {
            return DmlfRelationCondition.EvalRelation(LeftExpr, RightExpr, ">=", ns);
        }
    }

    public class DmlfLessCondition : DmlfBinaryCondition
    {
        public override void GenSql(ISqlDumper dmp)
        {
            LeftExpr.GenSql(dmp);
            dmp.Put("<");
            RightExpr.GenSql(dmp);
        }

        public override bool EvalCondition(IDmlfNamespace ns)
        {
            return DmlfRelationCondition.EvalRelation(LeftExpr, RightExpr, "<", ns);
        }
    }

    public class DmlfLessEqualCondition : DmlfBinaryCondition
    {
        public override void GenSql(ISqlDumper dmp)
        {
            LeftExpr.GenSql(dmp);
            dmp.Put("<=");
            RightExpr.GenSql(dmp);
        }

        public override bool EvalCondition(IDmlfNamespace ns)
        {
            return DmlfRelationCondition.EvalRelation(LeftExpr, RightExpr, "<=", ns);
        }
    }

    public class DmlfRelationCondition : DmlfBinaryCondition
    {
        public string Relation = "=";
        public string CollateSpec;

        public override void GenSql(ISqlDumper dmp)
        {
            LeftExpr.GenSql(dmp);
            if (CollateSpec != null)
            {
                dmp.Put(" ^collate %s ", CollateSpec);
            }
            dmp.Put(Relation);
            RightExpr.GenSql(dmp);
            if (CollateSpec != null)
            {
                dmp.Put(" ^collate %s ", CollateSpec);
            }
        }

        public override bool EvalCondition(IDmlfNamespace ns)
        {
            return EvalRelation(LeftExpr, RightExpr, Relation, ns);
        }

        public static bool EvalRelation(DmlfExpression leftExpr, DmlfExpression rightExpr, string relation, IDmlfNamespace ns)
        {
            object left = leftExpr.EvalExpression(ns);
            object right = rightExpr.EvalExpression(ns);

            if (left == null || right == null) return false;

            var leftType = left.GetType();
            var rightType = right.GetType();

            string leftStr = Convert.ToString(left, CultureInfo.InvariantCulture);
            string rightStr = Convert.ToString(right, CultureInfo.InvariantCulture);

            if (leftType.IsNumberType() || rightType.IsNumberType())
            {
                double leftValue, rightValue;
                if (Double.TryParse(leftStr, NumberStyles.Number, CultureInfo.InvariantCulture, out leftValue) 
                    && Double.TryParse(rightStr, NumberStyles.Number, CultureInfo.InvariantCulture, out rightValue))
                {
                    switch (relation)
                    {
                        case "=":
                            return leftValue == rightValue;
                        case "<=":
                            return leftValue <= rightValue;
                        case ">=":
                            return leftValue >= rightValue;
                        case "<":
                            return leftValue < rightValue;
                        case ">":
                            return leftValue > rightValue;
                        case "<>":
                            return leftValue != rightValue;
                    }
                }
            }

            if (leftType == typeof(DateTime) || rightType == typeof(DateTime))
            {
                DateTime? leftValue = null, rightValue = null;
                DateTime tmp;
                if (leftType == typeof (DateTime))
                {
                    leftValue = (DateTime) left;
                }
                else if (DateTime.TryParse(leftStr, CultureInfo.InvariantCulture, DateTimeStyles.None, out tmp))
                {
                    leftValue = tmp;
                }
                if (rightType == typeof (DateTime))
                {
                    rightValue = (DateTime) right;
                }
                else if (DateTime.TryParse(leftStr, CultureInfo.InvariantCulture, DateTimeStyles.None, out tmp))
                {
                    rightValue = tmp;
                }
                if (leftValue.HasValue && rightValue.HasValue)
                {
                    switch (relation)
                    {
                        case "=":
                            return leftValue == rightValue;
                        case "<=":
                            return leftValue <= rightValue;
                        case ">=":
                            return leftValue >= rightValue;
                        case "<":
                            return leftValue < rightValue;
                        case ">":
                            return leftValue > rightValue;
                        case "<>":
                            return leftValue != rightValue;
                    }
                }
            }

            switch (relation)
            {
                case "=":
                    return System.String.Compare(leftStr, rightStr, System.StringComparison.OrdinalIgnoreCase) == 0;
                case "<=":
                    return System.String.Compare(leftStr, rightStr, System.StringComparison.OrdinalIgnoreCase) <= 0;
                case ">=":
                    return System.String.Compare(leftStr, rightStr, System.StringComparison.OrdinalIgnoreCase) >= 0;
                case "<":
                    return System.String.Compare(leftStr, rightStr, System.StringComparison.OrdinalIgnoreCase) < 0;
                case ">":
                    return System.String.Compare(leftStr, rightStr, System.StringComparison.OrdinalIgnoreCase) > 0;
                case "<>":
                    return System.String.Compare(leftStr, rightStr, System.StringComparison.OrdinalIgnoreCase) != 0;
            }

            return false;
        }
    }

    public class DmlfLikeCondition : DmlfBinaryCondition
    {
        public override void GenSql(ISqlDumper dmp)
        {
            LeftExpr.GenSql(dmp);
            dmp.Put(" ^like ");
            RightExpr.GenSql(dmp);
        }
    }

    public abstract class DmlfStringTestCondition : DmlfUnaryCondition
    {
        public string Value;

        public override bool EvalCondition(IDmlfNamespace ns)
        {
            if (Value == null) return false;
            object val = Expr.EvalExpression(ns);
            if (val == null) return false;
            return Test(Convert.ToString(val, CultureInfo.InvariantCulture));
        }

        protected abstract bool Test(string testedString);
    }

    public class DmlfStartsWithCondition : DmlfStringTestCondition
    {
        public override void GenSql(ISqlDumper dmp)
        {
            Expr.GenSql(dmp);
            dmp.Put(" ^like %v", Value + "%");
        }

        protected override bool Test(string testedString)
        {
            return testedString.StartsWith(Value, StringComparison.InvariantCultureIgnoreCase);
        }
    }

    public class DmlfEndsWithCondition : DmlfStringTestCondition
    {
        public override void GenSql(ISqlDumper dmp)
        {
            Expr.GenSql(dmp);
            dmp.Put(" ^like %v", "%" + Value);
        }

        protected override bool Test(string testedString)
        {
            return testedString.EndsWith(Value, StringComparison.InvariantCultureIgnoreCase);
        }
    }

    public class DmlfContainsTextCondition : DmlfStringTestCondition
    {
        public override void GenSql(ISqlDumper dmp)
        {
            Expr.GenSql(dmp);
            dmp.Put(" ^like %v", "%" + Value + "%");
        }

        protected override bool Test(string testedString)
        {
            return testedString.IndexOf(Value, StringComparison.InvariantCultureIgnoreCase) >= 0;
        }
    }

    public class DmlfNotLikeCondition : DmlfBinaryCondition
    {
        public override void GenSql(ISqlDumper dmp)
        {
            LeftExpr.GenSql(dmp);
            dmp.Put(" ^not ^like ");
            RightExpr.GenSql(dmp);
        }
    }

    public class DmlfInCondition : DmlfBinaryCondition
    {
        public override void GenSql(ISqlDumper dmp)
        {
            LeftExpr.GenSql(dmp);
            dmp.Put(" ^in ");
            RightExpr.GenSql(dmp);
        }
    }

    public class DmlfNotInCondition : DmlfBinaryCondition
    {
        public override void GenSql(ISqlDumper dmp)
        {
            LeftExpr.GenSql(dmp);
            dmp.Put(" ^not ^in ");
            RightExpr.GenSql(dmp);
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

        public virtual void GenSqlItem(DmlfConditionBase item, ISqlDumper dmp)
        {
            item.GenSql(dmp);
        }

        public override void GenSql(ISqlDumper dmp)
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
                    GenSqlItem(item, dmp);
                    was = true;
                }
                GenSqlEnd(dmp);
            }
        }

        public override void ForEachChild(Action<IDmlfNode> action)
        {
            base.ForEachChild(action);
            foreach(var child in Conditions)
            {
                child.ForEachChild(action);
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

        public override bool EvalCondition(IDmlfNamespace ns)
        {
            return Conditions.All(x => x.EvalCondition(ns));
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

        public override bool EvalCondition(IDmlfNamespace ns)
        {
            return Conditions.Any(x => x.EvalCondition(ns));
        }
    }

    public class DmlfFalseCondition : DmlfConditionBase
    {
        public override void GenSql(ISqlDumper dmp)
        {
            dmp.Put("(1=0)");
        }

        public override bool EvalCondition(IDmlfNamespace ns)
        {
            return false;
        }
    }

    public class DmlfExistCondition : DmlfConditionBase
    {
        public DmlfSelect Select;

        public override void GenSql(ISqlDumper dmp)
        {
            dmp.Put("^exists (");
            Select.GenSql(dmp);
            dmp.Put(")");
        }
    }

    public class DmlfNotExistCondition : DmlfConditionBase
    {
        public DmlfSelect Select;

        public override void GenSql(ISqlDumper dmp)
        {
            dmp.Put("^not ^exists (");
            Select.GenSql(dmp);
            dmp.Put(")");
        }
    }
}
