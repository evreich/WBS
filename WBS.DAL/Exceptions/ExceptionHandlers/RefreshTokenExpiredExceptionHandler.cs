using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Exceptions.ExceptionHandlers
{
    public class RefreshTokenExpiredExceptionHandler: AbstractExceptionHandler
    {
        public RefreshTokenExpiredExceptionHandler(ILoggerFactory loggingFactory) :
            base(loggingFactory, typeof(RefreshTokenExpiredException), StatusCodes.Status401Unauthorized)
        { }

        public override string GetJSONResponse(Exception exception)
        {
            if (exception.GetType() != ExceptionType)
            {
                throw new ArgumentException("Type of exception not equal errorHandler type.");
            }
            _logger.LogWarning(exception, exception.Message);
            return base.GetJSONResponse(exception);
        }
    }
}
