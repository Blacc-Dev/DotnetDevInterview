using System.Reflection;

using BlaccEnterprise.Interview.Application.Reporting.Entities;
using BlaccEnterprise.Interview.Domain.CargoInterview;
using BlaccEnterprise.Interview.Domain.LineInterview;
using BlaccEnterprise.Interview.Domain.Order;
using BlaccEnterprise.Interview.Infrastructure.Data.EFCore.Configurations;
using BlaccEnterprise.Interview.Infrastructure.Data.EFCore.Context;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BlaccEnterprise.Interview.Infrastructure.Data.EFCore
{
    public class AppEFCoreContext : EntityContextBase<AppEFCoreContext>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private static MethodInfo ConfigureGlobalFiltersMethodInfo = typeof(AppEFCoreContext).GetMethod(nameof(ConfigureGlobalFilters), BindingFlags.Instance | BindingFlags.NonPublic);

        public AppEFCoreContext(DbContextOptions<AppEFCoreContext> options, IHttpContextAccessor httpContextAccessor) : base(options, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<LineInterview> LineInterviews { get; set; }
        public DbSet<CargoInterview> CargoInterviews { get; set; }
        public DbSet<BestSellingProduct> BestSellingProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BestSellingProductConfiguration());
            modelBuilder.ApplyConfiguration(new CargoInterviewConfiguration());
            modelBuilder.ApplyConfiguration(new LineInterviewConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}