using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.RelatedDataSync
{
    public class SourceColumn
    {
        [XamlProperty]
        public string Name { get; set; }

        [XamlProperty]
        public string Alias { get; set; }

        [XamlProperty]
        public bool IsKey { get; set; }

        [XamlProperty]
        public string DataType { get; set; }

        [XamlProperty]
        public string Filter { get; set; }

        [XamlProperty]
        public FilterParserTool.ExpressionType FilterType { get; set; } = FilterParserTool.ExpressionType.None;

        public string AliasOrName
        {
            get { return Alias ?? Name; }
        }
    }
}
