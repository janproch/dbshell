using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Runtime;
using log4net;
using log4net.Config;

namespace DbShell
{
    internal class Program
    {
        private static ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static int Main(string[] args)
        {
            XmlConfigurator.Configure();

            var runner = new ShellRunner();
            try
            {
                runner.LoadFile(args[0]);
            }
            catch (Exception err)
            {
                _log.Error("Error loading XAML", err);
                return 1;
            }

            try
            {
                runner.Run();
            }
            catch (Exception err)
            {
                _log.Error("Error running process", err);
                return 2;
            }
            return 0;
        }
    }
}
