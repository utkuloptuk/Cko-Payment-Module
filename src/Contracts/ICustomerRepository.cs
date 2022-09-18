// <copyright file="ICustomerRepository.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Contracts
{
    using Entities.Models;

    /// <summary>
    /// customer interface.
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// get all customers.
        /// </summary>
        /// <param name="trackChanges">asnotracking control.</param>
        /// <returns>customers.</returns>
        Task<IEnumerable<Customer>> GetAllCustomersAsync(bool trackChanges);
    }
}
