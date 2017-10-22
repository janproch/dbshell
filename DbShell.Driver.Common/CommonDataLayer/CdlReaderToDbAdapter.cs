using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.CommonDataLayer
{
    public class CdlReaderToDbAdapter : CdlRecordProxy, ICdlReader
    {
        private ICdlReader _sourceReader;
        private IRecordToDbAdapter _recordAdapter;

        public CdlReaderToDbAdapter(IRecordToDbAdapter recordAdapter, ICdlReader sourceReader)
        {
            _sourceReader = sourceReader;
            _recordAdapter = recordAdapter;
            RefObject = sourceReader;
        }

        public void Dispose()
        {
            if (Disposing != null)
            {
                Disposing();
                Disposing = null;
            }
        }

        public void Cancel() { }

        public event Action Disposing;

        public bool Read()
        {
            if (_sourceReader.Read())
            {
                RefObject = _recordAdapter.AdaptRecord(_sourceReader);
                return true;
            }
            return false;
        }

        public bool NextResult()
        {
            return _sourceReader.NextResult();
        }
    }
}
