using System;

using BlaccEnterprise.Interview.Application.Mapping;

using Microsoft.Extensions.DependencyInjection;

namespace BlaccEnterprise.Interview.Api.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) 
                throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
        }
    }
}