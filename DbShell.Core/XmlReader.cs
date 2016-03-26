using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using System.Windows.Markup;

namespace DbShell.Core
{
    /// <summary>
    /// Providers tabular data readed from XML file
    /// </summary>
    public class XmlReader : ElementBase, ITabularDataSource, IModelProvider
    {
        /// <summary>
        ///  name of input file
        /// </summary>
        [XamlProperty]
        public string File { get; set; }

        /// <summary>
        /// whether to automatic analyse columns
        /// </summary>
        [XamlProperty]
        public bool AnalyseColumns { get; set; }

        /// <summary>
        /// instructions for creating reader (xpath, columns)
        /// </summary>
        [XamlProperty]
        public List<XmlReadInstructions> Instructions { get; set; } = new List<XmlReadInstructions>();


        /// <summary>
        /// xpath, where rows are stored (use instructions for multiple xpaths)
        /// </summary>
        [XamlProperty]
        public string XPath { get; set; }

        /// <summary>
        /// list of defined columns (use instructions for multiple xpaths)
        /// </summary>
        [XamlProperty]
        public List<XmlColumn> Columns { get; set; } = new List<XmlColumn>();

        DataFormatSettings ITabularDataSource.GetSourceFormat(IShellContext context)
        {
            return null;
        }

        object IModelProvider.GetModel(IShellContext context)
        {
            return this;
        }

        public void InitializeTemplate(IRazorTemplate template, IShellContext context)
        {
            template.TabularData = this;
        }

        private List<XmlReadInstructions> GetInstructions(IShellContext context)
        {
            if (!AnalyseColumns)
            {
                var res = new List<XmlReadInstructions>();
                if (!String.IsNullOrEmpty(XPath) && Columns.Any())
                {
                    res.Add(new XmlReadInstructions
                    {
                        Columns = Columns,
                        XPath = XPath,
                    });
                }
                if (Instructions != null) res.AddRange(res);
                return res;
            }

            string file = context.ResolveFile(context.Replace(File), ResolveFileMode.Input);
            return XmlTableAnalyser.AnalyseFile(file, true);
        }

        public TableInfo GetRowFormat(IShellContext context)
        {
            var instructions = GetInstructions(context);

            var res = new TableInfo(null);
            foreach (var instruction in instructions)
            {
                foreach (var col in instruction.Columns)
                {
                    if (res.Columns.Any(x => x.Name == col.Name)) continue;
                    res.Columns.Add(new ColumnInfo(res) { CommonType = new DbTypeString(), DataType = "nvarchar", Length = -1, Name = col.Name });
                }
            }
            return res;
        }

        public ICdlReader CreateReader(IShellContext context)
        {
            var instructions = GetInstructions(context);

            string file = context.ResolveFile(context.Replace(File), ResolveFileMode.Input);
            var doc = new XmlDocument();
            doc.Load(file);
            return new XmlDocumentReader(doc, GetRowFormat(context), instructions);
        }

        public override string ToString()
        {
            return String.Format("[XmlReader {0}]", File);
        }

        public override string ToStringCtx(IShellContext context)
        {
            return String.Format("[XmlReader {0}]", context.Replace(File));
        }

    }
}
