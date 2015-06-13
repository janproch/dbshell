using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.DmlFramework;
using DbShell.Driver.Common.Structure;
using MS.Internal.Xml.XPath;

namespace DbShell.Driver.Common.ChangeSet
{
    public abstract class ChangeSetCompiledConditionItem
    {
        protected ChangeSetCompiledModel _changeSet;
        protected ChangeSetItem _item;

        public ChangeSetCompiledConditionItem(ChangeSetCompiledModel changeSet, ChangeSetItem item)
        {
            _changeSet = changeSet;
            _item = item;
        }

        public List<ChangeSetCompiledCondition> Conditions = new List<ChangeSetCompiledCondition>();
        public bool CanBeUsed = false;

        public ChangeSetItem Item
        {
            get { return _item; }
        }

        protected void CompileConditions(List<ChangeSetCondition> conditions)
        {
            foreach (var cond in conditions)
            {
                var compiled = CompileCondition(cond);
                if (compiled == null)
                {
                    CanBeUsed = false;
                    Conditions.Clear();
                    return;
                }
                Conditions.Add(compiled);
            }
        }

        private ChangeSetCompiledCondition CompileCondition(ChangeSetCondition cond)
        {
            int column = FindColumnIndex(cond.Column);
            if (column < 0) return null;
            var cinfo = FindColumnInfo(cond.Column);
            if (cinfo == null) return null;
            var expr = FilterParser.FilterParser.ParseFilterExpression(cinfo.CommonType, new DmlfPlaceholderExpression(), cond.Expression);
            if (expr == null) return null;
            return new ChangeSetCompiledCondition
                {
                    ColumnIndex = column,
                    Expression = expr,
                };
        }

        protected int FindColumnIndex(string column)
        {
            return _changeSet.FindColumnIndex(_item.TargetTable, column);
        }

        private ColumnInfo FindColumnInfo(string column)
        {
            return _changeSet.FindColumnInfo(_item.TargetTable, column);
        }

        public bool EvalCondition(CdlRow row)
        {
            if (!CanBeUsed) return false;
            return Conditions.All(x => EvalSingleCondition(x, row));
        }

        private bool EvalSingleCondition(ChangeSetCompiledCondition cond, CdlRow row)
        {
            object data = row[cond.ColumnIndex];
            return cond.Expression.EvalCondition(new DmlfSingleValueNamespace(data));
        }

        //public bool MatchKey(NameWithSchema tableName, int[] pk, object[] values)
        //{
        //    if (_item.TargetTable != tableName) return false;
        //    if (Conditions.Count != pk.Length) return false;
        //    int pkindex = 0;
        //    foreach (int colindex in pk)
        //    {
        //        var cond = Conditions.FirstOrDefault(x => x.ColumnIndex == colindex);
        //        if (cond == null) return false;
        //        var eqexpr = cond.Expression as DmlfEqualCondition;
        //        if (eqexpr == null) return false;
        //        var placeholder = eqexpr.LeftExpr as DmlfPlaceholderExpression;
        //        if (placeholder == null) return false;
        //        var literal = eqexpr.RightExpr as DmlfLiteralExpression;
        //        if (literal == null) return false;
        //        bool eqvalue = literal.Value != null && values[pkindex] != null &&
        //                       Convert.ToString(literal.Value, CultureInfo.InvariantCulture) == Convert.ToString(values[pkindex], CultureInfo.InvariantCulture);
        //        if (!eqvalue) return false;
        //        pkindex++;
        //    }
        //    return true;
        //}
    }
}
