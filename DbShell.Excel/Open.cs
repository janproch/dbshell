using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Interfaces;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Utility;
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

        /// <summary>
        /// data format
        /// </summary>
        [XamlProperty]
        public DataFormatSettings DataFormat { get; set; }

        protected override void DoRun(IShellContext context)
        {
            string file = context.ResolveFile(context.Replace(File), ResolveFileMode.Input);
            var model = ExcelModel.OpenFile(file);
            model.DataFormat = DataFormat;
            context.SetVariable(GetExcelVariableName(context), model);
        }
    }
}
