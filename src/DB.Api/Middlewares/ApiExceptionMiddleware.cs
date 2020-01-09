using Microsoft.AspNetCore.Http;
using OCCBPackage.Mvc;
using System;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;

namespace DB.Api.Middlewares
{
    internal class ApiExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public ApiExceptionMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleApiExceptionAsync(context, ex);
            }
        }

        private Task HandleApiExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = exception switch
            {
                TimeoutException _ => StatusCodes.Status504GatewayTimeout,
                NotImplementedException _ => StatusCodes.Status501NotImplemented,
                _ => StatusCodes.Status500InternalServerError,
            };
            context.Response.ContentType = MediaTypeNames.Application.Json;
            var response = JsonSerializer.Serialize(new ApiProblemDetails(context, exception), _jsonSerializerOptions);

            return context.Response.WriteAsync(response);
        }
    }
}
