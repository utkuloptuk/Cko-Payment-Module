// <copyright file="IInvoiceDetailRepository.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Contracts
{
    using Entities.Models;

    /// <summary>
    /// invoicedetail repo ınterface.
    /// </summary>
    public interface IInvoiceDetailRepository
    {
        /// <summary>
        /// create interface.
        /// </summary>
        /// <param name="invoiceDetail">input.</param>
        void CreateInvoiceDetail(InvoiceDetail invoiceDetail);
    }
}
