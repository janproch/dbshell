using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;

namespace DbShell.Core
{
    public class Table : ElementBase, ITabularDataSource
    {
        public string Name { get; set; }

        string ITabularDataSource.GetData()
        {
            return Name;
        }
    }
}
