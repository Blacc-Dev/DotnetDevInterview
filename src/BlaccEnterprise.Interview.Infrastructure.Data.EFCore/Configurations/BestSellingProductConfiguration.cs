using BlaccEnterprise.Interview.Application.Reporting.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlaccEnterprise.Interview.Infrastructure.Data.EFCore.Configurations
{
    public class BestSellingProductConfiguration : IEntityTypeConfiguration<BestSellingProduct>
    {
        public void Configure(EntityTypeBuilder<BestSellingProduct> builder)
        {
            builder.HasNoKey();
        }
    }
}