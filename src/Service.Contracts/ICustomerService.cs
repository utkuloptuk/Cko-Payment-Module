// <copyright file="ICustomerService.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Service.Contracts
{
    using Shared.Dtos;

    /// <summary>
    /// customer service layer interface.
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// get all customers.
        /// </summary>
        /// <param name="trackChanges">asnotracking control.</param>
        /// <returns>customers data.</returns>
        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync(bool trackChanges);
    }
}
