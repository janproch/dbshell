using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using DbShell.Common;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Utility;
using log4net;

namespace DbShell.Core.Utility
{
    [ContentProperty("TemplateData")]
    public abstract class TemplateHolderBase : RunnableBase
    {
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Gets or sets the template file.
        /// </summary>
        /// <value>
        /// File name of Razor template (cshtml file)
        /// </value>
        [XamlProperty]
        public string TemplateFile { get; set; }

        /// <summary>
        /// Inlined template data
        /// </summary>
        [XamlProperty]
        public string TemplateData { get; set; }

        protected string LoadTemplate(IShellContext context)
        {
            string templateData = TemplateData;

            if (templateData == null && TemplateFile != null)
            {
                using (var sr = new StreamReader(context.ResolveFile(context.Replace(TemplateFile), ResolveFileMode.Template)))
                {
                    templateData = sr.ReadToEnd();
                }
            }
            return templateData;
        }
    }
}
