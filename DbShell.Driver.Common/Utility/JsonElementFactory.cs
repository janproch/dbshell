using DbShell.Driver.Common.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace DbShell.Driver.Common.Utility
{
    public interface IJsonElementFactory
    {
        ISerializationBinder JsonBinder { get; }
    }

    public class JsonElementFactory : IJsonElementFactory, ISerializationBinder
    {
        private Dictionary<string, Type> _nameToType = new Dictionary<string, Type>();
        private Dictionary<Type, string> _typeToName = new Dictionary<Type, string>();

        public JsonElementFactory(IEnumerable<IJsonElementProvider> providers)
        {
            foreach (var provider in providers)
            {
                provider.EnumJsonTypes((name, type) =>
                {
                    _nameToType[name] = type;
                    _typeToName[type] = name;
                });
            }
        }

        public ISerializationBinder JsonBinder => this;

        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = null;
            _typeToName.TryGetValue(serializedType, out typeName);
        }

        public Type BindToType(string assemblyName, string typeName)
        {
            if (_nameToType.TryGetValue(typeName, out var type))
                return type;
            return null;
        }
    }
}
