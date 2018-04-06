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
    public class CdlFileWriter : ICdlWriter
    {
        private BinaryWriter _bw;

        public CdlFileWriter(string file, TableInfo table)
        {
            var fw = new FileInfo(file).Create();
            _bw = new BinaryWriter(fw);
            var tcopy = table.CloneTable();
            tcopy.ForeignKeys.Clear();
            if (tcopy.PrimaryKey != null) tcopy.PrimaryKey.ConstraintName = null;
            string data = JsonTool.Serialize(tcopy, x => x.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto);
            _bw.Write(data);
        }

        public void Write(ICdlRecord row)
        {
            _bw.Write(false);
            CdlTool.SaveRecord(row.FieldCount, row, _bw);
        }

        public void Dispose()
        {
            if (Disposing != null) Disposing();
            Disposing = null;
            _bw.Write(true);
            _bw.Dispose();
        }

        public event Action Disposing;
    }
}
