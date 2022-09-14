// <copyright file="Product.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Entities.Models
{
    using Entities.Enums;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    /// <summary>
    /// Product table.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        [Column("ProductId")]
        public Guid Id { get; set; }

        /// <summary>
        /// gets or sets productName.
        /// </summary>
        [Required(ErrorMessage = $"{nameof(Product)} {nameof(Name)} can not be null.")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Name { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        /// <summary>
        /// gets or sets Price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// gets or sets Quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// gets or sets ProductType.
        /// </summary>
        public ProductType ProductType { get; set; }

        /// <summary>
        /// gets or sets update time.
        /// </summary>
        public DateTime UpdatedTime { get; set; }

        /// <summary>
        /// gets or sets Invoicedetails table.
        /// </summary>
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
