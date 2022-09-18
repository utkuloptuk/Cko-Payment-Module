// <copyright file="ProductsController.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Cko_Payment_Module.Presentation.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Service.Contracts;
    using Shared.Dtos;

    /// <summary>
    /// products controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        /// <param name="serviceManager">servicemanager imp.</param>
        public ProductsController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        /// <summary>
        /// presentation layer product.
        /// </summary>
        /// <returns>Status code 200 or 500.</returns>
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await this.serviceManager.ProductService.GetAllProductsAsync(trackChanges: false);
            return this.Ok(products);
        }

        /// <summary>
        /// getProduct presentation layer.
        /// </summary>
        /// <param name="id">condition.</param>
        /// <returns>status code 200 or 404.</returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProductAsync(Guid id)
        {
            var product = await this.serviceManager.ProductService.GetProductAsync(id, trackChanges: false);
            return this.Ok(product);
        }
    }
}
