using BlaccEnterprise.Interview.Domain.Order;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlaccEnterprise.Interview.Infrastructure.Data.EFCore.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(m => m.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            builder.Property(m => m.OrderNumber)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.OrderDate)
                .HasColumnType("datetime2(7)")
                .IsRequired();

            builder.Property(m => m.Amount)
                .HasColumnType("float")
                .IsRequired();

            builder.Property(m => m.Status)
                .HasColumnType("tinyint")
                .IsRequired();

            builder.Property(m => m.OrderSource)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.HasKey(m => m.Id);
            builder.ToTable("Orders");
        }
    }
}