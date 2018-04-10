using DbShell.Core.Utility;
using DbShell.Driver.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Csv
{
    public class DbShellCsvElementsProvider : IJsonElementProvider
    {
        public void EnumJsonTypes(Action<string, Type> typeFunc)
        {
            MiscTool.RegisterAllJsonTypes(typeof(DbShellCsvElementsProvider).Assembly, "DbShell.Csv", typeFunc);
            //typeFunc("csvFile", typeof(CsvFile));
        }
    }
}
