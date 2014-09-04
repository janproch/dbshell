using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.DataSet.DataSetModels;
using DbShell.Core.Utility;

namespace DbShell.DataSet
{
    public abstract class DataSetItemBase : RunnableBase
    {
        /// <summary>
        /// data set name
        /// </summary>
        public string Name { get; set; }

        protected DataSetModel Model
        {
            get { return (DataSetModel) Context.GetVariable(DataSetVariableName); }
        }

        protected string DataSetVariableName
        {
            get
            {
                if (String.IsNullOrEmpty(Name)) return "DefaultDataSet";
                return Replace(Name);
            }
        }
    }
}
