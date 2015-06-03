using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using DbShell.Driver.Common.AbstractDb;

namespace DbShell.Driver.Common.DmlFramework
{
    public abstract class DmlfUnaryExpression : DmlfExpression
    {
        public DmlfExpression Argument;

        public DmlfUnaryExpression()
        {
        }

        public DmlfUnaryExpression(XmlElement xml)
        {
            LoadFromXml(xml);
        }

        public override bool DmlfEquals(DmlfBase obj)
        {
            var o = (DmlfUnaryExpression)obj;
            if (!Argument.DmlfEquals(o.Argument)) return false;
            if (GetType() != obj.GetType()) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return Argument.GetHashCode();
        }
    }

    public class DmlfMonthExpression : DmlfUnaryExpression
    {
        protected override string GetTypeName()
        {
            return "month";
        }

        public override void GenSql(ISqlDumper dmp)
        {
            dmp.ExtractMonth(d => Argument.GenSql(d));
        }

        public override object EvalExpression(IDmlfNamespace ns)
        {
            var inner = Argument.EvalExpression(ns);
            var dt = inner as DateTime?;
            if (dt.HasValue) return dt.Value.Month;
            return null;
        }
    }

    public class DmlfDayOfWeekExpression : DmlfUnaryExpression
    {
        protected override string GetTypeName()
        {
            return "day_of_week";
        }

        public override void GenSql(ISqlDumper dmp)
        {
            dmp.ExtractDayOfWeek(d => Argument.GenSql(d));
        }

        public override object EvalExpression(IDmlfNamespace ns)
        {
            var inner = Argument.EvalExpression(ns);
            var dt = inner as DateTime?;
            if (dt.HasValue) return (int)dt.Value.DayOfWeek;
            return null;
        }
    }

    public class DmlfDayOfWeekLiteralExpression : DmlfExpression
    {
        public DayOfWeek Value;

        protected override string GetTypeName()
        {
            return "day_of_week_literal";
        }

        public override void GenSql(ISqlDumper dmp)
        {
            dmp.PutDayOfWeekLiteral(Value);
        }

        public override object EvalExpression(IDmlfNamespace ns)
        {
            return (int)Value;
        }
    }


    public class DmlfDayOfMonthExpression : DmlfUnaryExpression
    {
        protected override string GetTypeName()
        {
            return "day_of_month";
        }

        public override void GenSql(ISqlDumper dmp)
        {
            dmp.ExtractDayOfMonth(d => Argument.GenSql(d));
        }

        public override object EvalExpression(IDmlfNamespace ns)
        {
            var inner = Argument.EvalExpression(ns);
            var dt = inner as DateTime?;
            if (dt.HasValue) return dt.Value.Day;
            return null;
        }
    }
}
