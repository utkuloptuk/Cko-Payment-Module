// <copyright file="InvoiceDetailService.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Service
{
    using AutoMapper;
    using Entities.Models;
    using global::Contracts;
    using Service.Contracts;
    using Shared.Dtos;

    /// <summary>
    /// service layer invoicedetail.
    /// </summary>
    internal sealed class InvoiceDetailService : IInvoiceDetailService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly ILoggerManager loggerManager;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceDetailService"/> class.
        /// </summary>
        /// <param name="repositoryManager">repo manager.</param>
        /// <param name="loggerManager">log manager.</param>
        /// <param name="mapper">mapper.</param>
        public InvoiceDetailService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            this.repositoryManager = repositoryManager;
            this.loggerManager = loggerManager;
            this.mapper = mapper;
        }

        /// <summary>
        /// service layer create.
        /// </summary>
        /// <param name="invoiceDetail">input.</param>
        /// <returns>invoiceDetailDto.</returns>
        public InvoiceDetailDto CreateInvoiceDetail(InvoiceDetailForCreationDto invoiceDetail)
        {
            var invoiceDetailEntity = this.mapper.Map<InvoiceDetail>(invoiceDetail);
            this.repositoryManager.InvoiceDetailRepository.CreateInvoiceDetail(invoiceDetailEntity);
            this.repositoryManager.Save();
            var invoiceDetailToReturn = this.mapper.Map<InvoiceDetailDto>(invoiceDetailEntity);
            return invoiceDetailToReturn;
        }
    }
}
