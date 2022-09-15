// <copyright file="NotFoundException.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Entities.Exceptions
{
    /// <summary>
    /// not found exception.
    /// </summary>
    public abstract class NotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class.
        /// </summary>
        /// <param name="message">input.</param>
        protected NotFoundException(string message)
            : base(message)
        {
        }
    }
}
