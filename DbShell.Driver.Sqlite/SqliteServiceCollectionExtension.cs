using DbShell.Driver.Common.AbstractDb;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Driver.Sqlite
{
    public static class SqliteServiceCollectionExtension
    {
        public static void AddSqlite(this IServiceCollection services)
        {
            services.AddTransient<IDatabaseFactory, SqliteDatabaseFactory>();
        }
    }
}
