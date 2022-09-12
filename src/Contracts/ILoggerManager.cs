// <copyright file="ILoggerManager.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Contracts
{
    /// <summary>
    /// Interface to logger.
    /// </summary>
    public interface ILoggerManager
    {
        /// <summary>
        /// Info log interface.
        /// </summary>
        /// <param name="message">Info log message value.</param>
        void LogInfo(string message);

        /// <summary>
        /// Warning log interface.
        /// </summary>
        /// <param name="message">Warning log message value.</param>
        void LogWarning(string message);

        /// <summary>
        /// Debug log interface.
        /// </summary>
        /// <param name="message">Debug log message value.</param>
        void LogDebug(string message);

        /// <summary>
        /// Error log interface.
        /// </summary>
        /// <param name="message">Error log message value.</param>
        void LogError(string message);
    }
}
