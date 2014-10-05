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
        protected override void DoRun(IShellContext context)
        {
            var dbs = GetDatabaseStructure(context);
            context.SetVariable(GetDataSetVariableName(context), new DataSetModel(dbs, context, GetConnectionProvider(context).Factory));
        }
    }
}
