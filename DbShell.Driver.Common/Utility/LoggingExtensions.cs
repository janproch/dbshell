using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace DbShell.Driver.Common.Utility
{
    public static class LoggingExtensions
    {
        public static void LogCritical<T>(this IServiceProvider serviceProvider, Exception exception, string message, params object[] args)
        {
            var logger = (serviceProvider ?? GenericServicesProvider.InternalInstance).GetService<ILogger<T>>();
            logger.LogCritical(exception, message, args);
        }
        public static void LogCritical<T>(this IServiceProvider serviceProvider, EventId eventId, string message, params object[] args)
        {
            var logger = (serviceProvider ?? GenericServicesProvider.InternalInstance).GetService<ILogger<T>>();
            logger.LogCritical(eventId, message, args);
        }
        public static void LogCritical<T>(this IServiceProvider serviceProvider, EventId eventId, Exception exception, string message, params object[] args)
        {
            var logger = (serviceProvider ?? GenericServicesProvider.InternalInstance).GetService<ILogger<T>>();
            logger.LogCritical(eventId, exception, message, args);
        }
        public static void LogCritical<T>(this IServiceProvider serviceProvider, string message, params object[] args)
        {
            var logger = (serviceProvider ?? GenericServicesProvider.InternalInstance).GetService<ILogger<T>>();
            logger.LogCritical(message, args);
        }
        public static void LogDebug<T>(this IServiceProvider serviceProvider, EventId eventId, Exception exception, string message, params object[] args)
        {
            var logger = (serviceProvider ?? GenericServicesProvider.InternalInstance).GetService<ILogger<T>>();
            logger.LogDebug(eventId, exception, message, args);
        }
        public static void LogDebug<T>(this IServiceProvider serviceProvider, EventId eventId, string message, params object[] args)
        {
            var logger = (serviceProvider ?? GenericServicesProvider.InternalInstance).GetService<ILogger<T>>();
            logger.LogDebug(eventId, message, args);
        }
        public static void LogDebug<T>(this IServiceProvider serviceProvider, Exception exception, string message, params object[] args)
        {
            var logger = (serviceProvider ?? GenericServicesProvider.InternalInstance).GetService<ILogger<T>>();
            logger.LogDebug(exception, message, args);
        }
        public static void LogDebug<T>(this IServiceProvider serviceProvider, string message, params object[] args)
        {
            var logger = (serviceProvider ?? GenericServicesProvider.InternalInstance).GetService<ILogger<T>>();
            logger.LogDebug(message, args);
        }
        public static void LogError<T>(this IServiceProvider serviceProvider, EventId eventId, Exception exception, string message, params object[] args)
        {
            var logger = (serviceProvider ?? GenericServicesProvider.InternalInstance).GetService<ILogger<T>>();
            logger.LogError(eventId, exception, message, args);
        }
        public static void LogError<T>(this IServiceProvider serviceProvider, EventId eventId, string message, params object[] args)
        {
            var logger = (serviceProvider ?? GenericServicesProvider.InternalInstance).GetService<ILogger<T>>();
            logger.LogError(eventId, message, args);
        }
        public static void LogError<T>(this IServiceProvider serviceProvider, Exception exception, string message, params object[] args)
        {
            var logger = (serviceProvider ?? GenericServicesProvider.InternalInstance).GetService<ILogger<T>>();
            logger.LogError(exception, message, args);
        }
        public static void LogError<T>(this IServiceProvider serviceProvider, string message, params object[] args)
        {
            var logger = (serviceProvider ?? GenericServicesProvider.InternalInstance).GetService<ILogger<T>>();
            logger.LogError(message, args);
        }
        public static void LogInformation<T>(this IServiceProvider serviceProvider, EventId eventId, Exception exception, string message, params object[] args)
        {
            var logger = (serviceProvider ?? GenericServicesProvider.InternalInstance).GetService<ILogger<T>>();
            logger.LogInformation(eventId, exception, message, args);
        }
        public static void LogInformation<T>(this IServiceProvider serviceProvider, EventId eventId, string message, params object[] args)
        {
            var logger = (serviceProvider ?? GenericServicesProvider.InternalInstance).GetService<ILogger<T>>();
            logger.LogInformation(eventId, message, args);
        }
        public static void LogInformation<T>(this IServiceProvider serviceProvider, Exception exception, string message, params object[] args)
        {
            var logger = (serviceProvider ?? GenericServicesProvider.InternalInstance).GetService<ILogger<T>>();
            logger.LogInformation(exception, message, args);
        }
        public static void LogInformation<T>(this IServiceProvider serviceProvider, string message, params object[] args)
        {
            var logger = (serviceProvider ?? GenericServicesProvider.InternalInstance).GetService<ILogger<T>>();
            logger.LogInformation(message, args);
        }
        public static void LogTrace<T>(this IServiceProvider serviceProvider, Exception exception, string message, params object[] args)
        {
            var logger = (serviceProvider ?? GenericServicesProvider.InternalInstance).GetService<ILogger<T>>();
            logger.LogTrace(exception, message, args);
        }
        public static void LogTrace<T>(this IServiceProvider serviceProvider, string message, params object[] args)
        {
            var logger = (serviceProvider ?? GenericServicesProvider.InternalInstance).GetService<ILogger<T>>();
            logger.LogTrace(message, args);
        }
        public static void LogTrace<T>(this IServiceProvider serviceProvider, EventId eventId, Exception exception, string message, params object[] args)
        {
            var logger = (serviceProvider ?? GenericServicesProvider.InternalInstance).GetService<ILogger<T>>();
            logger.LogTrace(eventId, exception, message, args);
        }
        public static void LogTrace<T>(this IServiceProvider serviceProvider, EventId eventId, string message, params object[] args)
        {
            var logger = (serviceProvider ?? GenericServicesProvider.InternalInstance).GetService<ILogger<T>>();
            logger.LogTrace(eventId, message, args);
        }
        public static void LogWarning<T>(this IServiceProvider serviceProvider, string message, params object[] args)
        {
            var logger = (serviceProvider ?? GenericServicesProvider.InternalInstance).GetService<ILogger<T>>();
            logger.LogWarning(message, args);
        }
        public static void LogWarning<T>(this IServiceProvider serviceProvider, EventId eventId, string message, params object[] args)
        {
            var logger = (serviceProvider ?? GenericServicesProvider.InternalInstance).GetService<ILogger<T>>();
            logger.LogWarning(eventId, message, args);
        }
        public static void LogWarning<T>(this IServiceProvider serviceProvider, Exception exception, string message, params object[] args)
        {
            var logger = (serviceProvider ?? GenericServicesProvider.InternalInstance).GetService<ILogger<T>>();
            logger.LogWarning(exception, message, args);
        }
        public static void LogWarning<T>(this IServiceProvider serviceProvider, EventId eventId, Exception exception, string message, params object[] args)
        {
            var logger = (serviceProvider ?? GenericServicesProvider.InternalInstance).GetService<ILogger<T>>();
            logger.LogWarning(eventId, exception, message, args);
        }
    }
}
