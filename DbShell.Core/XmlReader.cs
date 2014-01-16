﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;

namespace DbShell.Core
{
    /// <summary>
    /// Providers tabular data readed from XML file
    /// </summary>
    public class XmlReader : ElementBase, ITabularDataSource, IModelProvider
    {
        /// <summary>
        /// xpath, where rows are stored
        /// </summary>
        public string XPath { get; set; }

        /// <summary>
        /// list of defined columns
        /// </summary>
        public List<XmlColumn> Columns { get; set; }

        /// <summary>
        ///  name of input file
        /// </summary>
        public string File { get; set; }

        public XmlReader()
        {
            Columns = new List<XmlColumn>();
        }

        object IModelProvider.GetModel()
        {
            return this;
        }

        public void InitializeTemplate(IRazorTemplate template)
        {
            template.TabularData = this;
        }

        public TableInfo GetRowFormat()
        {
            var res = new TableInfo(null);
            foreach (var col in Columns)
            {
                res.Columns.Add(new ColumnInfo(res) { CommonType = new DbTypeString(), DataType = "nvarchar", Length = -1, Name = col.Name });
            }
            return res;
        }

        public ICdlReader CreateReader()
        {
            string file = Context.ResolveFile(Replace(File), ResolveFileMode.Input);
            var doc = new XmlDocument();
            doc.Load(file);
            return new XmlDocumentReader(doc, GetRowFormat(), Columns, XPath);
        }
    }
}