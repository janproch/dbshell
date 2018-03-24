using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace DbShell.Driver.Common.Interfaces
{
    public static class ShellContextExtensions
    {
        public static ILogger<T> GetLogger<T>(this IShellContext context)
        {
            return context.ServiceProvider.GetService<ILogger<T>>();
        }
    }
}
