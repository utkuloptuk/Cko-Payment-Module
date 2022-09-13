// <copyright file="CustomersConfiguration.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Repository.Configuration
{
    using Entities.Enums;
    using Entities.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Created base customers.
    /// </summary>
    public class CustomersConfiguration : IEntityTypeConfiguration<Customer>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer
                {
                    Id = new Guid("953a2bdc-7aab-46fa-9364-8858424ca7db"),
                    Name = "newbie",
                    LastName = "lastname1",
                    Address = "new address1",
                    Age = 25,
                    CreationDate = DateTime.Now,
                    Email = "email@example.com",
                    TelephoneNumber = "111111111",
                    UserType = UserType.Common,
                },
                new Customer
                {
                    Id = new Guid("5314362a-5f87-4b38-9a88-1174d5999cc5"),
                    Name = "employee",
                    LastName = "lastname1",
                    Address = "new address1",
                    Age = 25,
                    CreationDate = DateTime.Now,
                    Email = "email2@example.com",
                    TelephoneNumber = "22222222",
                    UserType = UserType.Employee,
                },
                new Customer
                {
                    Id = new Guid("f6db198c-8780-4687-b5f6-9aa2530c65eb"),
                    Name = "affiliate",
                    LastName = "lastname1",
                    Address = "new address1",
                    Age = 25,
                    CreationDate = DateTime.Now,
                    Email = "email3@example.com",
                    TelephoneNumber = "33333333",
                    UserType = UserType.Affiliate,
                },
                new Customer
                {
                    Id = new Guid("0d23ac2f-3a5d-466d-8cc6-f8f3dab296c7"),
                    Name = "veteran",
                    LastName = "lastname1",
                    Address = "new address1",
                    Age = 25,
                    CreationDate = DateTime.Now.AddYears(-2),
                    Email = "email4@example.com",
                    TelephoneNumber = "33333333",
                    UserType = UserType.Common,
                });
        }
    }
}
