using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace NewStarterTask.WebApi.Extensions
{
    public static class CustomSwaggerGenExtensions
    {
        public static IServiceCollection AddCustomSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Fleet API", Version = "v1" });
            });
            return services;
        }

        public static void UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            var swaggerEndpoint = "swagger";
            app.UseSwagger(c =>
                c.RouteTemplate = $"{swaggerEndpoint}/{{documentName}}/swagger.json"
            );

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/{swaggerEndpoint}/v1/swagger.json", "v1");

                c.DocumentTitle = "Fleet API Documentation";
                c.DocExpansion(DocExpansion.List);
            });
        }
    }
}
