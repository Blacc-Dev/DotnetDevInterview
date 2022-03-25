using System;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Z.EntityFramework.Extensions;

namespace BlaccEnterprise.Interview.Infrastructure.Data.EFCore.Context
{
    public interface IAppEFCoreContextFactory
    {
        void Register();
    }

    public class AppEFCoreContextFactory : IAppEFCoreContextFactory
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;

        public AppEFCoreContextFactory(IHttpContextAccessor contextAccessor, IConfiguration configuration)
        {
            _configuration = configuration;
            _contextAccessor = contextAccessor;
        }

        public void Register()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppEFCoreContext>();
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));

            EntityFrameworkManager.ContextFactory = context =>
            {
                return (AppEFCoreContext)Activator.CreateInstance(typeof(AppEFCoreContext), optionsBuilder.Options, _contextAccessor); ;
            };
        }
    }
}