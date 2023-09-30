namespace FluentValidation.API.DependencyInjection;

public static class DependencyInjectionHandler
{
    public static void AddDependencyInjectionHandler(this IServiceCollection services)
    {
        services.AddSettingsDependencyInjection();
        services.AddFiltersDependencyInjection();
        services.AddServicesDependencyInjection();
    }
}
