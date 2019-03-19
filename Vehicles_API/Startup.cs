using Entities.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Swashbuckle.AspNetCore.Swagger;
using Vehicles_API.Config;
using VehiclesRepository;

namespace Vehicles_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private SwaggerConfig swaggerInfo = new SwaggerConfig();

        //TODO Create middleware for the config
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureCorsOrigin();

            Configuration.GetSection("SwaggerConfig").Bind(swaggerInfo);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c =>
            {
                var info = new Info
                {
                    Title = swaggerInfo.DocInfoTitle,
                    Version = swaggerInfo.DocInfoVersion,
                    Description = swaggerInfo.DocInfoDescription,
                    Contact = new Contact
                    {
                        Name = swaggerInfo.ContactName,
                        Url = swaggerInfo.ContactUrl
                    }
                };
                c.SwaggerDoc(swaggerInfo.DocNameV1, info);
            });

            //services config
            services.AddScoped<IJsonRepository, JsonRepository>();
            services.AddScoped<IJsonService, JsonService>();
            services.AddScoped<ICsvService, CsvService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(swaggerInfo.EndpointUrl, swaggerInfo.EndpointDescription);
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("SiteCorsPolicy");
            app.UseMvc();
        }
    }
}
