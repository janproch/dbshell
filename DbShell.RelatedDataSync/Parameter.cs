using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Driver.Common.Utility;
using DbShell.RelatedDataSync.SqlModel;

namespace DbShell.RelatedDataSync
{
    public class Parameter
    {
        [XamlProperty]
        public string Name { get; set; }

        [XamlProperty]
        public string DataType { get; set; }

        [XamlProperty]
        public string DefaultValue { get; set; }
    }
}
