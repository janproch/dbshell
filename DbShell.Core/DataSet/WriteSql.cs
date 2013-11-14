using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Common;

namespace DbShell.Core.DataSet
{
    public class WriteSql : DataSetItemBase
    {
        public string File { get; set; }

        protected override void DoRun()
        {
            string file = Context.ResolveFile(Replace(File), ResolveFileMode.Output);
            Context.OutputMessage("DBSH-00118 Exporting SQL file Writing " + file);
            using (var fw = new StreamWriter(file))
            {
                Model.WriteSql(fw);
            }
        }
    }
}
