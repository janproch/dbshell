using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbShell.Driver.Common.Utility
{
    public static class JsonTool
    {
        public static void SetupSettings(JsonSerializerSettings settings)
        {
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.TypeNameHandling = TypeNameHandling.None;
            settings.Converters.Add(new StringEnumConverter { CamelCaseText = true });
        }

        public static JsonSerializerSettings GetDefaultSettings(Action<JsonSerializerSettings> overrides = null)
        {
            var settings = new JsonSerializerSettings();
            SetupSettings(settings);
            overrides?.Invoke(settings);
            return settings;
        }


        public static string Serialize(object o, Action<JsonSerializerSettings> overrides = null)
        {
            return JsonConvert.SerializeObject(o, Formatting.None, GetDefaultSettings(overrides));
        }

        public static string UnquoteUriName(string s)
        {
            return s?.Replace("@2", "/")?.Replace("@3", "#")?.Replace("@1", "@");
        }

        public static string SerializeAsObject(string[] fieldNames, object[] fieldValues)
        {
            var sb = new StringBuilder();
            sb.Append('{');
            for (int i = 0; i < fieldNames.Length; i++)
            {
                if (i > 0) sb.Append(',');
                sb.Append($"\"{fieldNames[i]}\":");
                sb.Append(Serialize(fieldValues[i]));
            }
            sb.Append('}');
            return sb.ToString();
        }

        public static T Deserilize<T>(string s, Action<JsonSerializerSettings> overrides = null)
        {
            return JsonConvert.DeserializeObject<T>(s, GetDefaultSettings(overrides));
        }

        public static object DeserilizeObject(string s, Action<JsonSerializerSettings> overrides = null)
        {
            return JsonConvert.DeserializeObject(s, GetDefaultSettings(overrides));
        }

    }
}
