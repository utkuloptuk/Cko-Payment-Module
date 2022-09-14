// <copyright file="InvoiceDetail.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Entities.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Invoice detail table.
    /// </summary>
    public class InvoiceDetail
    {
        /// <summary>
        /// gets or sets.
        /// </summary>
        [Key]
        [Column("InvoiceDetailId")]
        public Guid Id { get; set; }

        ///// <summary>
        ///// Gets or sets invoiceId.
        ///// </summary>
        public Guid InvoiceId;

        /// <summary>
        /// gets or sets Invoice table.
        /// </summary>
        public virtual Invoice Invoices { get; set; }

        ///// <summary>
        ///// gets or sets ProductId.
        ///// </summary>
        public Guid ProductId;

        /// <summary>
        /// gets or sets Products table.
        /// </summary>
        public virtual Product Products { get; set; }

        /// <summary>
        /// gets or sets Quantity.
        /// </summary>
        public int Quantity { get; set; }
    }
}
