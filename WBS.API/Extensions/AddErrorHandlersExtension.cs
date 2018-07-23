using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBS.DAL.Exceptions;
using WBS.DAL.Exceptions.ExceptionHandlers;
using WBS.API.Services;

namespace WBS.API.Extensions
{
    static class AddErrorHandlersExtension
    {
        public static void AddErrorHandlers(this IServiceCollection services)
        {
            services.AddSingleton<AbstractExceptionHandler, UserNotFoundExceptionHandler>(ctx =>
            {
                var logger = ctx.GetService<ILoggerFactory>();
                return new UserNotFoundExceptionHandler(logger);
            });
            services.AddSingleton<AbstractExceptionHandler, RefreshTokenExpiredExceptionHandler>(ctx =>
            {
                var logger = ctx.GetService<ILoggerFactory>();
                return new RefreshTokenExpiredExceptionHandler(logger);
            });

            //add new error handlers...

            services.AddSingleton<CommonServerErrorExceptionHandler>(ctx =>
            {
                var logger = ctx.GetService<ILoggerFactory>();
                return new CommonServerErrorExceptionHandler(logger);
            });
            services.AddSingleton<ErrorsHandlerService>(ctx =>
            {
                var logger = ctx.GetService<ILoggerFactory>();
                var errorsHandlers = ctx.GetServices<AbstractExceptionHandler>();
                var commonErrorHandler = ctx.GetService<CommonServerErrorExceptionHandler>();
                return new ErrorsHandlerService(errorsHandlers, logger, commonErrorHandler);
            });
        }
    }
}
