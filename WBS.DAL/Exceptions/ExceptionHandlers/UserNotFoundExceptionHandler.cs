using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WBS.DAL.Exceptions.ExceptionHandlers
{
    public class UserNotFoundExceptionHandler : AbstractExceptionHandler
    {
        public UserNotFoundExceptionHandler(ILoggerFactory loggerFactory): 
            base(loggerFactory, typeof(UserNotFoundException), StatusCodes.Status401Unauthorized) { }

        public override string GetJSONResponse(Exception exception)
        {
            if (exception.GetType() != ExceptionType)
            {
                throw new ArgumentException("Type of exception not equal errorHandler type.");
            }
            _logger.LogInformation(exception.Message);
            
            return base.GetJSONResponse(exception);
        }
    }
}