// <copyright file="ServiceExtensions.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Cko_Payment_Module.Extensions
{
    using Contracts;
    using Repository;

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

        /// <summary>
        /// RepositoryManager configuration class.
        /// </summary>
        /// <param name="services">Service.</param>
        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
    }
}
