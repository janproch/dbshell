using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace DbShell.Common
{
    public interface IShellContext
    {
        IConnectionProvider ConnectionProvider { get; set; }
        string CurrentDirectory { get; set; }
    }
}
