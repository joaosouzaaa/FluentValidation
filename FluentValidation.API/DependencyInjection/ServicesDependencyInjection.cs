using FluentValidation.API.Interfaces.Services;
using FluentValidation.API.Services;

namespace FluentValidation.API.DependencyInjection;

public static class ServicesDependencyInjection
{
    public static void AddServicesDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<IPhoneService, PhoneService>();
        services.AddScoped<ISkillService, SkillService>();
    }
}
