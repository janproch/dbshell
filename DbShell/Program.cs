using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using DbShell.Core.Runtime;
//using Microsoft.Extensions.Logging;
//using log4net.Config;
//using DbShell.FilterParser.Antlr;
//using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DbShell.Core.Runtime;
using DbShell.All;

namespace DbShell
{
    internal class Program
    {
        //private static ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //private static void AddSerilogServices(IServiceCollection services)
        //{
        //    var logger = new LoggerConfiguration()
        //        .MinimumLevel.Debug()
        //        .WriteTo.Console()
        //        .CreateLogger();

        //    services.AddSerilog();
        //}

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddDbShell();
        }

        private static void ConfigureLogging(IServiceProvider serviceProvider)
        {
            var serilogLogger = new LoggerConfiguration()
               .Enrich.FromLogContext()
               .WriteTo.Console()
               .CreateLogger();

            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            loggerFactory.AddSerilog(serilogLogger);
        }

        private static int Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();
            ConfigureLogging(serviceProvider);

            var logger = serviceProvider.GetService<ILogger<Program>>();

            var runner = new ShellRunner(serviceProvider);
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
                logger.LogError(err, "DBSH-00146 Error loading input DbShell script");
                return 1;
            }

            try
            {
                runner.Run();
            }
            catch (Exception err)
            {
                logger.LogError(err, "DBSH-00147 Error running process");
                return 2;
            }

            return 0;
        }
    }
}
