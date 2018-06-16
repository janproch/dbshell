using DbShell.Core.Utility;
using DbShell.Driver.Common.Interfaces;
using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Xml
{
    public abstract class OutputXmlRunnableBase : RunnableBase
    {
        /// <summary>
        /// XML variable name
        /// </summary>
        [XamlProperty]
        public string VariableName { get; set; }

        protected System.Xml.XmlWriter GetModel(IShellContext context)
        {
            return (System.Xml.XmlWriter)context.GetVariable(GetXmlVariableName(context));
        }

        protected string GetXmlVariableName(IShellContext context)
        {
            if (String.IsNullOrEmpty(VariableName)) return "DefaultXml";
            return context.Replace(VariableName);
        }
    }
}
