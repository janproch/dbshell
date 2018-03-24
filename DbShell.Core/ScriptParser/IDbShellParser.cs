using DbShell.Driver.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Core.ScriptParser
{
    public interface IDbShellParser
    {
        IRunnable Parse(string text);
    }
}
