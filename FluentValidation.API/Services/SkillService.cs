using FluentValidation.API.Entities;
using FluentValidation.API.Interfaces.Services;
using FluentValidation.API.Interfaces.Settings;
using FluentValidation.API.Services.BaseServices;

namespace FluentValidation.API.Services;

public sealed class SkillService : BaseService<Skill>, ISkillService
{
    public SkillService(IValidator<Skill> validator, INotificationHandler notificationHandler) 
                        : base(validator, notificationHandler)
    {
    }

    public async Task<bool> ValidateSkillAsync(Skill skill) =>
        await ValidateAsync(skill);
}
