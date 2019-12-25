﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Api.Controllers.Filters
{
    internal class ApiResultFilter : IAsyncResultFilter
    {
        public Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            switch (context.Result)
            {
                case NotFoundObjectResult nfor:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    ResultApiProblemDetails(context, nfor.Value.ToString());

                    return Task.FromCanceled(new CancellationToken(true));

                case BadRequestObjectResult bror:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    ResultApiProblemDetails(context, bror.Value.ToString());

                    return Task.FromCanceled(new CancellationToken(true));

                case NotFoundResult _:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    ResultApiProblemDetails(context);

                    return Task.FromCanceled(new CancellationToken(true));
            }

            return next();
        }

        private void ResultApiProblemDetails(ResultExecutingContext resultExecutingContext, string title = default(string))
        {
            var apiProblemDetails = new ApiProblemDetails(resultExecutingContext.HttpContext, title);
            var objectResult = new ObjectResult(apiProblemDetails)
            {
                StatusCode = resultExecutingContext.HttpContext.Response.StatusCode
            };
            resultExecutingContext.Result = objectResult;
        }
    }
}
