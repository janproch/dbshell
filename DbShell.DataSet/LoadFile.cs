using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Core.Utility;

namespace DbShell.DataSet
{
    public class LoadFile : DataSetItemBase
    {
        /// <summary>
        /// file name
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// name of target table
        /// </summary>
        public string Table { get; set; }

        protected override void DoRun()
        {
            string file = Replace(File);
            string table = Replace(Table);
            Model.LoadFile(file, table ?? Path.GetFileNameWithoutExtension(file));
        }
    }
}
