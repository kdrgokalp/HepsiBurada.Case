using Data.Model;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Infrastructure
{
    public class CampaignContext : DbContext
    {
        public CampaignContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
