using Microsoft.Extensions.DependencyInjection;

namespace Vehicles.API.Extension
{
    public static class CorsExtension
    {
        public static void ConfigureCorsOrigin(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy", builder =>
                {
                    builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
                });
            });
        }
    }
}
