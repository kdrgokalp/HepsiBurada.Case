using Data.Model;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class CampaignConfiguration : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(10).IsRequired();
            builder.Property(p => p.ProductId);
            builder.Property(p => p.Duration).IsRequired();
            builder.Property(p => p.PriceManipulationLimit).IsRequired();
            builder.Property(p => p.TargetSalesCount).IsRequired();
            builder.Property(p => p.CampaignStartDate).IsRequired();

            builder.HasIndex(p => p.ProductId);
            builder.HasQueryFilter(f => f.Status != Enums.Status.Deleted);
        }
    }
}
