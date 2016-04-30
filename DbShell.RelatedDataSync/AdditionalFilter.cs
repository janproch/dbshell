using DbShell.Driver.Common.FilterParser;
using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.RelatedDataSync
{
    public class AdditionalFilter
    {
        [XamlProperty]
        public string Column { get; set; }

        [XamlProperty]
        public string Filter { get; set; }

        [XamlProperty]
        public FilterParser.ExpressionType FilterType { get; set; } = FilterParser.ExpressionType.None;
    }
}
