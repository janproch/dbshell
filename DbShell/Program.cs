using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Core.Runtime;
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
                for (int i = 1; i < args.Length; i++)
                {
                    if (args[i].StartsWith("--"))
                    {
                        string name = args[i].Substring(2);
                        i++;
                        if (i >= args.Length) break;
                        runner.Context.SetVariable(name, args[i]);
                    }
                    else if (args[i] == "/sqlconn")
                    {
                        i++;
                        if (i >= args.Length) break;

                        string sqlconn = args[i];
                        runner.Context.SetDefaultConnection("sqlserver://" + sqlconn);
                    }
                }
            }
            catch (Exception err)
            {
                _log.Error("DBSH-00146 Error loading XAML", err);
                return 1;
            }

            try
            {
                runner.Run();
            }
            catch (Exception err)
            {
                _log.Error("DBSH-00147 Error running process", err);
                return 2;
            }
            return 0;
        }
    }
}
