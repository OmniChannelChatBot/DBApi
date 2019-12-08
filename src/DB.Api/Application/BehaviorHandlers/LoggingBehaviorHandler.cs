﻿using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Api.Application.BehaviorHandlers
{
    public class LoggingBehaviorHandler<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<IPipelineBehavior<TRequest, TResponse>> _logger;

        public LoggingBehaviorHandler(ILogger<IPipelineBehavior<TRequest, TResponse>> logger) =>
            _logger = logger;

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                _logger.LogInformation("Операция {RequestName}: {@Request}", typeof(TRequest).Name, request);
                var response = await next();
                _logger.LogInformation("Операция {ResponseName} выполнена успешно. Результат: {@Response}", typeof(TResponse).Name, response);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при выполнении операции {RequestName}", typeof(TRequest).Name);
                throw;
            }
        }
    }
}
