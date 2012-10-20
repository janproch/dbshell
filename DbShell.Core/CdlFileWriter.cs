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
            var fw = new FileInfo(file).OpenWrite();
            _bw = new BinaryWriter(fw);
            var doc = XmlTool.CreateDocument("Table");
            table.SaveToXml(doc.DocumentElement);
            _bw.Write(doc.GetPackedDocumentXml());
        }

        public void Write(ICdlRecord row)
        {
            _bw.Write(false);
            CdlTool.SaveRecord(row.FieldCount, row, _bw);
        }

        public void Dispose()
        {
            _bw.Write(true);
            _bw.Close();
        }
    }
}
