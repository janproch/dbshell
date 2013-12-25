using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.CommonDataLayer
{
    public class CdlStorageReader : ArrayDataRecord, ICdlReader
    {
        private IEnumerator<ICdlRecord> _reader;

        public CdlStorageReader(TableInfo structure)
            : base(structure)
        {
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

        public bool Read()
        {
            return _reader.MoveNext();
        }

        public bool NextResult()
        {
            return false;
        }

        public void SetEnumerator(IEnumerable<ICdlRecord> enumerator)
        {
            _reader = enumerator.GetEnumerator();
        }
    }
}
