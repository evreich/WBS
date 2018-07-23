using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WBS.API.Services;

namespace WBS.API.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;
        private readonly ErrorsHandlerService _errorsHandlerService;

        public ErrorHandlerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, ErrorsHandlerService errorsHandlerService)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = loggerFactory?.CreateLogger<ErrorHandlerMiddleware>() ?? throw new ArgumentNullException(nameof(loggerFactory));
            _errorsHandlerService = errorsHandlerService;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);         
            }
            catch (Exception ex)
            {
                if (context.Response.HasStarted)
                {
                    var error = "The response has already started, the http status code middleware will not be executed.";
                    _logger.LogWarning(error);
                    throw new Exception(error);
                }

                var errorInfo = _errorsHandlerService.GetResultOfErrorHandling(ex);

                context.Response.Body.SetLength(0);
                context.Response.StatusCode = errorInfo.statusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(errorInfo.JSONErrors);
            }
        }
    }
}
