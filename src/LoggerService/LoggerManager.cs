// <copyright file="LoggerManager.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace LoggerService
{
    using Contracts;
    using NLog;

    /// <summary>
    /// Logger manager service.
    /// </summary>
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Debug log service.
        /// </summary>
        /// <param name="message">Take message value.</param>
        public void LogDebug(string message) => logger.Debug(message);

        /// <summary>
        /// Error log service.
        /// </summary>
        /// <param name="message">Take message value.</param>
        public void LogError(string message) => logger.Error(message);

        /// <summary>
        /// Info log service.
        /// </summary>
        /// <param name="message">Take message value.</param>
        public void LogInfo(string message) => logger.Info(message);

        /// <summary>
        /// Warning log service.
        /// </summary>
        /// <param name="message">Take message value.</param>
        public void LogWarning(string message) => logger.Warn(message);
    }
}
