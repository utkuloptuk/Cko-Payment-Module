// <copyright file="CustomersController.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Cko_Payment_Module.Presentation.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Service.Contracts;

    /// <summary>
    /// Customers controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersController"/> class.
        /// </summary>
        /// <param name="serviceManager">service manager imp.</param>
        public CustomersController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        /// <summary>
        /// presentation layer getcustomers.
        /// </summary>
        /// <returns>Ok or Error message.</returns>
        [HttpGet]
        public IActionResult GetCustomers()
        {
            try
            {
                var customers = this.serviceManager.CustomerService.GetAllCustomers(trackChanges: false);
                return this.Ok(customers);
            }
            catch
            {
                return this.StatusCode(500, "Internal server error.");
            }
        }
    }
}
