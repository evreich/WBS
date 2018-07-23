using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBS.DAL.Exceptions.ExceptionHandlers;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using WBS.API.Helpers;

namespace WBS.API.Services
{
    public class ErrorsHandlerService
    {
        private readonly IEnumerable<AbstractExceptionHandler> _errorHandlers;
        private readonly CommonServerErrorExceptionHandler _commonServerErrorHandler;
        private readonly ILogger<ErrorsHandlerService> _logger;

        public ErrorsHandlerService(IEnumerable<AbstractExceptionHandler> errorHandlers, 
            ILoggerFactory loggerFactory, CommonServerErrorExceptionHandler commonServerErrorExceptionHandler)
        {
            _errorHandlers = errorHandlers;
            _commonServerErrorHandler = commonServerErrorExceptionHandler;
            _logger = loggerFactory?.CreateLogger<ErrorsHandlerService>() ?? throw new ArgumentNullException(nameof(loggerFactory));
        }

        public (string JSONErrors, int statusCode) GetResultOfErrorHandling(Exception inputExc)
        {
            try
            {
                var errorHandler = _errorHandlers.SingleOrDefault(handler => handler.ExceptionType == inputExc.GetType());
                return errorHandler == null ?
                    (_commonServerErrorHandler.GetJSONResponse(inputExc), _commonServerErrorHandler.StatusCode) :
                    (errorHandler.GetJSONResponse(inputExc), errorHandler.StatusCode);
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                return (JsonConvert.SerializeObject(new ResponseError("Возникла серверная ошибка! Обратитесь в тех поддержку.")), StatusCodes.Status500InternalServerError);
            }
        }
    }
}
