﻿// <copyright file="IProductRepository.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Contracts
{
    using Entities.Models;

    /// <summary>
    /// product interface.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// get all customers.
        /// </summary>
        /// <param name="trackChanges">asnotracking control.</param>
        /// <returns>customers.</returns>
        IEnumerable<Product> GetAllProducts(bool trackChanges);

        /// <summary>
        /// get product by id.
        /// </summary>
        /// <param name="productId">get condition.</param>
        /// <param name="trackChanges">asnotracking.</param>
        /// <returns>Product.</returns>
        Product GetById(Guid productId, bool trackChanges);

        /// <summary>
        /// get products by name.
        /// </summary>
        /// <param name="names">get condition.</param>
        /// <param name="trackChanges">asnotracking control.</param>
        /// <returns>Products.</returns>
        public IEnumerable<Product> BulkGetProductsByName(IEnumerable<string> names, bool trackChanges);
    }
}
