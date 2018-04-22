using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Driver.Common.Utility
{
    public static class ServiceProviderExtensions
    {
        public static T GetCachedService<T>(this IServiceProvider serviceProvider, ref T cachedValue)
        {
            if (cachedValue != null)
                return cachedValue;

            cachedValue = serviceProvider.GetRequiredService<T>();
            return cachedValue;
        }
    }
}
