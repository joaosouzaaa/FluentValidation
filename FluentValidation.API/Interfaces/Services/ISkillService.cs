using FluentValidation.API.Entities;

namespace FluentValidation.API.Interfaces.Services;

public interface ISkillService
{
    Task<bool> ValidateSkillAsync(Skill skill);
}
