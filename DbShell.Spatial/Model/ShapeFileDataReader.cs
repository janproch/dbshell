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
        private ShapeFileModel _model;
        private bool _addFileIdentifier;

        public ShapeFileDataReader(ShapeFileModel model, bool addFileIdentifier)
            : base(GetTableInfo(model.Shape.DataTable, addFileIdentifier))
        {
            _model = model;
            _addFileIdentifier = addFileIdentifier;
        }

        public static TableInfo GetTableInfo(DataTable data, bool addFileIdentifier)
        {
            var res = data.Columns.GetTableInfo();
            res.AddColumn("_ShapeId_", "int", new DbTypeInt());
            if (addFileIdentifier)
            {
                res.AddColumn("_File_", "nvarchar(250)", new DbTypeString());
            }
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
            var data = _model.Shape.DataTable;
            _rowIndex++;
            if (_rowIndex >= data.Rows.Count) return false;

            for (int i = 0; i < data.Columns.Count; i++)
            {
                _values[i] = data.Rows[_rowIndex][i];
            }
            _values[data.Columns.Count] = _rowIndex;
            if (_addFileIdentifier)
            {
                _values[data.Columns.Count + 1] = _model.File;
            }

            return true;
        }
    }
}
