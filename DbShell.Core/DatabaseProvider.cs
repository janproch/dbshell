using System.Collections;
using DbShell.Common;
using DbShell.Core.Utility;

namespace DbShell.Core
{
    /// <summary>
    /// Returns database structure
    /// </summary>
    public class DatabaseProvider : ElementBase, IModelProvider
    {
        public object GetModel()
        {
            return GetDatabaseStructure();
        }
    }
}