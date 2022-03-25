using BlaccEnterprise.Interview.Infrastructure.DomainEvents;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlaccEnterprise.Interview.Infrastructure.Data.EFCore.Configurations
{
    public class StoredDomainEventConfiguration : IEntityTypeConfiguration<StoredDomainEvent>
    {
        public void Configure(EntityTypeBuilder<StoredDomainEvent> builder)
        {
            builder.Property(m => m.Timestamp)
                .HasColumnName("CreationDate");

            builder.Property(m => m.Action)
                .HasColumnName("Action")
                .HasColumnType("varchar(100)");
        }
    }
}