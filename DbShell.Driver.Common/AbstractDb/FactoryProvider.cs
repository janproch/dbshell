using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.AbstractDb
{
    public static class FactoryProvider
    {
        private static Dictionary<string, IDatabaseFactory> _factories = new Dictionary<string, IDatabaseFactory>();
        private static Dictionary<Type, IDatabaseFactory> _factoryByType = new Dictionary<Type, IDatabaseFactory>();  

        public static void RegisterFactory(IDatabaseFactory factory)
        {
            foreach(string ident in factory.Identifiers)
            {
                _factories[ident] = factory;
            }
            foreach (var type in factory.ConnectionTypes)
            {
                _factoryByType[type] = factory;
            }
        }

        public static IDatabaseFactory FindFactory(string identifier)
        {
            if (_factories.ContainsKey(identifier)) return _factories[identifier];
            return null;
        }

        public static IDatabaseFactory FindFactory(DbConnection connection)
        {
            if (_factoryByType.ContainsKey(connection.GetType())) return _factoryByType[connection.GetType()];
            return null;
        }
    }
}
