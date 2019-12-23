using DB.Api.Controllers.Filters;
using DB.Core.Interfaces;
using DB.Infrastructure.Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DB.Api.Extensions
{
    internal static class ServiceCollectionExtension
    {
        private static readonly string _namespaceApplication = $"{nameof(DB)}.{nameof(Api)}.{nameof(Application)}";

        public static void AddApplicationServices(this IServiceCollection services) => services
            .AddMediatR()
            .AddMediatRHandlers();

        public static IMvcBuilder AddApiServices(this IServiceCollection services) => services
            .AddFluentValidators()
            .AddMvcActionFilters()
            .AddControllers(o => o.Filters.AddService<ApiActionFilter>())
                .AddJsonOptions(o => o.JsonSerializerOptions.IgnoreNullValues = true)
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                    options.SuppressMapClientErrors = true;
                })
                .AddFluentValidation();

        public static void AddDatabaseServices(this IServiceCollection services, string connectionString) => services
            .AddDbContext<ChatBotDbContext>(options => options.UseSqlServer(connectionString))
            .AddScoped<IChatMessageRepository, ChatMessageRepository>()
            .AddScoped<IChatRoomRepository, ChatRoomRepository>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

        public static IServiceCollection AddHealthCheckServices(this IServiceCollection services)
        {
            services.AddHealthChecks();
            services.AddCustomHealthChecks();
            return services;
        }

        private static IServiceCollection AddFluentValidators(this IServiceCollection services) => services
            .Scan(scan =>
            {
                scan
                    .FromAssemblies(typeof(Startup).Assembly)
                    .AddClasses(classes => classes
                        .InNamespaces(_namespaceApplication)
                        .AssignableTo(typeof(IValidator<>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
            });

        private static IServiceCollection AddMediatR(this IServiceCollection services) => services
            .AddScoped<ServiceFactory>(p => t => p.GetService(t))
            .AddScoped<IMediator, Mediator>();

        private static IServiceCollection AddMediatRHandlers(this IServiceCollection services) => services
            .Scan(scan =>
            {
                scan
                    .FromAssemblies(typeof(Startup).Assembly)
                    .AddClasses(classes => classes
                        .InNamespaces(_namespaceApplication)
                        .AssignableTo(typeof(IRequestHandler<>)))
                    .AsImplementedInterfaces()
                    .AddClasses(classes => classes
                        .InNamespaces(_namespaceApplication)
                        .AssignableTo(typeof(IRequestHandler<,>)))
                    .AsImplementedInterfaces()
                    .AddClasses(classes => classes
                        .InNamespaces(_namespaceApplication)
                        .AssignableTo(typeof(IPipelineBehavior<,>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
            });

        private static IServiceCollection AddMvcActionFilters(this IServiceCollection services) => services
            .AddScoped<ApiActionFilter>();
    }
}
