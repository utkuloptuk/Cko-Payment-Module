// <copyright file="ServiceExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Cko_Payment_Module.Extensions
{
    /// <summary>
    /// Service Extension class.
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Cors configuration class.There we can change accessbility.
        /// </summary>
        /// <param name="services">Service.</param>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
        }
    }
}
