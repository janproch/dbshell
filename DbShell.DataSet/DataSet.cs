using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.DataSet.DataSetModels;
using DbShell.Core.Utility;

namespace DbShell.DataSet
{
    public class DataSet : DataSetItemBase
    {
        /// <summary>
        /// if true, undefined references will be imported with original value. Otherwise, NULL value will be used.
        /// </summary>
        [XamlProperty]
        public bool KeepUndefinedReferences { get; set; }

        protected override void DoRun(IShellContext context)
        {
            var dbs = GetDatabaseStructure(context);
            var model = new DataSetModel(dbs, context, GetConnectionProvider(context).Factory);
            model.KeepUndefinedReferences = KeepUndefinedReferences;
            context.SetVariable(GetDataSetVariableName(context), model);
        }
    }
}
