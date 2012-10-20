using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Core
{
    internal class CdlFileReader : ArrayDataRecord, ICdlReader
    {
        private BinaryReader _fr;
        private bool _eof;

        public CdlFileReader(TableInfo table, BinaryReader fr)
            :base(table)
        {
            _fr = fr;
        }

        public bool Read()
        {
            if (_eof) return false;
            _eof = _fr.ReadBoolean();
            if (_eof) return false;
            CdlTool.LoadRecord(_fr, this);
            return true;
        }

        public void Dispose()
        {
            _fr.Dispose();
        }
    }
}
