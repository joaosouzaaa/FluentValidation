using FluentValidation.API.Interfaces.Settings;
using FluentValidation.API.Settings.NotificationSettings;

namespace FluentValidation.API.DependencyInjection;

public static class SettingsDependencyInjection
{
    public static void AddSettingsDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<INotificationHandler, NotificationHandler>();
        services.AddValidatorsDependencyInjection(); 
    }
}
