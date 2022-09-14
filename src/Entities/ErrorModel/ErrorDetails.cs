// <copyright file="ErrorDetails.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Entities.ErrorModel
{
    using System.Text.Json;

    /// <summary>
    /// global error handling definitions.
    /// </summary>
    public class ErrorDetails
    {
        /// <summary>
        /// Gets or sets status code area.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// gets or sets.
        /// </summary>
        public string? Message { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
