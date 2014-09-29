using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using SocialExplorer.IO.FastDBF;

namespace DbShell.Dbf
{
    public class DbfReader : ArrayDataRecord, ICdlReader
    {
        private SocialExplorer.IO.FastDBF.DbfFile _dbf;
        private string[] _array;
        DbfRecord _irec;

        public DbfReader(TableInfo structure, SocialExplorer.IO.FastDBF.DbfFile dbf)
            : base(structure)
        {
            _dbf = dbf;
            _array = new string[structure.ColumnCount];
            _irec = new DbfRecord(_dbf.Header);
        }

        public bool Read()
        {
            for (;;)
            {
                bool next = _dbf.ReadNext(_irec);
                if (!next) return false;
                if (!_irec.IsDeleted) break;
            }


            for (int i = 0; i < _array.Length; i++)
            {
                _values[i] = _irec[i];
            }
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
            _dbf.Close();
        }
    }
}
