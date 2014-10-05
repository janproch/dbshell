using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;

namespace DbShell.Excel
{
    public class Sheet : ExcelElementBase, ITabularDataSource, ITabularDataTarget
    {
        /// <summary>
        /// Name of sheet
        /// </summary>
        public string SheetName { get; set; }

        /// <summary>
        /// Index of sheet
        /// </summary>
        public string SheetIndex { get; set; }

        public bool IsAvailableRowFormat(IShellContext context)
        {
            return false;
        }

        public ICdlWriter CreateWriter(TableInfo rowFormat, CopyTableTargetOptions options, IShellContext context)
        {
            return GetModel(context).CreateWriter(rowFormat, context.Replace(SheetName));
        }

        public TableInfo GetRowFormat(IShellContext context)
        {
            if (!String.IsNullOrEmpty(SheetIndex)) return GetModel(context).GetSheetStructure(Int32.Parse(context.Replace(SheetIndex)));
            return GetModel(context).GetSheetStructure(context.Replace(SheetName));
        }

        public ICdlReader CreateReader(IShellContext context)
        {
            if (!String.IsNullOrEmpty(SheetIndex)) return GetModel(context).CreateReader(Int32.Parse(context.Replace(SheetIndex)));
            return GetModel(context).CreateReader(context.Replace(SheetName));
        }
    }
}
