using Habaripay.ShopsRUs.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habaripay.ShopsRUs.Data
{
    public class ShopsRUsContext : DbContext
    {
        public ShopsRUsContext(DbContextOptions<ShopsRUsContext> options)
           : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Invoice>().HasIndex(u => u.InvoiceNo).IsUnique();
        }
    }
}
