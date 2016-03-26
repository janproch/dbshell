using DbShell.Core.Utility;
using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Core
{
    public class XmlReadInstructions : ElementBase
    {
        /// <summary>
        /// xpath, where rows are stored
        /// </summary>
        [XamlProperty]
        public string XPath { get; set; }

        /// <summary>
        /// list of defined columns
        /// </summary>
        [XamlProperty]
        public List<XmlColumn> Columns { get; set; } = new List<XmlColumn>();

        /// <summary>
        /// name of collections (filled by XmlTableAnalyser)
        /// </summary>
        public string CollectionName { get; set; }
    }
}
