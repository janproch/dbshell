using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;

namespace DbShell.Common
{
    public interface ITabularDataTarget
    {
        bool AvailableRowFormat { get; }
        ICdlWriter CreateWriter(TableInfo rowFormat);
        TableInfo GetRowFormat();
    }
}
