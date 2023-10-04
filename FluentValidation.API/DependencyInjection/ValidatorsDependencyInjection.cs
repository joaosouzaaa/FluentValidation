using FluentValidation.API.Entities;
using FluentValidation.API.Settings.ValidationSettings;

namespace FluentValidation.API.DependencyInjection;

public static class ValidatorsDependencyInjection
{
    public static void AddValidatorsDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IValidator<Address>, AddressValidator>();
        services.AddScoped<IValidator<Person>, PersonValidator>();
        services.AddScoped<IValidator<Phone>, PhoneValidator>();
        services.AddScoped<IValidator<Skill>, SkillValidator>();
    }
}
