using DbShell.Core.Utility;
using DbShell.Driver.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Xml
{
    public class DbShellXmlElementsProvider : IJsonElementProvider
    {
        public void EnumJsonTypes(Action<string, Type> typeFunc)
        {
            MiscTool.RegisterAllJsonTypes(typeof(DbShellXmlElementsProvider).Assembly, "DbShell.Xml", typeFunc);
        }
    }
}
