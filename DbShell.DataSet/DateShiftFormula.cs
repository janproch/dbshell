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
        public string OriginalValue { get; set; }

        [XamlProperty]
        public string NewValue { get; set; }

        protected DateTime GetOriginalValue() => ConvertValue(OriginalValue);
        protected DateTime GetNewValue() => ConvertValue(NewValue);

        protected DateTime ConvertValue(string name)
        {
            switch (name)
            {
                case "TODAY":
                    return DateTime.Now.Date;
                case "NOW":
                    return DateTime.Now;
            }
            return DateTime.Parse(name);
        }

        public TimeSpan GetDateDiff()
        {
            return GetNewValue() - GetOriginalValue();
        }

        public override void WritePrefix(StringBuilder sb)
        {
            var diff = GetDateDiff();
            double msDay = diff.Milliseconds + 1000 * (diff.Seconds + 60 * (diff.Minutes + 60 * diff.Hours));
           sb.AppendFormat("DATEADD(dd, {0}, DATEADD(ms, {0}, ", diff.Days, (long)msDay);
        }

        public override void WritePostfix(StringBuilder sb)
        {
            sb.Append("))");
        }
    }
}
