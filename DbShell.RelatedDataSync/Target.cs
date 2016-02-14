using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using DbShell.Common;
using DbShell.Driver.Common.Structure;

namespace DbShell.RelatedDataSync
{
    [ContentProperty(nameof(Columns))]
    public class Target
    {
        [XamlProperty]
        public string TableSchema { get; set; }

        [XamlProperty]
        public string TableName { get; set; }

        [XamlProperty]
        public string PrimarySource { get; set; }

        [XamlProperty]
        public string Alias { get; set; }

        [XamlProperty]
        public List<TargetColumn> Columns { get; private set; } = new List<TargetColumn>();

        [XamlProperty]
        public string FullTableNameVariable { get; set; }

        [XamlProperty]
        public LifetimeHandlerBase LifetimeHandler { get; set; } = new LifetimeHandlerBase();

        [XamlProperty]
        public string Connection { get; set; }

        [XamlProperty]
        public string LinkedServerName { get; set; }

        [XamlProperty]
        public string LinkedDatabaseName { get; set; }

        [XamlProperty]
        public string ExplicitDatabaseName { get; set; }

        public LinkedDatabaseInfo LinkedInfo
        {
            get
            {
                if (!String.IsNullOrEmpty(ExplicitDatabaseName)) return new LinkedDatabaseInfo(ExplicitDatabaseName);
                return new LinkedDatabaseInfo(LinkedServerName, LinkedDatabaseName);
            }
            set
            {
                if (value == null)
                {
                    LinkedServerName = null;
                    LinkedDatabaseName = null;
                    ExplicitDatabaseName = null;
                }
                else
                {
                    LinkedServerName = value.LinkedServerName;
                    LinkedDatabaseName = value.LinkedDatabaseName;
                    ExplicitDatabaseName = value.ExplicitDatabaseName;
                }
            }
        }

        public void ReplaceTargetSchemaByTemplate(string template)
        {
            TableSchema = template;
            Connection = null;
            LinkedInfo = null;
        }
    }
}
