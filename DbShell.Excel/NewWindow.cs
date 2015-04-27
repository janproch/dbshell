using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Utility;
using DbShell.Excel.ExcelModels;

namespace DbShell.Excel
{
    public class NewWindow : ExcelRunnableBase
    {
        /// <summary>
        /// data format
        /// </summary>
        [XamlProperty]
        public DataFormatSettings DataFormat { get; set; }

        protected override void DoRun(IShellContext context)
        {
            context.OutputMessage("Opening MS Excel");
            var model = ExcelModel.CreateNewWindow();
            model.DataFormat = DataFormat;
            context.SetVariable(GetExcelVariableName(context), model);
        }
    }
}
