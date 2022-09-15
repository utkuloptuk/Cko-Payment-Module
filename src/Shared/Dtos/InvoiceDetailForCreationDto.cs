// <copyright file="InvoiceDetailForCreationDto.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Shared.Dtos
{
    public record InvoiceDetailForCreationDto(Guid invoiceId, Guid productId, int quantity);
}
