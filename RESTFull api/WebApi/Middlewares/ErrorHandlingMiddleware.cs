using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Application;
using Aplication;
using Microsoft.Extensions.Logging;

namespace WebApi
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
               await _next(context);
            }
            catch(Exception exception)
            {
                var statusCode = HttpStatusCode.InternalServerError;

                if (exception is ApiException)
                    statusCode = (exception as ApiException).StatusCode;

                context.Response.StatusCode = (int)statusCode;
                var jsonResponse = new object();

                if (exception is ValidationException)
                {
                    var validationException = exception as ValidationException;
                    jsonResponse = new { 
                        Message = exception.Message, 
                        Errors = validationException.Failures
                    };
                }
                else
                  jsonResponse = new { Message = exception.Message };

                _logger.LogError(exception, exception.Message);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(jsonResponse));
            }
        }
    }
}