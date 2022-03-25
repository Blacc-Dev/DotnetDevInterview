using BlaccEnterprise.Interview.Infrastructure.Data.EFCore.Configurations;
using BlaccEnterprise.Interview.Infrastructure.DomainEvents;

using Microsoft.EntityFrameworkCore;

namespace BlaccEnterprise.Interview.Infrastructure.Data.EFCore
{
    public class StoredDomainEventEFCoreContext : DbContext
    {
        public StoredDomainEventEFCoreContext(DbContextOptions<StoredDomainEventEFCoreContext> options) : base(options) { }

        public DbSet<StoredDomainEvent> StoredDomainEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredDomainEventConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}