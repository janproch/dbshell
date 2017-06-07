using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.CommonDataLayer
{
    public class CdlReaderAdapter : CdlRecordAdapter, IDataReader
    {
        ICdlReader _reader;
        private bool _isClosed;

        public int ReadedRows { get; private set; }

        public ICdlReader Reader
        {
            get { return _reader; }
            set
            {
                _reader = value;
                Record = _reader;
            }
        }

        public void Dispose()
        {
            if (!IsClosed)
            {
                Close();
            }
        }

        public void Close()
        {
            _isClosed = true;
            _reader.Dispose();
            _reader = null;
        }


#if !NETSTANDARD1_5
        public DataTable GetSchemaTable()
        {
            return _reader.Structure.SchemaFromStructure();
        }
#else
        public DataTable GetSchemaTable()
        {
            return null;
        }
#endif

        public bool NextResult()
        {
            return false;
        }

        public bool Read()
        {
            if (_reader.Read())
            {
                ReadedRows++;
                return true;
            }
            return false;
        }

        public int Depth
        {
            get { return 0; }
        }

        public bool IsClosed
        {
            get { return _isClosed; }
        }

        public int RecordsAffected
        {
            get { return 0; }
        }
    }
}
