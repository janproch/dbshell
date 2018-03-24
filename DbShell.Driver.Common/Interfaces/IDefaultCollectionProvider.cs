using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Driver.Common.Interfaces
{
    public interface IDefaultCollectionProvider
    {
        IList DefaultCollection { get; }
    }
}
