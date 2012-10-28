using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.Structure;
using RazorEngine;
using RazorEngine.Templating;
using log4net;

namespace DbShell.Core
{
    public class RazorDatabase : ElementBase, IRunnable
    {
        private static ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public string File { get; set; }
        public string Template { get; set; }

        void IRunnable.Run()
        {
            _log.InfoFormat("Apply template {0}=>{1}", Template, File);
            using (var sr = new StreamReader(Template))
            {
                string templateData = sr.ReadToEnd();
                try
                {
                    string output = Razor.Parse(templateData, GetDatabaseStructure());
                    using (var sw = new StreamWriter(File))
                    {
                        sw.Write(output);
                    }
                }
                catch (TemplateCompilationException err)
                {
                    _log.ErrorFormat("Error compiling template {0}", Template);
                    foreach (var error in err.Errors)
                    {
                        _log.Error(error.ToString());
                    }
                }
            }
        }
    }
}
