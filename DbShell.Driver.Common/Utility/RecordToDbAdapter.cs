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
        private TableInfo _targetTable;
        private IDialectDataAdapter _dda;
        private ICdlValueConvertor _outputConv;

        public RecordToDbAdapter(TableInfo targetTable, IDatabaseFactory targetFactory, DataFormatSettings formatSettings)
        {
            _targetTable = targetTable;
            _dda = targetFactory.CreateDataAdapter();
            _outputConv = new CdlValueConvertor(formatSettings);
        }

        public ICdlRecord AdaptRecord(ICdlRecord record)
        {
            var res = new ArrayDataRecord(record.Structure);
            for (int i = 0; i < res.FieldCount; i++)
            {
                record.ReadValue(i);
                res.SeekValue(i);
                _dda.AdaptValue(record, _targetTable.Columns[i].CommonType, res, _outputConv);
            }
            return res;
        }
    }
}
