using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace DbShell.RelatedDataSync
{
    [ContentProperty(nameof(Columns))]
    public class TargetReference
    {
        [XamlProperty]
        public List<TargetReferenceColumn> Columns { get; private set; } = new List<TargetReferenceColumn>();

        [XamlProperty]
        public string Source { get; set; }

        [XamlProperty]
        public string Target { get; set; }

        [XamlProperty]
        public bool IsKey { get; set; }

        [XamlProperty]
        public bool Compare { get; set; }

        [XamlProperty]
        public bool Update { get; set; } = true;

        [XamlProperty]
        public bool Insert { get; set; } = true;

        public void ReplaceTargetSchemaByTemplate(string template)
        {
            var identSrc = StructuredIdentifier.Parse(Source);

            if (identSrc.Count == 1 || identSrc.Count == 2)
            {
                Source = new StructuredIdentifier(new string[] { template, identSrc.Last }).ToString();
            }

            var identDst = StructuredIdentifier.Parse(Target);

            if (identDst.Count == 1 || identDst.Count == 2)
            {
                Target = new StructuredIdentifier(new string[] { template, identDst.Last }).ToString();
            }
        }
    }
}
