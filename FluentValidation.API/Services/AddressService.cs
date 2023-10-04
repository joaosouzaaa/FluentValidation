using FluentValidation.API.Entities;
using FluentValidation.API.Interfaces.Services;
using FluentValidation.API.Interfaces.Settings;
using FluentValidation.API.Services.BaseServices;

namespace FluentValidation.API.Services;

public sealed class AddressService : BaseService<Address>, IAddressService
{
    public AddressService(IValidator<Address> validator, INotificationHandler notificationHandler) 
                          : base(validator, notificationHandler)
    {
    }

    public async Task<bool> ValidateAddressAsync(Address address) =>
        await ValidateAsync(address);
}
