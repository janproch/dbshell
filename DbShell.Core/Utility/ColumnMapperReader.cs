using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Core.Utility
{
    public class ColumnMapperReader : ArrayDataRecord, ICdlReader
    {
        private ICdlReader _source;
        private List<IColumnMapping> _columnMap;
        private int _rowNumber = 0;
        private List<int> _counts;
        private IShellContext _context;

        public ColumnMapperReader(ICdlReader source, TableInfo outputFormat, List<IColumnMapping> columnMap, List<int> counts, IShellContext context )
            : base(outputFormat)
        {
            _source = source;
            _columnMap = columnMap;
            _counts = counts;
            _context = context;
        }

        public void Dispose()
        {
            if (Disposing != null)
            {
                Disposing();
                Disposing = null;
            }
        }

        public event Action Disposing;

        public bool Read()
        {
            bool res = _source.Read();
            if (!res) return false;

            int columnIndex = 0;
            for (int i = 0; i < _columnMap.Count; i++)
            {
                var map = _columnMap[i];
                int count = _counts[i];
                for (int j = 0; j < count; j++, columnIndex++)
                {
                    SeekValue(columnIndex);
                    map.ProcessMapping(j, _rowNumber, _source, this, _context);
                }
            }
            _rowNumber++;
            return true;
        }

        public bool NextResult()
        {
            return _source.NextResult();
        }
    }
}
