using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Structure;

namespace DbShell.Common
{
    public interface IShellContext
    {
        DatabaseInfo GetDatabaseStructure(IConnectionProvider connection);

        void SetVariable(string name, object value);
        object Evaluate(string expression);
        void EnterScope();
        void LeaveScope();
        string Replace(string replaceString);

        void IncludeFile(string file, IShellElement parent);
    }
}
