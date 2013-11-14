using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Core.DataSet
{
    public class AddRows : DataSetItemBase
    {
        public string Table { get; set; }
        public string Condition { get; set; }

        protected override void DoRun()
        {
            using (var conn = Connection.Connect())
            {
                Model.AddRows(conn, Replace(Table), Replace(Condition));
            }
        }
    }
}
