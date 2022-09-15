// <copyright file="IRepositoryManager.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Contracts
{
    /// <summary>
    /// RepositoryManager interface.
    /// </summary>
    public interface IRepositoryManager
    {
        /// <summary>
        /// gets customer repo.
        /// </summary>
        ICustomerRepository CustomerRepository { get; }

        /// <summary>
        /// Gets product repo.
        /// </summary>
        IProductRepository ProductRepository { get; }

        /// <summary>
        /// gets.
        /// </summary>
        IInvoiceRepository InvoiceRepository { get; }

        /// <summary>
        /// gets.
        /// </summary>
        IInvoiceDetailRepository InvoiceDetailRepository { get; }

        /// <summary>
        /// save.
        /// </summary>
        void Save();
    }
}
