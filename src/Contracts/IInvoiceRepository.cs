// <copyright file="IInvoiceRepository.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>


namespace Contracts
{
    using Entities.Models;

    /// <summary>
    /// invoice repo interface.
    /// </summary>
    public interface IInvoiceRepository
    {
        /// <summary>
        /// create invoice.
        /// </summary>
        /// <param name="invoice">input.</param>
        void CreateInvoice(Invoice invoice);
    }
}
