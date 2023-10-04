using Microsoft.OpenApi.Models;
using System.Reflection;

namespace FluentValidation.API.DependencyInjection;

public static class SwaggerDependencyInjection
{
    public static void AddSwaggerDependencyInjection(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1",
                new OpenApiInfo()
                {
                    Title = "FluentValidation",
                    Version = "v1"
                });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });
    }
}
