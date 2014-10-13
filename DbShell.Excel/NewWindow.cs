using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Excel.ExcelModels;

namespace DbShell.Excel
{
    public class NewWindow : ExcelRunnableBase
    {
        protected override void DoRun(IShellContext context)
        {
            context.OutputMessage("Opening MS Excel");
            context.SetVariable(GetExcelVariableName(context), ExcelModel.CreateNewWindow());
        }
    }
}
