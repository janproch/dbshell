using DbShell.Driver.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Csv
{
    public static class DbShellCsvServiceCollectionExtension
    {
        public static void AddDbShellCsv(this IServiceCollection services)
        {
            services.AddTransient<IJsonElementProvider, DbShellCsvElementsProvider>();
            services.AddTransient<IDataFileFormat, CsvFileFormat>();
        }
    }
}
