using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WBS.DAL.Exceptions.ExceptionHandlers
{
    public abstract class AbstractExceptionHandler
    {
        protected readonly ILogger _logger;
        public Type ExceptionType { get; }
        public int StatusCode { get; }

        public AbstractExceptionHandler(ILoggerFactory loggerFactory, Type exceptionType, int statusCode)
        {
            _logger = loggerFactory?.CreateLogger(GetType().Namespace) ?? throw new ArgumentNullException(nameof(loggerFactory));
            ExceptionType = exceptionType;
            StatusCode = statusCode;
        }  

        public virtual string GetJSONResponse(Exception _exception)
        {
            if (_exception.GetType() != ExceptionType)
                throw new ArgumentException("Type of exception not equal errorHandler type.");
            return JsonConvert.SerializeObject(new { error = _exception.Message });
        }
    }
}
