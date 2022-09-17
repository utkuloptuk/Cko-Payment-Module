// <copyright file="ProductDto.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

using Entities.Enums;

namespace Shared.Dtos
{
    public record ProductDto(Guid id, string name, decimal price,ProductType productType);
}
