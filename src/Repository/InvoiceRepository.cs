// <copyright file="InvoiceRepository.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Repository
{
    using Contracts;
    using Entities.Models;

    /// <summary>
    /// invoiceRepo class.
    /// </summary>
    internal sealed class InvoiceRepository : RepositoryBase<Invoice>, IInvoiceRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">context.</param>
        public InvoiceRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        /// <summary>
        /// createInvoice repo.
        /// </summary>
        /// <param name="invoice">input.</param>
        public void CreateInvoice(Invoice invoice)
        {
            this.Create(invoice);
        }
    }
}
