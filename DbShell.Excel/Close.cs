using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Interfaces;

namespace DbShell.Excel
{
    public class Close : ExcelRunnableBase
    {
        protected override void DoRun(IShellContext context)
        {
            GetModel(context).Close();
        }
    }
}
