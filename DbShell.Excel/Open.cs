using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Excel.ExcelModels;

namespace DbShell.Excel
{
    public class Open : ExcelRunnableBase
    {
        /// <summary>
        /// file name of Excel file
        /// </summary>
        [XamlProperty]
        public string File { get; set; }

        protected override void DoRun(IShellContext context)
        {
            string file = context.ResolveFile(context.Replace(File), ResolveFileMode.Input);
            context.SetVariable(GetExcelVariableName(context), ExcelModel.OpenFile(file));
        }
    }
}
