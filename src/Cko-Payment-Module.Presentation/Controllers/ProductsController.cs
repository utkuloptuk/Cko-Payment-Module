// <copyright file="ProductsController.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Cko_Payment_Module.Presentation.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Service.Contracts;

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
        public IActionResult GetProducts()
        {
            var products = this.serviceManager.ProductService.GetAllProducts(trackChanges: false);
            return this.Ok(products);
        }
    }
}
