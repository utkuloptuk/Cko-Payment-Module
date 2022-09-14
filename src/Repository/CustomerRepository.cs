// <copyright file="CustomerRepository.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Repository
{
    using Contracts;
    using Entities.Models;

    /// <inheritdoc/>
    internal sealed class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">repo context.</param>
        public CustomerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        /// <inheritdoc/>
        public IEnumerable<Customer> GetAllCustomers(bool trackChanges)
        {
            return this.FindAll(trackChanges).OrderBy(c => c.Id).ToList();
        }
    }
}
