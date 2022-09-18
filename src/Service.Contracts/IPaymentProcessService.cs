// <copyright file="IPaymentProcessService.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Service.Contracts
{
    using Shared.Dtos;

    /// <summary>
    /// paymentprocess service layer.
    /// </summary>
    public interface IPaymentProcessService
    {
        /// <summary>
        /// create payment.
        /// </summary>
        /// <param name="paymentProcessDto">input.</param>
        /// <returns>Invoice result.</returns>
        Task<InvoiceDto> CreatePayment(PaymentProcessDto paymentProcessDto);
    }
}
