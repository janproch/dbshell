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
        private ICdlValueFormatter _formatter;
        private List<object[]> _rows = new List<object[]>();

        public ExcelWriter(TableInfo rowFormat, Worksheet sheet, DataFormatSettings dataFormat)
        {
            _rowFormat = rowFormat;
            _sheet = sheet;
            _formatter = new CdlValueFormatter(dataFormat ?? new DataFormatSettings());
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (_rows.Any())
            {
                var data = new object[_rows.Count,_rowFormat.ColumnCount];
                for (int i = 0; i < _rows.Count; i++)
                {
                    for (int j = 0; j < _rowFormat.ColumnCount; j++)
                    {
                        data[i, j] = _rows[i][j];
                    }
                }

                var beginWrite = (Range) _sheet.Cells[2, 1];
                var endWrite = (Range) _sheet.Cells[_rows.Count + 1, _rowFormat.ColumnCount];
                var sheetData = _sheet.Range[beginWrite, endWrite];
                sheetData.Value2 = data;
            }

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
            var dataRow = new object[row.FieldCount];
            _rows.Add(dataRow);
            for (int i = 0; i < row.FieldCount; i++)
            {
                row.ReadValue(i);
                _formatter.ReadFrom(row);
                dataRow[i] = _formatter.GetText();
            }
        }
    }
}
