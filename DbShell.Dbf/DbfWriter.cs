using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbShell.Driver.Common.CommonDataLayer;
using SocialExplorer.IO.FastDBF;

namespace DbShell.Dbf
{
    public class DbfWriter : ICdlWriter
    {
        private SocialExplorer.IO.FastDBF.DbfFile _dbf;
        private DbfRecord _orec;
        private CdlValueFormatter _formatter;

        public DbfWriter(SocialExplorer.IO.FastDBF.DbfFile dbf)
        {
            _dbf = dbf;
            _orec = new DbfRecord(_dbf.Header);
            _formatter = new CdlValueFormatter(new DataFormatSettings());
        }

        public event Action Disposing;

        public void Write(ICdlRecord row)
        {
            _orec.Clear();
            for (int i = 0; i < row.FieldCount; i++)
            {
                row.ReadValue(i);
                _formatter.ReadFrom(row);
                _orec[i] = _formatter.GetText();
            }
            _dbf.Write(_orec);
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (Disposing != null)
            {
                Disposing();
                Disposing = null;
            }
            _dbf.Close();
        }

        #endregion

    }
}
