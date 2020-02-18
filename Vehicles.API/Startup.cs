using Entities.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services;
using Vehicles.API.Extension;
using VehiclesRepository;

namespace Vehicles.API
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
        private readonly SwaggerConfig SwaggerInfo = new SwaggerConfig();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Configuration.GetSection("SwaggerConfig").Bind(SwaggerInfo);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.ConfigureCorsOrigin();
            services.AddConfigureSwagger(SwaggerInfo);

            //services
            services.AddScoped<IJsonRepository, JsonRepository>();
            services.AddScoped<IJsonService, JsonService>();
            services.AddScoped<ICsvService, CsvService>();
            services.AddScoped<IValidationService, ValidationService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseCors("SiteCorsPolicy");

            app.UseConfiguredSwagger(SwaggerInfo);

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
