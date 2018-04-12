using DbShell.Driver.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Xml
{
    public class XmlFileFormat : IDataFileFormat
    {
        public string Extension => ".xml";

        public string Name => "XML file";

        public ITabularDataSource CreateSource(string file)
        {
            return new XmlReader { File = file, AnalyseColumns = true };
        }

        public ITabularDataTarget CreateTarget(string file)
        {
            throw new NotImplementedException();
        }
    }
}
