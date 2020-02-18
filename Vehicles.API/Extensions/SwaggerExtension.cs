using Entities.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Vehicles.API.Extension
{
    public static class SwaggerExtension
    {
        public static void AddConfigureSwagger(this IServiceCollection services, SwaggerConfig swaggerConfig)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(swaggerConfig.DocName, new OpenApiInfo { 
                    Title = swaggerConfig.DocInfoTitle, 
                    Version = swaggerConfig.DocInfoVersion,
                    Contact = new OpenApiContact() 
                    { 
                        Name = swaggerConfig.ContactName,
                        Url = new System.Uri(swaggerConfig.ContactUrl)
                    },
                    Description = swaggerConfig.DocInfoDescription

                });
            });
        }


        public static void UseConfiguredSwagger(this IApplicationBuilder app, SwaggerConfig swaggerConfig)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(swaggerConfig.EndpointUrl, swaggerConfig.EndpointDescription);
            });
        }
    }
}
