using DbShell.Driver.Common.AbstractDb;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Driver.MySql
{
    public static class MySqlServiceCollectionExtension
    {
        public static void AddMySql(this IServiceCollection services)
        {
            services.AddTransient<IDatabaseFactory, MySqlDatabaseFactory>();
        }
    }
}
