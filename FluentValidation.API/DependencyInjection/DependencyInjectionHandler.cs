namespace FluentValidation.API.DependencyInjection;

public static class DependencyInjectionHandler
{
    public static void AddDependencyInjectionHandler(this IServiceCollection services)
    {
        services.AddCorsDependencyInjection();
        services.AddSettingsDependencyInjection();
        services.AddServicesDependencyInjection();
        services.AddFiltersDependencyInjection();
    }
}
