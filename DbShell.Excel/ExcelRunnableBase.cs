using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Interfaces;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Utility;
using DbShell.Excel.ExcelModels;

namespace DbShell.Excel
{
    public abstract class ExcelRunnableBase : RunnableBase
    {
        /// <summary>
        /// Excel variable name
        /// </summary>
        [XamlProperty]
        public string VariableName { get; set; }

        protected ExcelModel GetModel(IShellContext context)
        {
            return (ExcelModel)context.GetVariable(GetExcelVariableName(context));
        }

        protected string GetExcelVariableName(IShellContext context)
        {
            if (String.IsNullOrEmpty(VariableName)) return "DefaultExcel";
            return context.Replace(VariableName);
        }
    }
}
