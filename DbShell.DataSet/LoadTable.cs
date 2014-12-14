using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;

namespace DbShell.DataSet
{
    public class LoadTable : DataSetItemBase
    {
        /// <summary>
        /// name of target table
        /// </summary>
        [XamlProperty]
        public string Table { get; set; }

        /// <summary>
        /// Source of copy operation
        /// </summary>
        /// <value>
        /// Table or data file
        /// </value>
        [XamlProperty]
        public ITabularDataSource Source { get; set; }

        /// <summary>
        /// Expression to obtain source of copy operation
        /// </summary>
        [XamlProperty]
        public string SourceExpression { get; set; }

        protected override void DoRun(IShellContext context)
        {
            ITabularDataSource source;

            if (Source != null && SourceExpression != null) throw new Exception("DBSH-00000 LoadTable: Both Source and SourceExpression are set");
            if (Source == null && SourceExpression == null) throw new Exception("DBSH-00000 LoadTable: None Source and SourceExpression are set");

            if (SourceExpression != null)
            {
                source = (ITabularDataSource) context.Evaluate(SourceExpression);
            }
            else
            {
                source = Source;
            }

            GetModel(context).LoadTable(source, Table, context);
        }
    }
}
