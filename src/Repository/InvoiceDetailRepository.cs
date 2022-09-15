// <copyright file="InvoiceDetailRepository.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Repository
{
    using Contracts;
    using Entities.Models;

    /// <summary>
    /// invoice detail repo.
    /// </summary>
    internal sealed class InvoiceDetailRepository : RepositoryBase<InvoiceDetail>, IInvoiceDetailRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceDetailRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">input.</param>
        public InvoiceDetailRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        /// <summary>
        /// create mothod.
        /// </summary>
        /// <param name="invoiceDetail">input.</param>
        public void CreateInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            this.Create(invoiceDetail);
        }
    }
}
