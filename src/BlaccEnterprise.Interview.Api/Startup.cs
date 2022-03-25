using BlaccEnterprise.Interview.Api.Configurations;
using BlaccEnterprise.Interview.Infrastructure.Data.EFCore.Context;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BlaccEnterprise.Interview.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabaseSetup(Configuration);
            services.AddIdentitySetup(Configuration);
            
            services.AddControllers();
            
            services.AddAutoMapperSetup();
            services.AddAuthSetup(Configuration);
            services.AddSwaggerSetup();
            services.AddMediatR(typeof(Startup));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // .NET Native DI Abstraction
            services.AddDependencyInjectionSetup();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IAppEFCoreContextFactory appEFCoreContextFactory)
        {
            loggerFactory.AddFile(
                pathFormat: $"{env.ContentRootPath}\\Logs\\Log.txt",
                minimumLevel: LogLevel.Information,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] [{SourceContext}] [{EventId}] {Message}{NewLine}{Exception}");

            appEFCoreContextFactory.Register();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(m =>
            {
                m.AllowAnyHeader();
                m.AllowAnyMethod();
                m.AllowAnyOrigin();
            });

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerSetup();
        }
    }
}