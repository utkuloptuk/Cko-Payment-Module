// <copyright file="ProductRepository.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Repository
{
    using Contracts;
    using Entities.Models;

    ///<inheritdoc/>
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

        ///<inheritdoc/>
        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return this.FindAll(trackChanges).OrderBy(c => c.Id).ToList();
        }
    }
}
