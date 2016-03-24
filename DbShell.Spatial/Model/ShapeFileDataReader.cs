using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace DbShell.Spatial.Model
{
    public class ShapeFileDataReader : ArrayDataRecord, ICdlReader
    {
        public event Action Disposing;
        private int _rowIndex = -1;
        private DataTable _data;

        public ShapeFileDataReader(DataTable data)
            : base(GetTableInfo(data))
        {
            _data = data;
        }

        public static TableInfo GetTableInfo(DataTable data)
        {
            var res = data.Columns.GetTableInfo();
            res.AddColumn("ShapeId", "int", new DbTypeInt());
            return res;
        }

        public void Dispose()
        {
            if (Disposing != null)
            {
                Disposing();
                Disposing = null;
            }
        }

        public bool NextResult()
        {
            return false;
        }

        public bool Read()
        {
            _rowIndex++;
            if (_rowIndex >= _data.Rows.Count) return false;

            for (int i = 0; i < Structure.ColumnCount; i++)
            {
                _values[i] = _data.Rows[_rowIndex][i];
            }
            _values[Structure.ColumnCount] = _rowIndex;

            return true;
        }
    }
}
