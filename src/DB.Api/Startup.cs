using AutoMapper;
using Correlate.AspNetCore;
using Correlate.DependencyInjection;
using DB.Api.Extensions;
using DB.Api.Middlewares;
using DB.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OCCBPackage.Extensions;
using OCCBPackage.Sentry;
using OCCBPackage.Swagger.OperationFilters;
using Sentry.Extensibility;

namespace DB.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Register as many ISentryEventExceptionProcessor as you need. They ALL get called.
            services.AddSingleton<ISentryEventExceptionProcessor, ApiExceptionProcessor>();

            // You can also register as many ISentryEventProcessor as you need.
            services.AddTransient<ISentryEventProcessor, SentryEventProcessor>();

            // To demonstrate taking a request-aware service into the event processor above
            services.AddHttpContextAccessor();

            services.AddMediatR();
            services.AddCustomHealthChecks();
            services.AddCorrelate(options => options.RequestHeaders = new[] { "X-Correlation-ID" });
            services.AddDatabaseServices(Configuration.GetConnectionString("DefaultConnection"));
            services.AddAutoMapper(typeof(Startup));
            services.AddApplicationServices();
            services.AddApiServices();
            services.AddCustomSwagger(o =>
            {
                o.OperationFilter<OperationApiProblemDetailsFilter>(
                    new int[] { 504, 503, 502, 501, 500, 415, 413, 412, 405, 400 });
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<ApiExceptionMiddleware>();
            app.UseRouting();
            app.UseCustomHealthChecks();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
            app.UseCorrelate();
            app.UseCustomSwagger();

            app.UpdateDatabase();
        }
    }
}
