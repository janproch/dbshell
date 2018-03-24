using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;

namespace DbShell.Driver.Common.Interfaces
{
    public interface IConnectionProvider
    {
        DbConnection Connect();
        IDatabaseFactory Factory { get; }
        string ProviderString { get; }
    }
}
