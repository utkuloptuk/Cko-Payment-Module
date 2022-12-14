// <copyright file="IServiceManager.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Service.Contracts
{
    /// <summary>
    /// manager interface.
    /// </summary>
    public interface IServiceManager
    {
        /// <summary>
        /// Gets customer service interface.
        /// </summary>
        ICustomerService CustomerService { get; }

        /// <summary>
        /// gets products service interface.
        /// </summary>
        IProductService ProductService { get; }

        /// <summary>
        /// gets invoice service interface.
        /// </summary>
        IInvoiceService InvoiceService { get; }

        /// <summary>
        /// gets invoice detail intterface.
        /// </summary>
        IInvoiceDetailService InvoiceDetailService { get; }
    }
}
