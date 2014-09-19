using System.Collections;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.Structure;

namespace DbShell.Core
{
    /// <summary>
    /// Returns database structure, typed as <see cref="DatabaseInfo"/>
    /// </summary>
    public class DatabaseProvider : ElementBase, IModelProvider
    {
        public object GetModel(IShellContext context)
        {
            return context.GetDatabaseStructure(GetProviderString(context));
        }

        public void InitializeTemplate(IRazorTemplate template, IShellContext context)
        {
        }
    }
}