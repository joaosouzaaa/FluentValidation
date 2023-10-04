using FluentValidation.API.Entities;
using FluentValidation.API.Interfaces.Services;
using FluentValidation.API.Interfaces.Settings;
using FluentValidation.API.Services.BaseServices;

namespace FluentValidation.API.Services;

public sealed class PhoneService : BaseService<Phone>, IPhoneService
{
    public PhoneService(IValidator<Phone> validator, INotificationHandler notificationHandler) 
                        : base(validator, notificationHandler)
    {
    }

    public async Task<bool> ValidatePhoneAsync(Phone phone) =>
        await ValidatePhoneAsync(phone);
}
