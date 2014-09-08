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
using log4net;

namespace DbShell.Core
{
    /// <summary>
    /// Binary file holding table data. Can be used for temporary storage of table contents.
    /// </summary>
    public class CdlFile : ElementBase, ITabularDataSource, ITabularDataTarget, IModelProvider
    {
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// File name (should have .cdl extension)
        /// </summary>
        [XamlProperty]
        public string Name { get; set; }

        private string GetName()
        {
            return Replace(Name);
        }

        private void OpenRead(out TableInfo table, out BinaryReader br)
        {
            string file = GetName();
            if (Context != null) file = Context.ResolveFile(file, ResolveFileMode.Input);
            var fr = new FileInfo(file).OpenRead();
            br = new BinaryReader(fr);
            string s = br.ReadString();
            var doc = new XmlDocument();
            doc.LoadXml(s);
            table = new TableInfo(null);
            table.LoadFromXml(doc.DocumentElement);
            table.AfterLoadLink();
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
            string file = GetName();
            if (Context != null)
            {
                file = Context.ResolveFile(file, ResolveFileMode.Output);
                Context.OutputMessage("Writing file " + Path.GetFullPath(file));
            }
            return new CdlFileWriter(file, rowFormat);
        }

        TableInfo ITabularDataTarget.GetRowFormat()
        {
            return null;
        }

        object IModelProvider.GetModel()
        {
            return this;
        }

        void IModelProvider.InitializeTemplate(IRazorTemplate template)
        {
            template.TabularData = this;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return String.Format("[CdlFile {0}]", GetName());
        }
    }
}
