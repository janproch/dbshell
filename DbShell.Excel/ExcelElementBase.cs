using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Excel.ExcelModels;

namespace DbShell.Excel
{
    public abstract class ExcelElementBase : ElementBase
    {
        /// <summary>
        /// Excel variable name
        /// </summary>
        public string Name { get; set; }

        protected ExcelModel GetModel(IShellContext context)
        {
            return (ExcelModel)context.GetVariable(GetExcelVariableName(context));
        }

        protected string GetExcelVariableName(IShellContext context)
        {
            if (String.IsNullOrEmpty(Name)) return "DefaultExcel";
            return context.Replace(Name);
        }
    }
}
