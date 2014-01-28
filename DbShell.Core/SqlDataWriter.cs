using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;

namespace DbShell.Core
{
    public class SqlDataWriter : ElementBase, ITabularDataTarget
    {
        /// <summary>
        ///  name of input file
        /// </summary>
        public string File { get; set; }

        public bool AvailableRowFormat
        {
            get { return false; }
        }

        public ICdlWriter CreateWriter(TableInfo rowFormat, CopyTableTargetOptions options)
        {
            string file = Context.ResolveFile(Replace(File), ResolveFileMode.Output);
            var fw = new StreamWriter(file);
            return new SqlFileWriter(fw, Context.DefaultConnection.Factory);
        }

        public TableInfo GetRowFormat()
        {
            return null;
        }
    }
}
