// <copyright file="InvoiceDetailDto.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Shared.Dtos
{
public record InvoiceDetailDto(Guid invoiceId, Guid productId, int quantity);
}
