// <copyright file="InvoiceForCreationDto.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Shared.Dtos
{
    public record InvoiceForCreationDto(Guid customerId, decimal grossPrice, decimal netPrice);
}
