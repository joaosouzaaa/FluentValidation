using FluentValidation.API.Entities;
using FluentValidation.API.Enums;
using FluentValidation.API.Extensions;

namespace FluentValidation.API.Settings.ValidationSettings;

public sealed class PhoneValidator : AbstractValidator<Phone>
{
	public PhoneValidator()
	{
		RuleFor(p => p.PhoneNumber).Matches(@"^\d{11}$")
			.WithMessage(EMessage.InvalidFormat.Description().FormatTo("Phone Number", "00000000000"));
	}
}
