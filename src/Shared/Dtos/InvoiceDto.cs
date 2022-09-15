// <copyright file="InvoiceDto.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Shared.Dtos
{
    public record InvoiceDto(Guid Id, Guid CustomerId, decimal GrossPrice, decimal NetPrice);
}
