using DbShell.Driver.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DbShell.Core.Utility
{
    public static class MiscTool
    {
        public static string ToStringCtx(this object o, IShellContext context)
        {
            var elem = o as ElementBase;
            if (elem != null) return elem.ToStringCtx(context);
            return o?.ToString();
        }

        public static string ToPascalCase(string value)
        {
            if (value.Length > 0 && char.IsLower(value[0]))
                return char.ToUpper(value[0]) + value.Substring(1);
            return value;
        }

        public static void RegisterAllJsonTypes(Assembly assembly, string ns, Action<string, Type> typeFunc)
        {
            foreach(var type in assembly.GetTypes())
            {
                if (!type.FullName.StartsWith(ns + "."))
                    continue;
                typeFunc(type.Name, type);
            }
        }
    }
}
