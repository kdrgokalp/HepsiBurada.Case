using Data.Model;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.ProductCode).HasMaxLength(5);
            builder.Property(p => p.Price).IsRequired();

            builder.HasQueryFilter(f => f.Status != Enums.Status.Deleted);
        }
    }
}
