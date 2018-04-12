using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Core.Utility;

namespace DbShell.Xml
{
    /// <summary>
    /// definition of column saved in XML
    /// </summary>
    public class XmlColumn : ElementBase
    {
        /// <summary>
        /// column name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// XPath (relative to row XML element), where columns date are stored
        /// </summary>
        public string XPath { get; set; }
    }
}
