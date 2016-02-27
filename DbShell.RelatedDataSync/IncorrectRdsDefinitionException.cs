using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.RelatedDataSync
{
    public class IncorrectRdsDefinitionException : Exception
    {
        public IncorrectRdsDefinitionException(string message) : base(message)
        {
        }
    }
}
