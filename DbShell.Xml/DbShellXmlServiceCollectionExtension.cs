using DbShell.Driver.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Xml
{
    public static class DbShellXmlServiceCollectionExtension
    {
        public static void AddDbShellXml(this IServiceCollection services)
        {
            services.AddTransient<IJsonElementProvider, DbShellXmlElementsProvider>();
            services.AddTransient<IDataFileFormat, XmlFileFormat>();
        }
    }
}
