using DbShell.Core.Utility;
using DbShell.Csv;
using DbShell.Xml;
using DbShell.Driver.MySql;
using DbShell.Driver.Postgres;
using DbShell.Driver.Sqlite;
using DbShell.Driver.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.All
{
    public static class DbShellServiceCollectionExtension
    {
        public static void AddDbShell(this IServiceCollection services)
        {
            services.AddDbShellCore();

            // add database engines
            services.AddSqlServer();
            services.AddMySql();
            services.AddSqlite();
            services.AddPostgres();

            // add file formats
            services.AddDbShellCsv();
            services.AddDbShellXml();
        }
    }
}
