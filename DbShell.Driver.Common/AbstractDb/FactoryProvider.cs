using System;
using System.Collections.Generic;
using System.Data.Common;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.AbstractDb
{
    public static class FactoryProvider
    {
        //private static Dictionary<string, IDatabaseFactory> _factories = new Dictionary<string, IDatabaseFactory>();
        //private static Dictionary<Type, IDatabaseFactory> _factoryByType = new Dictionary<Type, IDatabaseFactory>();  

        //public static void RegisterFactory(IDatabaseFactory factory)
        //{
        //    foreach(string ident in factory.Identifiers)
        //    {
        //        _factories[ident] = factory;
        //    }
        //    foreach (var type in factory.ConnectionTypes)
        //    {
        //        _factoryByType[type] = factory;
        //    }
        //}

        public static IDatabaseFactory FindFactory(IServiceProvider serviceProvider, string identifier)
        {
            var factories = serviceProvider.GetService<IEnumerable<IDatabaseFactory>>();
            return factories.FirstOrDefault(x => x.Identifiers.Contains(identifier));
        }

        public static IDatabaseFactory FindFactory(IServiceProvider serviceProvider, DbConnection connection)
        {
            var factories = serviceProvider.GetService<IEnumerable<IDatabaseFactory>>();
            return factories.FirstOrDefault(x => x.ConnectionTypes.Contains(connection.GetType()));
        }
    }
}
