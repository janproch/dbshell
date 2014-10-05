using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using Microsoft.Office.Interop.Excel;
using Action = System.Action;

namespace DbShell.Excel.ExcelModels
{
    public class ExcelWriter : ICdlWriter
    {
        private TableInfo _rowFormat;
        private Worksheet _sheet;
        private int _rowIndex = 2;
        private ICdlValueFormatter _formatter;

        public ExcelWriter(TableInfo rowFormat, Worksheet sheet)
        {
            _rowFormat = rowFormat;
            _sheet = sheet;
            _formatter = new CdlValueFormatter(new DataFormatSettings());
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (Disposing != null)
            {
                Disposing();
                Disposing = null;
            }
        }

        #endregion

        public event Action Disposing;

        public void Write(ICdlRecord row)
        {
            for (int i = 0; i < row.FieldCount; i++)
            {
                row.ReadValue(i);
                _formatter.ReadFrom(row);
                ((Range) _sheet.Cells[_rowIndex, i + 1]).Value2 = _formatter.GetText();
            }
            _rowIndex++;
        }
    }
}
