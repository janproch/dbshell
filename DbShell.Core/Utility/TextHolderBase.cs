using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Interfaces;
using DbShell.Core.RazorModels;
using Microsoft.Extensions.Logging;

namespace DbShell.Core.Utility
{
    public abstract class TextHolderBase : TemplateHolderBase
    {
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
#if !NETSTANDARD2_0
            string templateData = LoadTemplate(context);
            if (templateData != null)
            {
                var sw = new StringWriter();
                RazorScripting.ParseRazor(templateData, sw.Write, model);
                return sw.ToString();
            }
#endif

            string textData = TextData;

            if (textData == null && TextFile != null)
            {
                using (var sr = new StreamReader(System.IO.File.OpenRead(context.ResolveFile(context.Replace(TextFile), ResolveFileMode.Input))))
                {
                    textData = sr.ReadToEnd();
                }
            }
            return textData;
        }
    }
}
