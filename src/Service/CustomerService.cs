// <copyright file="CustomerService.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Service
{
    using global::Contracts;
    using Service.Contracts;

    /// <summary>
    /// customer service.
    /// </summary>
    internal sealed class CustomerService : ICustomerService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly ILoggerManager loggerManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerService"/> class.
        /// </summary>
        /// <param name="repositoryManager">repository manager.</param>
        /// <param name="loggerManager">logger manager.</param>
        public CustomerService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            this.repositoryManager = repositoryManager;
            this.loggerManager = loggerManager;
        }
    }
}
