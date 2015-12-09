using DbShell.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.DataSet
{
    public abstract class FormulaDefinition : FormulaItemBase
    {
        protected override void DoRun(IShellContext context)
        {
            var ds = GetModel(context);
            ds.DefineFormula(context.Replace(FormulaName), this);
        }

        public abstract void WritePrefix(StringBuilder sb);
        public abstract void WritePostfix(StringBuilder sb);
    }
}
