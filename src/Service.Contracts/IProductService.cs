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
        /// get all products.
        /// </summary>
        /// <param name="trackChanges">asnotracking control.</param>
        /// <returns>customers data.</returns>
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(bool trackChanges);

        /// <summary>
        /// get product.
        /// </summary>
        /// <param name="id">condition.</param>
        /// <param name="trackChanges">asnottracking control.</param>
        /// <returns>productdto.</returns>
        Task<ProductDto> GetProductAsync(Guid id, bool trackChanges);

        /// <summary>
        /// get bulk products.
        /// </summary>
        /// <param name="bulkData">condition.</param>
        /// <param name="trackChanges">asnotracking.</param>
        /// <returns>IEnum productDto.</returns>
        Task<IEnumerable<ProductDto>> BulkGetProductsAsync(IEnumerable<PaymentProcessProductDto> bulkData, bool trackChanges);
    }
}
