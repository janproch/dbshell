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
        object GetVariable(string name);
        object Evaluate(string expression);
        void EnterScope();
        void LeaveScope();
        string Replace(string replaceString, string replacePattern = null);
        void IncludeFile(string file, IShellElement parent);
        string ResolveFile(string file, ResolveFileMode mode);
        void PushExecutingFolder(string folder);
        void PopExecutingFolder();
        string GetExecutingFolder();
        void OutputMessage(string message);
        void AddSearchFolder(ResolveFileMode mode, string folder);
        void PutDatabaseInfoCache(string providerKey, DatabaseInfo db);
        IConnectionProvider DefaultConnection { get; set; }
        string DefaultOutputFolder { get; set; }
    }
}
