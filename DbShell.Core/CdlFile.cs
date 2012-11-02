using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Core
{
    /// <summary>
    /// Binary file holding table data. Can be used for temporary storage of table contents.
    /// </summary>
    public class CdlFile : ElementBase, ITabularDataSource, ITabularDataTarget
    {
        /// <summary>
        /// File name (should have .cdl extension)
        /// </summary>
        public string Name { get; set; }

        private string GetName()
        {
            return Context.Replace(Name);
        }

        private void OpenRead(out TableInfo table, out BinaryReader br)
        {
            var fr = new FileInfo(GetName()).OpenRead();
            br = new BinaryReader(fr);
            string s = br.ReadString();
            var doc = new XmlDocument();
            doc.LoadXml(s);
            table = new TableInfo(null);
            table.LoadFromXml(doc.DocumentElement);
        }

        TableInfo ITabularDataSource.GetRowFormat()
        {
            TableInfo table;
            BinaryReader br = null;
            try
            {
                OpenRead(out table, out br);
            }
            finally
            {
                if (br != null) br.Close();
            }
            return table;
        }

        ICdlReader ITabularDataSource.CreateReader()
        {
            TableInfo table;
            BinaryReader br;
            OpenRead(out table, out br);
            return new CdlFileReader(table, br);
        }

        bool ITabularDataTarget.AvailableRowFormat
        {
            get { return false; }
        }

        ICdlWriter ITabularDataTarget.CreateWriter(TableInfo rowFormat, CopyTableTargetOptions options)
        {
            return new CdlFileWriter(GetName(), rowFormat);
        }

        TableInfo ITabularDataTarget.GetRowFormat()
        {
            return null;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return String.Format("[File {0}]", GetName());
        }
    }
}
