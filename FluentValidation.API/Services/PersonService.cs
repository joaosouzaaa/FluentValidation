using FluentValidation.API.Entities;
using FluentValidation.API.Interfaces.Services;
using FluentValidation.API.Interfaces.Settings;
using FluentValidation.API.Services.BaseServices;

namespace FluentValidation.API.Services;

public sealed class PersonService : BaseService<Person>, IPersonService
{
    public PersonService(IValidator<Person> validator, INotificationHandler notificationHandler) 
                         : base(validator, notificationHandler)
    {
    }

    public async Task<bool> ValidatePersonAsync(Person person)
    {
        if (await ValidateAsync(person))
            return false;

        // call repository of perform other action
        return true;
    }
}
