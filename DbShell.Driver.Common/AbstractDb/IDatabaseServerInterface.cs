using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.AbstractDb
{
    public interface IDatabaseServerInterface
    {
        DbConnection Connection { get; set; }
        DatabaseServerVersion GetVersion();
        List<string> GetDatabaseList();
    }
}
