using BlaccEnterprise.Interview.Domain.CargoInterview;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlaccEnterprise.Interview.Infrastructure.Data.EFCore.Configurations
{
    public class CargoInterviewConfiguration : IEntityTypeConfiguration<CargoInterview>
    {
        public void Configure(EntityTypeBuilder<CargoInterview> builder)
        {
            builder.Property(m => m.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            builder.Property(m => m.OrderId)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(m => m.Name)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.TrackingNumber)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasKey(m => m.Id);
            builder.ToTable("CargoInterviews");
        }
    }
}