// <copyright file="CustomerDto.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

using Entities.Enums;

namespace Shared.Dtos
{
    public record CustomerDto(Guid id, string name, string lastName, string telNo, string email, string address, UserType userType,DateTime creationDate);
}