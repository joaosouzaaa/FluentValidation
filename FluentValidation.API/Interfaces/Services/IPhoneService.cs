using FluentValidation.API.Entities;

namespace FluentValidation.API.Interfaces.Services;

public interface IPhoneService
{
    Task<bool> ValidatePhoneAsync(Phone phone);
}
