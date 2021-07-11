using Data.Model;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.Property(p => p.OrderId);
            builder.Property(p => p.ProductId).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.Value).IsRequired();
            builder.Property(p => p.Quantity).IsRequired();

            builder.HasQueryFilter(f => f.Status != Enums.Status.Deleted);
        }
    }
}
