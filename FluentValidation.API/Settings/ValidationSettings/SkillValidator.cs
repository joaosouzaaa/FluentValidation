using FluentValidation.API.Entities;
using FluentValidation.API.Enums;
using FluentValidation.API.Extensions;

namespace FluentValidation.API.Settings.ValidationSettings;

public sealed class SkillValidator : AbstractValidator<Skill>
{
	public SkillValidator()
	{
		RuleFor(s => s.Name).Length(3, 50)
			.WithMessage(s => string.IsNullOrEmpty(s.Name)
			? EMessage.Required.Description().FormatTo("Name")
			: EMessage.InvalidLength.Description().FormatTo("Name", "3 to 50"));

		RuleFor(s => s.ExperienceYears).GreaterThan(0)
			.WithMessage(EMessage.GreaterThan.Description().FormatTo("Experience Years", "0"));
	}
}
