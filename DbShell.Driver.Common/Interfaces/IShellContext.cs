using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.Interfaces
{
    public interface IShellContext : IDisposable
    {
        DatabaseInfo GetDatabaseStructure(string providerKey);
        void SetVariable(string name, object value);
        object GetVariable(string name);
        object Evaluate(string expression);
        //void EnterScope();
        //void LeaveScope();
        void CreateScope();
        string Replace(string replaceString, string replacePattern = null);
        void IncludeFile(string file);
        string ResolveFile(string file, ResolveFileMode mode);

        void SetExecutingFolder(string folder);
        //void PopExecutingFolder();
        string GetExecutingFolder();

        void SetDefaultConnection(string connection);
        //void PopDefaultConnection();
        string GetDefaultConnection();

        void OutputMessage(string message);
        void AddSearchFolder(ResolveFileMode mode, string folder);
        void PutDatabaseInfoCache(string providerKey, DatabaseInfo db);
        //string DefaultConnection { get; set; }
        //string DefaultOutputFolder { get; set; }

        void SetDefaultOutputFolder(string value);
        string GetDefaultOutputFolder();

        IShellContext CreateChildContext();
        void AddDisposableItem(IDisposable disposable);

        IServiceProvider ServiceProvider { get; }
    }
}
