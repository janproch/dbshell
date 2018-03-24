using DbShell.Core.ScriptParser;
using DbShell.Driver.Common.Interfaces;
using DbShell.Driver.Common.Utility;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Core.Utility
{
    public static class DbShellCoreServiceCollectionExtension
    {
        public static void AddDbShellCore(this IServiceCollection services)
        {
            services.AddSingleton<IJsonElementProvider, DbShellCoreElementsProvider>();
            services.AddSingleton<IJsonElementFactory, JsonElementFactory>();
            services.AddTransient<IDbShellParser, DbShellParser>();
            services.AddSingleton<IDbShellLanguageProvider, DbShellLanguageProvider>();
        }
    }
}
