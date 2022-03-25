using System.Globalization;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BlaccEnterprise.Interview.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("tr-TR");

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

#if DEBUG
                    webBuilder.CaptureStartupErrors(true);
                    webBuilder.UseSetting("detailedErrors", "true");
#endif
                });
    }
}
