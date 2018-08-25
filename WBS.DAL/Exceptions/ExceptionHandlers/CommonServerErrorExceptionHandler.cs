using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace WBS.DAL.Exceptions.ExceptionHandlers
{
    public class CommonServerErrorExceptionHandler: AbstractExceptionHandler
    {
        public CommonServerErrorExceptionHandler(ILoggerFactory loggingFactory) : 
            base(loggingFactory, typeof(Exception), StatusCodes.Status500InternalServerError) { }

        public override string GetJSONResponse(Exception exception)
        {
            _logger.LogError(exception, exception.Message);
            //возможно, требуется возвращать текст ошибки
            //на текущий момент, возвращается текст для пользователя на клиенте
            return JsonConvert.SerializeObject( new { error = "Возникла серверная ошибка! Обратитесь в тех поддержку." });
        }
    }
}