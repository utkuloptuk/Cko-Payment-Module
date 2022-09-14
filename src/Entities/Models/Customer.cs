// <copyright file="Customer.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Entities.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Entities.Enums;

    /// <summary>
    /// Customer table.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Gets or sets customer Id column.
        /// </summary>
        [Column("CustomerId")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets customer name column.
        /// </summary>
        [Required(ErrorMessage = $"{nameof(Customer)} {nameof(Name)} can not be null.")]
        [MaxLength(30, ErrorMessage = $"{nameof(Customer)} {nameof(Name)} can not be over 30 characters.")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Name { get; set; }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        /// <summary>
        /// Gets or sets customer lastname column.
        /// </summary>
        [Required(ErrorMessage = $"{nameof(Customer)} {nameof(LastName)} can not be null.")]
        [MaxLength(30, ErrorMessage = $"{nameof(Customer)} {nameof(LastName)} can not be over 30 characters.")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string LastName { get; set; }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        /// <summary>
        /// Gets or sets telephone number column.
        /// </summary>
        public string? TelephoneNumber { get; set; }

        /// <summary>
        /// Gets or sets age column.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets email column.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets address column.
        /// </summary>
        [MaxLength(200, ErrorMessage = $"{nameof(Customer)} {nameof(Address)} column can not be over 200 characters.")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Address { get; set; }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        /// <summary>
        /// Gets or sets get or sets User type.Default type could be newbie.
        /// </summary>
        [Required(ErrorMessage = $"{nameof(Customer)} {nameof(UserType)} cannot be null.")]
        public UserType UserType { get; set; }

        /// <summary>
        /// Gets or sets creation date.
        /// </summary>
        [Required(ErrorMessage = $"{nameof(Customer)} {nameof(CreationDate)} can not be null.")]
        public DateTime CreationDate { get; set; }
    }
}
