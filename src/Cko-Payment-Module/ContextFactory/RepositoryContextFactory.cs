// <copyright file="RepositoryContextFactory.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Cko_Payment_Module.ContextFactory
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Repository;

    /// <inheritdoc/>
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        /// <inheritdoc/>
        public RepositoryContext CreateDbContext(string[] args)
        {
            var conf = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlServer(
                    conf.GetConnectionString("SqlConnection"),
                    b => b.MigrationsAssembly("Repository"));
            return new RepositoryContext(builder.Options);
        }
    }
}
