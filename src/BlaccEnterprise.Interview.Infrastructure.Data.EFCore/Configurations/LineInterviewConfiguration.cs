using BlaccEnterprise.Interview.Domain.LineInterview;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlaccEnterprise.Interview.Infrastructure.Data.EFCore.Configurations
{
    public class LineInterviewConfiguration : IEntityTypeConfiguration<LineInterview>
{
        public void Configure(EntityTypeBuilder<LineInterview> builder)
        {
            builder.Property(m => m.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            builder.Property(m => m.OrderId)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(m => m.ProductName)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.Quantity)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(m => m.Amount)
                .HasColumnType("float")
                .IsRequired();

            builder.HasKey(m => m.Id);
            builder.ToTable("LineInterviews");
        }
    }
}