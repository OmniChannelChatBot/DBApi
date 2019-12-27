using DB.Api.Swagger.OperationFilters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using OCCBPackage;

namespace DB.Api.Extensions
{
    internal static class SwaggerExtension
    {
        private const string RoutePrefix = "api-doc";
        private const string DefaultVersion = "v1";

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services) => services
            .AddSwaggerGen(c =>
            {
                c.SwaggerDoc(nameof(DB), new OpenApiInfo
                {
                    Version = DefaultVersion,
                    Title = nameof(DB),
                    Description = $"`{nameof(DB)}`",
                });

                c.OperationFilter<OperationApiProblemDetailsFilter>(
                       new int[] { 504, 503, 502, 501, 500, 415, 413, 412, 405, 400 },
                       typeof(ApiProblemDetails));

                c.EnableAnnotations();
            });

        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app) => app
            .UseSwagger(options =>
            {
                options.RouteTemplate = $"{RoutePrefix}/{{documentName}}/swagger.json";
            })
            .UseSwaggerUI(c =>
            {
                c.DocumentTitle = $"{nameof(DB)} api docs";

                var endpointName = $"{nameof(DB)} {DefaultVersion}";

                c.SwaggerEndpoint($"/{RoutePrefix}/{nameof(DB)}/swagger.json", endpointName);

                c.RoutePrefix = RoutePrefix;
                c.DisplayRequestDuration();
                c.DisplayOperationId();
            });
    }
}
