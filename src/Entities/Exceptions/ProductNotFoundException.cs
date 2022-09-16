// <copyright file="ProductNotFoundException.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Entities.Exceptions
{
    public sealed class ProductNotFoundException : NotFoundException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductNotFoundException"/> class.
        /// </summary>
        /// <param name="productId">input.</param>
        public ProductNotFoundException(Guid productId)
            : base($"The product with id: {productId} doesn't exist in the database.")
        {
        }
    }
}
