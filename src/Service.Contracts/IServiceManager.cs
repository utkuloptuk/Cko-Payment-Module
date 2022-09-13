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
    }
}
