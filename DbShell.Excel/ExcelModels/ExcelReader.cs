using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using Microsoft.Office.Interop.Excel;
using Action = System.Action;

namespace DbShell.Excel.ExcelModels
{
    public class ExcelReader : ArrayDataRecord, ICdlReader
    {
        private Worksheet _worksheet;
        private string[] _array;
        private int _rowIndex = 2;
        private Range _usedRange;

        public ExcelReader(TableInfo structure, Worksheet worksheet)
            : base(structure)
        {
            _worksheet = worksheet;
            _array = new string[structure.ColumnCount];
            _usedRange = _worksheet.UsedRange;
        }

        public bool Read()
        {
            if (_rowIndex > _usedRange.Rows.Count)
            {
                return false;
            }
            for (int i = 1; i <= _array.Length; i++)
            {
                object value = ((Range) _usedRange.Cells[_rowIndex, i]).Value2;
                string svalue = value.SafeToString();
                _values[i - 1] = svalue;
            }
            _rowIndex++;
            return true;
        }

        public bool NextResult()
        {
            return false;
        }

        public event Action Disposing;

        public void Dispose()
        {
            if (Disposing != null)
            {
                Disposing();
                Disposing = null;
            }
        }
    }
}
