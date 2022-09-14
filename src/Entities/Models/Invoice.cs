// <copyright file="Invoice.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Entities.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Invoice table.
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// gets or sets Invoice id.
        /// </summary>
        [Column("InvoiceId")]
        public Guid Id { get; set; }

        /// <summary>
        /// gets or sets CustomerId.
        /// </summary>
        [Required(ErrorMessage = $"{nameof(Invoice)} {nameof(CustomerId)} can not be null.")]
        public Guid CustomerId;

        /// <summary>
        /// Gets or sets customer table.
        /// </summary>
        public virtual Customer Customers { get; set; }

        /// <summary>
        /// gets or sets GrossPrice.
        /// </summary>
        [Required(ErrorMessage = $"{nameof(Invoice)} {nameof(GrossPrice)} can not be null.")]
        public decimal GrossPrice { get; set; }

        /// <summary>
        /// gets or sets NetPrice.
        /// </summary>
        [Required(ErrorMessage = $"{nameof(Invoice)} {nameof(NetPrice)} can not be null.")]
        public decimal NetPrice { get; set; }

        /// <summary>
        /// gets or sets creationDate.
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// gets or sets InvoiceDetails table.
        /// </summary>
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
