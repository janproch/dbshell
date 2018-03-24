using DbShell.Driver.Common.AbstractDb;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Driver.SqlServer
{
    public static class SqlServerServiceCollectionExtension
    {
        public static void AddSqlServer(this IServiceCollection services)
        {
            services.AddTransient<IDatabaseFactory, SqlServerDatabaseFactory>();
        }
    }
}
