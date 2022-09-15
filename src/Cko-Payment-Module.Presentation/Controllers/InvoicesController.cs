// <copyright file="InvoicesController.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Cko_Payment_Module.Presentation.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Service.Contracts;
    using Shared.Dtos;

    /// <summary>
    /// Invoice presentation layer.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private IServiceManager serviceManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoicesController"/> class.
        /// </summary>
        /// <param name="serviceManager">service manager.</param>
        public InvoicesController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        /// <summary>
        /// create controller.
        /// </summary>
        /// <param name="invoice">input.</param>
        /// <returns>statuscode 200 or 400.</returns>
        [HttpPost]
        public IActionResult CreateInvoice([FromBody] InvoiceForCreationDto invoice)
        {
            if (invoice is null)
            {
                return this.BadRequest("invoiceForCreationDto object is null.");
            }

            var createdInvoice = this.serviceManager.InvoiceService.CreateInvoice(invoice);

            return this.Ok($"Invoice id: {createdInvoice.Id}");
        }
    }
}
