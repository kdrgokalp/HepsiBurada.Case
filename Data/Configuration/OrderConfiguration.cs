using Data.Model;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(p => p.OrderDate).IsRequired();
            builder.Property(p => p.OrderValue).IsRequired();

            builder.HasQueryFilter(f => f.Status != Enums.Status.Deleted);
        }
    }
}
