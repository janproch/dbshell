using DbShell.Driver.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Core
{
    public class CdlFileFormat : IDataFileFormat
    {
        public string Extension => ".cdl";

        public string Name => "CDL file";

        public ITabularDataSource CreateSource(string file)
        {
            return new CdlFile { Name = file };
        }

        public ITabularDataTarget CreateTarget(string file)
        {
            return new CdlFile { Name = file };
        }
    }
}
