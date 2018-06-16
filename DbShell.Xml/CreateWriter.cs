using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Interfaces;
using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DbShell.Xml
{
    public class CreateWriter : OutputXmlRunnableBase
    {
        /// <summary>
        /// file name of XML file
        /// </summary>
        [XamlProperty]
        public string File { get; set; }

        /// <summary>
        /// data format
        /// </summary>
        [XamlProperty]
        public DataFormatSettings DataFormat { get; set; }

        protected override void DoRun(IShellContext context)
        {
            string file = context.ResolveFile(context.Replace(File), ResolveFileMode.Output);
            context.Info("Writing file " + Path.GetFullPath(file));
            var writer = XmlWriter.CreateWriter(file);
            context.SetVariable(GetXmlVariableName(context), writer);
        }
    }
}
