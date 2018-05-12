using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DbShell.Test.EngineProviders
{
    public interface IDatabaseEngineProvider
    {
        string ProviderConnectionString { get; }
        void CreateDatabase();
        DbConnection OpenConnection();
    }
}
