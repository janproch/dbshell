using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.DataSet
{
    public class DateShiftFormula : FormulaDefinition
    {
        [XamlProperty]
        public DateTime OriginalValue { get; set; }

        [XamlProperty]
        public DateTime NewValue { get; set; }

        public TimeSpan GetDateDiff()
        {
            return NewValue - OriginalValue;
        }

        public override void WritePrefix(StringBuilder sb)
        {
            sb.AppendFormat("DATEADD(ms, {0}, ", (long)GetDateDiff().TotalMilliseconds);
        }

        public override void WritePostfix(StringBuilder sb)
        {
            sb.Append(")");
        }
    }
}
