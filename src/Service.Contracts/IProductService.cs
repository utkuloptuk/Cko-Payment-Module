// <copyright file="IProductService.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Service.Contracts
{
    using Shared.Dtos;

    /// <summary>
    /// product service layer interface.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// get all customers.
        /// </summary>
        /// <param name="trackChanges">asnotracking control.</param>
        /// <returns>customers data.</returns>
        IEnumerable<ProductDto> GetAllProducts(bool trackChanges);
    }
}
