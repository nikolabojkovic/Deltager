using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Application;

namespace WebApi
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
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
                var jsonResponse = new { Message = exception.Message };
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(jsonResponse));
            }
        }
    }
}