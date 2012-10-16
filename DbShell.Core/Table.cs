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

        Driver.Common.Structure.TableInfo ITabularDataSource.GetRowFormat()
        {
            throw new NotImplementedException();
        }

        Driver.Common.CommonDataLayer.ICdlReader ITabularDataSource.CreateReader()
        {
            throw new NotImplementedException();
        }
    }
}
