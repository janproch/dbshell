using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Driver.Common.Interfaces
{
    public interface IJsonElementProvider
    {
        void EnumJsonTypes(Action<string, Type> typeFunc);
    }
}
