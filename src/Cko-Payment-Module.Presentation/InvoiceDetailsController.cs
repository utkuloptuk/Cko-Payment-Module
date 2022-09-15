// <copyright file="InvoiceDetailsController.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>


namespace Cko_Payment_Module.Presentation
{
    using Microsoft.AspNetCore.Mvc;
    using Service.Contracts;
    using Shared.Dtos;

    /// <summary>
    /// ınvoice detail presentation layer.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceDetailsController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceDetailsController"/> class.
        /// </summary>
        /// <param name="serviceManager">input.</param>
        public InvoiceDetailsController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        /// <summary>
        /// create invoice detail.
        /// </summary>
        /// <param name="invoiceDetail">input.</param>
        /// <returns>statuscode 200 or 400.</returns>
        [HttpPost]
        public IActionResult CreateInvoiceDetail([FromBody] InvoiceDetailForCreationDto invoiceDetail)
        {
            if (invoiceDetail is null)
            {
                return this.BadRequest($"{nameof(InvoiceDetailForCreationDto)} object is null.");
            }
            var createdInvoiceDetail = this.serviceManager.InvoiceDetailService.CreateInvoiceDetail(invoiceDetail);
            return this.Ok(createdInvoiceDetail);
        }
    }
}
