using FluentValidation.API.Entities;

namespace FluentValidation.API.Interfaces.Services;

public interface IAddressService
{
    Task<bool> ValidateAddressAsync(Address address);
}
