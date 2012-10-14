using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using DbShell.Common;
using DbShell.Core;

namespace DbShell.Runtime
{
    public class ShellRunner
    {
        private IRunnable _main;

        public void LoadFile(string file)
        {
            CoreLoader.Load();
            using (var fr = new FileInfo(file).OpenRead())
            {
                object obj = XamlReader.Load(fr);
                _main = (IRunnable) obj;
            }
        }

        public void Run()
        {
            using (var context = new ShellContext())
            {
                _main.Run(context);
            }
        }
    }
}
