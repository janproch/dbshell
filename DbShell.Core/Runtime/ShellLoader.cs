using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using DbShell.Driver.Common.Utility;
using DbShell.Driver.Common.Interfaces;
using System.Collections;
using Newtonsoft.Json.Linq;
using DbShell.Core.ScriptParser;

namespace DbShell.Core.Runtime
{
    public enum DbShellLanguage
    {
        Json,
        DbShellDsl,
        Xaml,
    }

    public static class ShellLoader
    {
        public static object LoadFile(string file, IServiceProvider serviceProvider)
        {
            string text = System.IO.File.ReadAllText(file);
            return LoadString(text, serviceProvider);
        }

        public static DbShellLanguage DetectLanguage(string content)
        {
            string trimmed = content.TrimStart();
            if (trimmed.Length == 0)
                return DbShellLanguage.DbShellDsl;
            if (trimmed[0] == '{')
                return DbShellLanguage.Json;
            if (trimmed[0] == '<')
                return DbShellLanguage.Xaml;
            return DbShellLanguage.DbShellDsl;
        }

        public static object LoadString(string content, IServiceProvider serviceProvider)
        {
            var language = DetectLanguage(content);
            switch (language)
            {
                case DbShellLanguage.Json:
                    return LoadStringJson(content, serviceProvider);
                case DbShellLanguage.DbShellDsl:
                    return LoadStringDsl(content, serviceProvider);
                case DbShellLanguage.Xaml:
                    throw new Exception("DBSH-00000 XAML is no longer supported for DbShell scripting");
            }
            return null;
        }

        public static object LoadStringDsl(string content, IServiceProvider serviceProvider)
        {
            var parser = serviceProvider.GetRequiredService<IDbShellParser>();
            return parser.Parse(content);
        }

        public static object LoadStringJson(string content, IServiceProvider serviceProvider)
        {
            var jsonElementFactory = serviceProvider.GetRequiredService<IJsonElementFactory>();

            var settings = new JsonSerializerSettings
            {
                SerializationBinder = jsonElementFactory.JsonBinder,
                TypeNameHandling = TypeNameHandling.Objects,
            };

            return JsonConvert.DeserializeObject(content, settings);
        }

        //public static object ExtractObject(JObject serialized, IServiceProvider serviceProvider)
        //{
        //    var jsonElementFactory = serviceProvider.GetRequiredService<IJsonElementFactory>();

        //    var serializer = new JsonSerializer
        //    {
        //        SerializationBinder = jsonElementFactory.JsonBinder,
        //        TypeNameHandling = TypeNameHandling.Objects,
        //    };
        //}

        //    public static IRunnable ExtractRunnable(object loadedObject, IServiceProvider serviceProvider, bool mustExist = false)
        //    {
        //        if (loadedObject is IRunnable res)
        //            return res;

        //        if (loadedObject is IEnumerable enumerable)
        //        {
        //            var batch = new Batch();

        //            foreach (var item in enumerable)
        //            {
        //                if (item is JObject jobj)
        //                {
        //                    ExtractObject(jobj, serviceProvider);
        //                }
        //                else
        //                {
        //                    batch.Commands.Add((IRunnable)item);
        //                }
        //            }

        //            return batch;
        //        }

        //        if (mustExist)
        //            throw new Exception(String.Format("Root object doesn't implement IRunnable"));

        //        return null;
        //    }
    }
}
