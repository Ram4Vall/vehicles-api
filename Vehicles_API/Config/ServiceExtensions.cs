using Entities.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Vehicles_API.Config
{
    public static class ServiceExtensions
    {
        public static void ConfigureCorsOrigin(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy", builder =>
                {
                    builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowCredentials();
                });
            });
        }
    }
}
