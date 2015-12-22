using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.RelatedDataSync
{
    public class ParameterValue
    {
        [XamlProperty]
        public string Name { get; set; }

        [XamlProperty]
        public string Value { get; set; }
    }
}
