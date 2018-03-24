using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Core.ScriptParser
{
    public interface IDbShellLanguageProvider
    {
        LanguageData DbShellLanguage { get; }
    }
}
