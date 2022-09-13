// <copyright file="ServiceManager.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Service
{
    using global::Contracts;
    using Service.Contracts;

    /// <summary>
    /// servicemanager.
    /// </summary>
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICustomerService> customerService;
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceManager"/> class.
        /// </summary>
        /// <param name="repositoryManager">repomanager.</param>
        /// <param name="logger">logger.</param>
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger)
        {
            this.customerService = new Lazy<ICustomerService>(() => new CustomerService(repositoryManager, logger));
        }

        /// <summary>
        /// Gets customerService.
        /// </summary>
        public ICustomerService CustomerService => this.customerService.Value;
    }
}
