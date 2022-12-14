// <copyright file="ProductService.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Service
{
    using AutoMapper;
    using Entities.Exceptions;
    using global::Contracts;
    using Service.Contracts;
    using Shared.Dtos;

    /// <summary>
    /// product service.
    /// </summary>
    internal sealed class ProductService : IProductService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly ILoggerManager loggerManager;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="repositoryManager">repository manager.</param>
        /// <param name="loggerManager">logger manager.</param>
        /// <param name="mapper">mapper.</param>
        public ProductService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            this.repositoryManager = repositoryManager;
            this.loggerManager = loggerManager;
            this.mapper = mapper;
        }

        /// <summary>
        /// service layer getallproducts.
        /// </summary>
        /// <param name="trackChanges">asnotracking control.</param>
        /// <returns>product.</returns>
        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(bool trackChanges)
        {
            var products = await this.repositoryManager.ProductRepository.GetAllProductsAsync(trackChanges);
            var productDto = this.mapper.Map<IEnumerable<ProductDto>>(products);
            return productDto;
        }

        /// <summary>
        /// service layer bulkgetproducts.
        /// </summary>
        /// <param name="bulkData">condition.</param>
        /// <param name="trackChanges">asnotracking control.</param>
        /// <returns>Ienum productDto.</returns>
        public async Task<IEnumerable<ProductDto>> BulkGetProductsAsync(IEnumerable<PaymentProcessProductDto> bulkData, bool trackChanges)
        {
            var bulkDataNames = this.mapper.Map<ProductForBulkGetDto>(bulkData);
            var products = await this.repositoryManager.ProductRepository.BulkGetProductsByNameAsync(bulkDataNames.names, trackChanges);
            var productsDto = this.mapper.Map<IEnumerable<ProductDto>>(products);
            return productsDto;
        }

        /// <summary>
        /// getbyid service layer.
        /// </summary>
        /// <param name="id">condition.</param>
        /// <param name="trackChanges">asnotracking control.</param>
        /// <returns>productDto.</returns>
        public async Task<ProductDto> GetProductAsync(Guid id, bool trackChanges)
        {
            var product = await this.repositoryManager.ProductRepository.GetByIdAsync(id, trackChanges);
            if (product is null)
            {
                throw new ProductNotFoundException(id);
            }

            var productDto = this.mapper.Map<ProductDto>(product);
            return productDto;
        }
    }
}
