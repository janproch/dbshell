using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Core.DataSet
{
    public class LoadReference : DataSetItemBase
    {
        public string Table { get; set; }
        public string Column { get; set; }
        public string RefTable { get; set; }

        protected override void DoRun()
        {
            string table = Replace(Table);
            string column = Replace(Column);
            string refTable = Replace(RefTable);

            Model.LoadReference(table, column, refTable);
        }
    }
}
