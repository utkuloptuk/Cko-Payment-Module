// <copyright file="ExceptionMiddlewareExtensions.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Cko_Payment_Module.Extensions
{
    using System.Net;
    using Contracts;
    using Entities.ErrorModel;
    using Entities.Exceptions;
    using Microsoft.AspNetCore.Diagnostics;

    /// <summary>
    /// exception middleware imp.
    /// </summary>
    public static class ExceptionMiddlewareExtensions
    {
        /// <summary>
        /// exception handler class.
        /// </summary>
        /// <param name="app">webapplication.</param>
        /// <param name="loggerManager">logger.</param>
        public static void ConfigureExceptionHandler(this WebApplication app, ILoggerManager loggerManager)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError,
                        };

                        loggerManager.LogError($"Something went wrong:{contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                        }.ToString());
                    }
                });
            });
        }
    }
}
