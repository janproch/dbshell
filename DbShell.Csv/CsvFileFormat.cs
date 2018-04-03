using DbShell.Driver.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Csv
{
    public class CsvFileFormat : IDataFileFormat
    {
        public string Extension => ".csv";

        public string Name => "CSV file";

        public ITabularDataSource CreateSource(string file)
        {
            return new CsvFile { Name = file };
        }

        public ITabularDataTarget CreateTarget(string file)
        {
            return new CsvFile { Name = file };
        }
    }
}
