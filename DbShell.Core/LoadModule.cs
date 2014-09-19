using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using DbShell.Common;
using DbShell.Core.Utility;

namespace DbShell.Core
{
    public class LoadModule : RunnableBase
    {
        [XamlProperty]
        public string File { get; set; }

        protected override void DoRun(IShellContext context)
        {
            LoadModuleFile(File);
        }

        public static void LoadModuleFile(string file)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string fullPath = Path.Combine(path, file);
            Assembly.LoadFrom(fullPath);
        }

        public static void LoadModulesFromData(string content)
        {
            var doc = new XmlDocument();
            doc.LoadXml(content);
            LoadModules(doc);
        }

        public static void LoadModules(XmlDocument doc)
        {
            var ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("dbshell", "http://schemas.dbshell.com/core");
            foreach (XmlElement elem in doc.SelectNodes("//dbshell:LoadModule", ns))
            {
                LoadModuleFile(elem.GetAttribute("File"));
            }
        }

        public static void LoadModules(Stream fr)
        {
            var doc = new XmlDocument();
            doc.Load(fr);
            LoadModules(doc);
        }
    }
}
