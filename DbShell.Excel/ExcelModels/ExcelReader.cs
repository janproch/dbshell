using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using OfficeOpenXml;
using Action = System.Action;


namespace DbShell.Excel.ExcelModels
{
    public class ExcelReader : ArrayDataRecord, ICdlReader
    {
        private ExcelWorksheet _worksheet;
        private string[] _array;
        private int _rowIndex = 2;
        private int _rowCount;
        private bool _isCanceled;

        public ExcelReader(TableInfo structure, ExcelWorksheet worksheet)
            : base(structure)
        {
            _worksheet = worksheet;
            _array = new string[structure.ColumnCount];
            _rowCount = _worksheet.Dimension.Rows;
        }

        public bool Read()
        {
            if (_rowIndex > _rowCount || _isCanceled)
            {
                return false;
            }
            for (int i = 1; i <= _array.Length; i++)
            {
                object value = _worksheet.GetValue(_rowIndex, i);
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

        public void Cancel()
        {
            _isCanceled = true;
        }
    }
}

