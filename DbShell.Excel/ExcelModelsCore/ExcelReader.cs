using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using Action = System.Action;


namespace DbShell.Excel.ExcelModels
{
    public class ExcelReader : ArrayDataRecord, ICdlReader
    {
#if !NETSTANDARD1_5
        private Worksheet _worksheet;
        private string[] _array;
        private int _rowIndex = 2;
        private Range _usedRange;
        private object[,] _usedData;
        private int _rowCount;

        public ExcelReader(TableInfo structure, Worksheet worksheet)
            : base(structure)
        {
            _worksheet = worksheet;
            _array = new string[structure.ColumnCount];
            _usedRange = _worksheet.UsedRange;
        }

        public bool Read()
        {
            if (_usedData == null)
            {
                _usedData = _usedRange.Value2;
                _rowCount = _usedRange.Rows.Count;
            }
            if (_rowIndex > _rowCount)
            {
                return false;
            }
            for (int i = 1; i <= _array.Length; i++)
            {
                //object value = ((Range) _usedRange.Cells[_rowIndex, i]).Value2;
                object value = _usedData[_rowIndex, i];
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
#endif

        public ExcelReader(TableInfo structure, object[] values) : base(structure, values)
        {
        }

        public event Action Disposing;

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        bool ICdlReader.NextResult()
        {
            throw new NotImplementedException();
        }

        bool ICdlReader.Read()
        {
            throw new NotImplementedException();
        }
    }
}

