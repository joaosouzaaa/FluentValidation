using FluentValidation.API.Constants.CorsConstants;

namespace FluentValidation.API.DependencyInjection;

public static class CorsDependencyInjection
{
    public static void AddCorsDependencyInjection(this IServiceCollection services)
    {
        services.AddCors(p => p.AddPolicy(PoliciesConstants.DefaultCorsPolicy, builder =>
        {
            builder.AllowAnyMethod()
                   .AllowAnyHeader()
                   .SetIsOriginAllowed(origin => true)
                   .AllowCredentials();
        }));
    }
}
