using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Runtime;

namespace DbShell
{
    class Program
    {
        static void Main(string[] args)
        {
            var runner = new ShellRunner();
            runner.LoadFile(args[0]);
            runner.Run();
        }
    }
}
