using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using DbShell.Common;
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

        protected string LoadTextContent(object model)
        {
            string templateData = LoadTemplate();
            if (templateData != null)
            {
                var sw = new StringWriter();
                RazorEngine.Razor.Parse(templateData, sw.Write, model);
                return sw.ToString();
            }

            string textData = TextData;

            if (textData == null && TextFile != null)
            {
                using (var sr = new StreamReader(Context.ResolveFile(Context.Replace(TextFile), ResolveFileMode.Input)))
                {
                    textData = sr.ReadToEnd();
                }
            }
            return textData;
        }
    }
}
