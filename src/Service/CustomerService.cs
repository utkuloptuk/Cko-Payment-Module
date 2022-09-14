// <copyright file="CustomerService.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Service
{
    using AutoMapper;
    using global::Contracts;
    using Service.Contracts;
    using Shared.Dtos;

    /// <summary>
    /// customer service.
    /// </summary>
    internal sealed class CustomerService : ICustomerService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly ILoggerManager loggerManager;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerService"/> class.
        /// </summary>
        /// <param name="repositoryManager">repository manager.</param>
        /// <param name="loggerManager">logger manager.</param>
        /// <param name="mapper">mapper.</param>
        public CustomerService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            this.repositoryManager = repositoryManager;
            this.loggerManager = loggerManager;
            this.mapper = mapper;
        }

        /// <summary>
        /// service layer getallcustomers.
        /// </summary>
        /// <param name="trackChanges">asnotracking control.</param>
        /// <returns>customer.</returns>
        public IEnumerable<CustomerDto> GetAllCustomers(bool trackChanges)
        {
            var customers = this.repositoryManager.CustomerRepository.GetAllCustomers(trackChanges);
            var customersDto = this.mapper.Map<IEnumerable<CustomerDto>>(customers);
            return customersDto;
        }
    }
}
