using AutoMapper;
using Correlate.AspNetCore;
using Correlate.DependencyInjection;
using DB.Api.Extensions;
using DB.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DB.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomHealthChecks();
            services.AddCorrelate(options => options.RequestHeaders = new[] { "X-Correlation-ID" });
            services.AddDatabaseServices(Configuration.GetConnectionString("DefaultConnection"));
            services.AddAutoMapper(typeof(Startup));
            services.AddApplicationServices();
            services.AddApiServices();
            services.AddCustomSwagger();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseCustomHealthChecks();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
            app.UseCorrelate();
            app.UseCustomSwagger();

            app.UpdateDatabase();
        }
    }
}
