using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace DbShell.Driver.Common.Utility
{
    public class GenericLogger<T> : ILogger<T>
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return new GenericLoggerScope();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            Console.WriteLine(formatter(state, exception));
        }
    }

    public class GenericLoggerScope : IDisposable
    {
        public void Dispose()
        {
        }
    }

    public class GenericServicesProvider : IServiceProvider
    {
        public static readonly GenericServicesProvider InternalInstance = new GenericServicesProvider();

        private GenericServicesProvider()
        {

        }
        public object GetService(Type serviceType)
        {
            if (serviceType.IsGenericType && serviceType.GetGenericTypeDefinition() == typeof(ILogger<>))
            {
                var loggerType = typeof(GenericLogger<>).MakeGenericType(serviceType.GetGenericArguments());
                return Activator.CreateInstance(loggerType);
            }
            return null;
        }
    }
}
