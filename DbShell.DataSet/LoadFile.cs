using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Common;
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

        protected override void DoRun(IShellContext context)
        {
            string file = context.Replace(File);
            string table = context.Replace(Table);
            GetModel(context).LoadFile(file, table ?? Path.GetFileNameWithoutExtension(file), context);
        }
    }
}
