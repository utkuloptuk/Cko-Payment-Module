// <copyright file="IInvoiceService.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Service.Contracts
{
    using Shared.Dtos;

    /// <summary>
    /// service layer interface.
    /// </summary>
    public interface IInvoiceService
    {
        /// <summary>
        /// create Invoice.
        /// </summary>
        /// <param name="invoice">input.</param>
        /// <returns>InvoiceDto.</returns>
        InvoiceDto CreateInvoice(InvoiceForCreationDto invoice);
    }
}
