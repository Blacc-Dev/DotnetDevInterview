using System;

using BlaccEnterprise.Interview.Infrastructure.CrossCutting.IoC;

using Microsoft.Extensions.DependencyInjection;

namespace BlaccEnterprise.Interview.Api.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}