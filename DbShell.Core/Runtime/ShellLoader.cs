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

namespace DbShell.Core.Runtime
{
    public static class ShellLoader
    {
        public static object LoadFile(string file, IServiceProvider serviceProvider)
        {
            string text = System.IO.File.ReadAllText(file);
            return LoadString(text, serviceProvider);
        }

        public static object LoadString(string content, IServiceProvider serviceProvider)
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
