using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.AbstractDb
{
    public interface IBulkInserter
    {
        TableInfo DestinationTable { get; set; }
        int BatchSize { get; set; }
        string DatabaseName { get; set; }
        DbConnection Connection { get; set; }
        void Run(ICdlReader reader);
        BulkInsertOptions CopyOptions { get; set; }
    }
}
