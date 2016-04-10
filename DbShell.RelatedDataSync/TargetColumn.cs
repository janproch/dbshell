using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.RelatedDataSync
{
    public enum TargetColumnValueType
    {
        Auto,
        Value,
        Source,
        Expression,
        Template,
        Special,
    }

    public enum TargetColumnSpecialValue
    {
        Null,
        ImportDateTime,
        ImportDate,
        CurrentDateTime,
        CurrentDate,
        CurrentUtcDateTime,
        CurrentUtcDate,
        NewGUID,
    }

    public class TargetColumn
    {
        [XamlProperty]
        public string Name { get; set; }

        [XamlProperty]
        public string Source { get; set; }

        [XamlProperty]
        public string Expression { get; set; }

        [XamlProperty]
        public string Value { get; set; }

        [XamlProperty]
        public string Template { get; set; }

        [XamlProperty]
        public TargetColumnSpecialValue? SpecialValue { get; set; }

        [XamlProperty]
        public TargetColumnValueType ValueType { get; set; } = TargetColumnValueType.Auto;

        [XamlProperty]
        public bool IsKey { get; set; }

        [XamlProperty]
        public bool IsRestriction { get; set; }

        [XamlProperty]
        public bool Compare { get; set; }

        [XamlProperty]
        public bool Update { get; set; } = true;

        [XamlProperty]
        public bool Insert { get; set; } = true;

        public TargetColumnValueType RealValueType
        {
            get
            {
                if (ValueType == TargetColumnValueType.Auto)
                {
                    if (!String.IsNullOrEmpty(Source)) return TargetColumnValueType.Source;
                    if (!String.IsNullOrEmpty(Expression)) return TargetColumnValueType.Expression;
                    if (!String.IsNullOrEmpty(Value)) return TargetColumnValueType.Value;
                    if (!String.IsNullOrEmpty(Template)) return TargetColumnValueType.Template;
                    if (SpecialValue.HasValue) return TargetColumnValueType.Special;
                }
                return ValueType;
            }
        }
    }
}
