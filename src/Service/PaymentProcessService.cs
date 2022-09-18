// <copyright file="PaymentProcessService.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Service
{
    using AutoMapper;
    using Cko_Payment_Module.Presentation.Helpers;
    using Entities.Models;
    using global::Contracts;
    using Service.Contracts;
    using Shared.Dtos;

    /// <summary>
    /// Payment service layer.
    /// </summary>
    public sealed class PaymentProcessService : IPaymentProcessService
    {
        private readonly IServiceManager serviceManager;
        private readonly PriceCalculationService calculator;
        private readonly ILoggerManager loggerManager;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentProcessService"/> class.
        /// </summary>
        /// <param name="loggerManager">logger imp.</param>
        /// <param name="mapper">mapper imp.</param>
        /// <param name="serviceManager">service manager imp.</param>
        public PaymentProcessService(ILoggerManager loggerManager, IMapper mapper, IServiceManager serviceManager)
        {
            this.mapper = mapper;
            this.loggerManager = loggerManager;
            this.serviceManager = serviceManager;
            this.calculator = new PriceCalculationService();
        }

        /// <summary>
        /// Create payment.
        /// </summary>
        /// <param name="paymentProcessDto">input.</param>
        /// <returns>invoice.</returns>
        public async Task<InvoiceDto> CreatePayment(PaymentProcessDto paymentProcessDto)
        {
            var products = await this.serviceManager.ProductService.BulkGetProductsAsync(paymentProcessDto.products, trackChanges: false);
            var prices = this.calculator.PriceCalculate(paymentProcessDto.customer, products, paymentProcessDto.products);
            Invoice invoice = new Invoice()
            {
                CustomerId = paymentProcessDto.customer.id,
                GrossPrice = prices.GrossPrice,
                NetPrice = prices.NetPrice,
            };
            var invoiceCreationDto = this.mapper.Map<InvoiceForCreationDto>(invoice);

            var newInvoice = this.serviceManager.InvoiceService.CreateInvoice(invoiceCreationDto);

            foreach (var product in products)
            {
                InvoiceDetail invoiceDetail = new InvoiceDetail()
                {
                    InvoiceId = newInvoice.Id,
                    ProductId = product.id,
                    Quantity = paymentProcessDto.products.First(x => x.name.Equals(product.name)).quantity,
                };
                var invoiceDetailDto = this.mapper.Map<InvoiceDetailForCreationDto>(invoiceDetail);
                this.serviceManager.InvoiceDetailService.CreateInvoiceDetail(invoiceDetailDto);
            }

            return newInvoice;
        }
    }
}
