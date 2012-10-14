using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Driver.Common.Utility
{
    public static class DictionaryExtension
    {
        public static void AddAll<Key, Value>(this IDictionary<Key, Value> dst, IDictionary<Key, Value> src)
        {
            if (src == null) return;
            foreach (var k in src.Keys) dst[k] = src[k];
        }
        public static void AddAllMapped<Key, ValueIn, ValueOut>(this IDictionary<Key, ValueOut> dst, IDictionary<Key, ValueIn> src, Func<ValueIn, ValueOut> func)
        {
            foreach (var k in src.Keys) dst[k] = func(src[k]);
        }
        public static Value Get<Key, Value>(this IDictionary<Key, Value> src, Key key)
        {
            Value res;
            if (src.TryGetValue(key, out res)) return res;
            return default(Value);
        }
        public static Value Get<Key, Value>(this IDictionary<Key, Value> src, Key key, Value defvalue)
        {
            Value res;
            if (src.TryGetValue(key, out res)) return res;
            return defvalue;
        }
        public static bool EqualsDictionary<Key, Value>(this IDictionary<Key, Value> a, IDictionary<Key, Value> b)
        {
            if (a.Count != b.Count) return false;
            foreach (Key key in a.Keys)
            {
                if (!b.ContainsKey(key)) return false;
                if (!a[key].Equals(b[key])) return false;
            }
            return true;
        }
        public static bool EqualsDictionary<Key, Value>(this IDictionary<Key, Value> a, IDictionary<Key, Value> b, IList<Key> ignoreKeys)
        {
            var allkeys = new HashSetEx<Key>(a.Keys);
            allkeys.AddRange(b.Keys);
            foreach (Key key in allkeys)
            {
                if (ignoreKeys.Contains(key)) continue;
                if (!a.ContainsKey(key)) return false;
                if (!b.ContainsKey(key)) return false;
                if (!a[key].Equals(b[key])) return false;
            }
            return true;
        }
        public static string Format(this Dictionary<string, string> dict)
        {
            StringBuilder sb = new StringBuilder();
            bool was = false;
            foreach (var key in dict.Keys)
            {
                if (was) sb.Append(",");
                sb.AppendFormat("{0}={1}", key, dict[key]);
            }
            return sb.ToString();
        }
    }
}
