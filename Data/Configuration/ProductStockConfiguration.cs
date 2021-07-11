using Data.Model;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class ProductStockConfiguration : IEntityTypeConfiguration<ProductStock>
    {
        public void Configure(EntityTypeBuilder<ProductStock> builder)
        {
            builder.Property(p => p.Quantity).IsRequired();
            builder.Property(p => p.Status).IsRequired();

            builder.HasQueryFilter(f => f.Status != Enums.Status.Deleted);
        }
    }
}
