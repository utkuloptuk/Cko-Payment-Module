// <copyright file="MappingProfile.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Cko_Payment_Module
{
    using AutoMapper;
    using Entities.Models;
    using Shared.Dtos;

    /// <summary>
    /// mapper.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            this.CreateMap<Customer, CustomerDto>()
                .ForCtorParam("email", opt => opt.MapFrom(x => string.IsNullOrEmpty(x.Email) ? "Not registered." : x.Email))
                .ForCtorParam("telNo", opt => opt.MapFrom(x => string.IsNullOrEmpty(x.TelephoneNumber) ? "Not registered." : x.TelephoneNumber));
        }
    }
}
