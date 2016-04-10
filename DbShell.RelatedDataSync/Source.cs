using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace DbShell.RelatedDataSync
{
    [ContentProperty(nameof(Columns))]
    public class Source
    {
        [XamlProperty]
        public ITabularDataSource DataSource { get; set; }

        [XamlProperty]
        public string Alias { get; set; }

        [XamlProperty]
        public bool Materialize { get; set; }

        [XamlProperty]
        public bool ForceExternalSource { get; set; }

        [XamlProperty]
        public List<SourceColumn> Columns { get; private set; } = new List<SourceColumn>();

        [XamlProperty]
        public string SourceTableVariable { get; set; }

        [XamlProperty]
        public string SourceQueryVariable { get; set; }

        #region TESTING
        [XamlProperty]
        public string OnExternalFilledAssertion { get; set; }

        [XamlProperty]
        public string OnExternalFilledRequiredValue { get; set; }
        #endregion

        public void ReplaceSouceSchemaByTemplate(string template)
        {
            var tbl = DataSource as TableOrView;
            if (tbl != null)
            {
                tbl.Schema = template;
                tbl.LinkedInfo = null;
                tbl.Connection = null;
            }
        }
    }
}
