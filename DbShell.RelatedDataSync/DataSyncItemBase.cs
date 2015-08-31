using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.RelatedDataSync
{
    public abstract class DataSyncItemBase : RunnableBase
    {
        /// <summary>
        /// sync model name
        /// </summary>
        [XamlProperty]
        public string Name { get; set; }

        protected SyncModel GetModel(IShellContext context)
        {
            return (SyncModel)context.GetVariable(GetSyncModelVariableName(context));
        }

        protected string GetSyncModelVariableName(IShellContext context)
        {
            if (String.IsNullOrEmpty(Name)) return "DefaultSyncModel";
            return context.Replace(Name);
        }
    }

}
