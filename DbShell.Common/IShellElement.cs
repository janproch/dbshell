﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Common
{
    public interface IShellElement
    {
        IConnectionProvider Connection { get; set; }
        void EnumChildren(Action<IShellElement> enumFunc);
    }
}