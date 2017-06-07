#if !NETSTANDARD1_5

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace DbShell.Core.Runtime
{
    public static class ShellLoader
    {
        public static object LoadFile(string file)
        {
            CoreLoader.Load();

            using (var fr = new FileInfo(file).OpenRead())
            {
                LoadModule.LoadModules(fr);
            }

            using (var fr = new FileInfo(file).OpenRead())
            {
                object obj = XamlReader.Load(fr);
                return obj;
            }
        }

        public static object LoadString(string content)
        {
            LoadModule.LoadModulesFromData(content);
            using (var fr = new StringReader(content))
            {
                using (var reader = System.Xml.XmlReader.Create(fr))
                {
                    object obj = XamlReader.Load(reader);
                    return obj;
                }
            }
        }
    }
}

#endif