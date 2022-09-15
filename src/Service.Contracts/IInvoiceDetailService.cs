// <copyright file="IInvoiceDetailService.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Service.Contracts
{
    using Shared.Dtos;

    /// <summary>
    /// IInvoiceDetail interface.
    /// </summary>
    public interface IInvoiceDetailService
    {
        /// <summary>
        /// service layer invoice detail.
        /// </summary>
        /// <param name="invoiceDetail">input.</param>
        /// <returns>invoicedetaildto.</returns>
        InvoiceDetailDto CreateInvoiceDetail(InvoiceDetailForCreationDto invoiceDetail);
    }
}
