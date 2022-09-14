// <copyright file="RepositoryContextModelCreating.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Repository
{
    using Entities.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// db relation definations.
    /// </summary>
    public static class RepositoryContextModelCreating
    {
        /// <summary>
        /// Db relations.
        /// </summary>
        /// <param name="builder">builder.</param>
        public static void ConfigureDbContext(this ModelBuilder builder)
        {
            builder.Entity<Invoice>(b =>
            {
                b.ToTable("Invoices")
                .HasOne(p => p.Customers)
                .WithMany(c => c.Invoices)
                .HasForeignKey(x => x.CustomerId);
                b.Property(c => c.NetPrice).HasPrecision(10, 10);
                b.Property(c => c.GrossPrice).HasPrecision(10, 10);
            });
            builder.Entity<InvoiceDetail>(i =>
            {
                i.ToTable("InvoiceDetails")
                .HasOne(c => c.Invoices)
                .WithMany(d => d.InvoiceDetails)
                .HasForeignKey(c => c.InvoiceId);

                i.ToTable("InvoiceDetails")
                .HasOne(c => c.Products)
                .WithMany(d => d.InvoiceDetails)
                .HasForeignKey(c => c.ProductId);
            });
            builder.Entity<Product>(p =>
            {
                p.Property(q => q.Price).HasPrecision(5);
            });
        }
    }
}
