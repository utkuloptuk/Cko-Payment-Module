// <copyright file="InvoiceService.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.Dtos;

namespace Service
{
    /// <summary>
    /// InvoiceService service layer.
    /// </summary>
    internal sealed class InvoiceService : IInvoiceService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly ILoggerManager loggerManager;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceService"/> class.
        /// </summary>
        /// <param name="repositoryManager">repo imp.</param>
        /// <param name="loggerManager">logger imp.</param>
        /// <param name="mapper">mapper imp.</param>
        public InvoiceService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            this.repositoryManager = repositoryManager;
            this.loggerManager = loggerManager;
            this.mapper = mapper;
        }

        /// <summary>
        /// create invoice.
        /// </summary>
        /// <param name="invoice">input.</param>
        /// <returns>returns 200 or 400.</returns>
        public InvoiceDto CreateInvoice(InvoiceForCreationDto invoice)
        {
            var invoiceEntity = this.mapper.Map<Invoice>(invoice);
            invoiceEntity.CreationDate = DateTime.Now;
            this.repositoryManager.InvoiceRepository.CreateInvoice(invoiceEntity);
            this.repositoryManager.Save();

            var invoiceToReturn = this.mapper.Map<InvoiceDto>(invoiceEntity);
            return invoiceToReturn;
        }
    }
}
