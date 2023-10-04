using FluentValidation.API.Entities;

namespace FluentValidation.API.Interfaces.Services;

public interface IPersonService
{
    Task<bool> ValidatePersonAsync(Person person);
}
