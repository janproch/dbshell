using DbShell.Driver.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Core.Utility
{
    public class DbShellCoreElementsProvider : IJsonElementProvider
    {
        public void EnumJsonTypes(Action<string, Type> typeFunc)
        {
            typeFunc("copyTable", typeof(CopyTable));
            typeFunc("cdlFile", typeof(CdlFile));
            typeFunc("createTable", typeof(CreateTable));
            typeFunc("echo", typeof(Echo));
            typeFunc("batch", typeof(Batch));
            typeFunc("setVariable", typeof(SetVariable));
            typeFunc("include", typeof(Include));
            typeFunc("table", typeof(Table));
            typeFunc("file", typeof(File));
            typeFunc("forEach", typeof(ForEach));
            typeFunc("getTables", typeof(GetTables));
            typeFunc("getFiles", typeof(GetFiles));
            typeFunc("setConnection", typeof(SetConnection));
        }
    }
}
