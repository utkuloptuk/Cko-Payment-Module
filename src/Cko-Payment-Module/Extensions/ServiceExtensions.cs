// <copyright file="ServiceExtensions.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Cko_Payment_Module.Extensions
{
    using Contracts;
    using Repository;
    using Service;
    using Service.Contracts;

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

        /// <summary>
        /// servicemanager configuration class.
        /// </summary>
        /// <param name="services">service.</param>
        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddTransient<IPaymentProcessService, PaymentProcessService>();
        }

        /// <summary>
        /// sqlcontext configuration class.
        /// </summary>
        /// <param name="services">Service.</param>
        /// <param name="conf">Conf value.</param>
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration conf)
        {
            services.AddSqlServer<RepositoryContext>(conf.GetConnectionString("SqlConnection"));
        }
    }
}
