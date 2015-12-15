using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.DataSet.DataSetModels;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Utility;

namespace DbShell.DataSet
{
    public abstract class DataSetItemBase : RunnableBase
    {
        /// <summary>
        /// data set name
        /// </summary>
        [XamlProperty]
        public string DataSetName { get; set; }

        protected DataSetModel GetModel(IShellContext context)
        {
            return (DataSetModel) context.GetVariable(GetDataSetVariableName(context)); 
        }

        protected string GetDataSetVariableName(IShellContext context)
        {
            if (String.IsNullOrEmpty(DataSetName)) return "DefaultDataSet";
            return context.Replace(DataSetName);
        }
    }
}
