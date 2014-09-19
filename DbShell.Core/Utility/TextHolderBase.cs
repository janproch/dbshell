using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using DbShell.Common;
using DbShell.Core.RazorModels;
using log4net;

namespace DbShell.Core.Utility
{
    public abstract class TextHolderBase : TemplateHolderBase
    {
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Raw text input file
        /// </summary>
        public string TextFile { get; set; }

        /// <summary>
        /// Inlined template data
        /// </summary>
        public string TextData { get; set; }

        protected string LoadTextContent(object model, IShellContext context)
        {
            string templateData = LoadTemplate(context);
            if (templateData != null)
            {
                var sw = new StringWriter();
                RazorScripting.ParseRazor(templateData, sw.Write, model);
                return sw.ToString();
            }

            string textData = TextData;

            if (textData == null && TextFile != null)
            {
                using (var sr = new StreamReader(context.ResolveFile(context.Replace(TextFile), ResolveFileMode.Input)))
                {
                    textData = sr.ReadToEnd();
                }
            }
            return textData;
        }
    }
}
