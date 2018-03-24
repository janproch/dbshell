using DbShell.Core.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Core.Runtime
{
    public class VariableScope
    {
        Dictionary<string, object> _values = new Dictionary<string, object>();
        VariableScope _parent;

        public VariableScope(VariableScope parent) => _parent = parent;

        public object GetVariable(string name)
        {
            if (_values.TryGetValue(name, out var value)) return value;
            if (_parent != null) return _parent.GetVariable(name);
            return null;
        }
        public object Evaluate(string expression)
        {
            if (!expression.Contains("."))
                return GetVariable(expression);
            var path = expression.Split('.');
            var value = GetVariable(path[0]);
            for(int i = 1; i < path.Length; i++)
            {
                string name = MiscTool.ToPascalCase(path[i]);
                var type = value.GetType();
                var prop = type.GetProperty(name);
                value = prop.GetValue(value);
            }
            return value;
        }
        public void SetVariable(string name, object value) => _values[name] = value;
    }
}
