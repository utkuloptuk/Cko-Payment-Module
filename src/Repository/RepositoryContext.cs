﻿// <copyright file="RepositoryContext.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Repository
{
    using Entities.Models;
    using Microsoft.EntityFrameworkCore;
    using Repository.Configuration;

    /// <inheritdoc/>
    public class RepositoryContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryContext"/> class.
        /// </summary>
        /// <param name="options">db options.</param>
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        /// <summary>
        /// Inserted base datas in db.
        /// </summary>
        /// <param name="modelBuilder">modelbuilder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomersConfiguration());
            modelBuilder.ApplyConfiguration(new ProductsConfiguration());
            modelBuilder.ConfigureDbContext();
        }

        /// <summary>
        /// Gets or sets customer table implementation.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// gets or sets Invoices table implementation.
        /// </summary>
        public DbSet<Invoice> Invoices { get; set; }

        /// <summary>
        /// gets or sets ınvoiceDetail table implementation.
        /// </summary>
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        /// <summary>
        /// gets or sets product table implementation.
        /// </summary>
        public DbSet<Product> Products { get; set; }
    }
}
