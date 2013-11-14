using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Core.DataSet
{
    public class Prepare : DataSetItemBase
    {
        protected override void DoRun()
        {
            using (var conn = Connection.Connect())
            {
                Model.Prepare(conn);
            }
        }
    }
}
