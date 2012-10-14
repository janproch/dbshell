using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;

namespace DbShell.Core
{
    public class File : ElementBase, ITabularDataTarget
    {
        void ITabularDataTarget.PutData(string data)
        {
            Console.WriteLine(data);
        }
    }
}
