using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Driver.Common.Interfaces
{
    public interface IDataFileFormat
    {
        string Extension { get; }
        string Name { get; }

        ITabularDataSource CreateSource(string file);
        ITabularDataTarget CreateTarget(string file);
    }
}
