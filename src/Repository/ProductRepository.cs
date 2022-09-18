// <copyright file="ProductRepository.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Repository
{
    using System;
    using System.Linq;
    using Contracts;
    using Entities.Models;
    using Microsoft.EntityFrameworkCore;

    /// <inheritdoc/>
    internal sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">repo context.</param>
        public ProductRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges)
        {
            return await this.FindAll(trackChanges).OrderBy(c => c.Id).ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Product> GetByIdAsync(Guid productId, bool trackChanges)
        {
            return await this.FindByCondition(x => x.Id.Equals(productId), trackChanges).SingleOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Product>> BulkGetProductsByNameAsync(IEnumerable<string> names, bool trackChanges)
        {
            return await this.FindByCondition(x => names.Contains(x.Name), trackChanges).ToListAsync();
        }
    }
}
