using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;

namespace DbShell.DataSet
{
    public abstract class FormulaItemBase : DataSetItemBase
    {
        [XamlProperty]
        public string FormulaName { get; set; }
    }
}
