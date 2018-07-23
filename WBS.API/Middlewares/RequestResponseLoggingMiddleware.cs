using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBS.API.Middlewares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly List<string> pathsWithPrivateFields = new List<string> { "/auth/login" };

        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestResponseLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory?.CreateLogger<RequestResponseLoggingMiddleware>() ?? throw new ArgumentException(nameof(loggerFactory));
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            if (pathsWithPrivateFields.IndexOf(request.Path) != 0)
            {
                return $"Request {request.Scheme} {request.Method} {request.Host}{request.Path} {request.QueryString} body dont present, because have private info about user";
            }
            request.EnableRewind();

            request.Body.Seek(0, SeekOrigin.Begin);
            var body = await new StreamReader(request.Body).ReadToEndAsync();
            request.Body.Seek(0, SeekOrigin.Begin);

            return $"Request {request.Scheme} {request.Method} {request.Host}{request.Path} {request.QueryString} {body}";
        }

        private string FormatResponse(MemoryStream responseBodyStream)
        {
            responseBodyStream.Seek(0, SeekOrigin.Begin);
            var text = new StreamReader(responseBodyStream).ReadToEnd();
            responseBodyStream.Seek(0, SeekOrigin.Begin);

            return $"Response {text}";
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation(await FormatRequest(context.Request));

            var bodyStream = context.Response.Body;
            var responseBodyStream = new MemoryStream();
            context.Response.Body = responseBodyStream;

            await _next(context);

            _logger.LogInformation(FormatResponse(responseBodyStream) + Environment.NewLine);
            await responseBodyStream.CopyToAsync(bodyStream);
        }
    }
}
