// <copyright file="LoggerExtensions.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Cko_Payment_Module.Extensions
{
    using Contracts;
    using LoggerService;

    /// <summary>
    /// Logger extension.
    /// </summary>
    public static class LoggerExtensions
    {
        /// <summary>
        /// Log service configuration.
        /// </summary>
        /// <param name="services">IService value.</param>
        public static void ConfigureLogs(this IServiceCollection services) => services.AddSingleton<ILoggerManager, LoggerManager>();
    }
}
