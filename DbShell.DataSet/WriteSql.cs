using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Common;

namespace DbShell.DataSet
{
    public class WriteSql : DataSetItemBase
    {
        public string File { get; set; }

        protected override void DoRun(IShellContext context)
        {
            string file = context.ResolveFile(context.Replace(File), ResolveFileMode.Output);
            context.OutputMessage("DBSH-00118 Exporting SQL file Writing " + file);
            using (var fw = new StreamWriter(file))
            {
                GetModel(context).WriteSql(fw);
            }
        }
    }
}
