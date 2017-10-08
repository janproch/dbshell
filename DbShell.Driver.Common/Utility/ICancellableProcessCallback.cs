using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Driver.Common
{
    public interface ICancelableProcessCallback
    {
        void AddCancelMethod(object owner, Action method);
        void RemoveCancelMethod(object owner);
    }
}
