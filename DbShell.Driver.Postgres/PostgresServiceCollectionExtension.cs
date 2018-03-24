using DbShell.Driver.Common.AbstractDb;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Driver.Postgres
{
    public static class PostgresServiceCollectionExtension
    {
        public static void AddPostgres(this IServiceCollection services)
        {
            services.AddTransient<IDatabaseFactory, PostgresDatabaseFactory>();
        }
    }
}
