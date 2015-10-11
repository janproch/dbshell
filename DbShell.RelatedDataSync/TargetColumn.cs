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
    }

    public class TargetColumn
    {
        [XamlProperty]
        public string Name { get; set; }

        [XamlProperty]
        public string SourceName { get; set; }

        [XamlProperty]
        public TargetColumnValueType ValueType { get; set; } = TargetColumnValueType.Auto;

        [XamlProperty]
        public bool IsKey { get; set; }

        [XamlProperty]
        public TargetColumnValueType RealValueType
        {
            get
            {
                if (ValueType == TargetColumnValueType.Auto)
                {
                    if (!String.IsNullOrEmpty(SourceName)) return TargetColumnValueType.Source;
                }
                return TargetColumnValueType.Auto;
            }
        }
    }
}
