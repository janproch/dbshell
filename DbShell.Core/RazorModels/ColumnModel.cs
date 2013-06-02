using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Structure;

namespace DbShell.Core.RazorModels
{
    public abstract class ColumnModel
    {
        public abstract string Name { get;  }
    }

    public class TableColumnModel : ColumnModel
    {
        private ColumnInfo _column;
        public TableColumnModel(ColumnInfo column)
        {
            _column = column;
        }

        public override string Name
        {
            get { return _column.Name; }
        }
    }
}
