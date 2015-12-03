using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.Utility
{
    public class RecordToDbAdapter : IRecordToDbAdapter
    {
        private IDialectDataAdapter _dda;
        private ICdlValueConvertor _outputConv;
        private TargetColumnMap _columnMap;

        public RecordToDbAdapter(TargetColumnMap columnMap, IDatabaseFactory targetFactory, DataFormatSettings formatSettings)
        {
            _columnMap = columnMap;
            _dda = targetFactory.CreateDataAdapter();
            _outputConv = new CdlValueConvertor(formatSettings);
        }

        public ICdlRecord AdaptRecord(ICdlRecord record)
        {
            var res = new ArrayDataRecord(record.Structure);
            for (int i = 0; i < Math.Min(res.FieldCount, record.FieldCount); i++)
            {
                var targetColumn = _columnMap.GetTargetColumnBySourceIndex(i);
                if (targetColumn == null) continue;

                record.ReadValue(i);
                res.SeekValue(i);

                _dda.AdaptValue(record, targetColumn.CommonType, res, _outputConv);
            }
            return res;
        }
    }
}
