using FluentValidation.API.Entities;
using FluentValidation.API.Enums;
using FluentValidation.API.Extensions;

namespace FluentValidation.API.Settings.ValidationSettings;

public sealed class PersonValidator : AbstractValidator<Person>
{
	public PersonValidator()
	{
		RuleFor(p => p.Address).SetValidator(new AddressValidator());
        
		RuleForEach(p => p.Phones).SetValidator(new PhoneValidator());

		RuleForEach(p => p.Skills).SetValidator(new SkillValidator());

        RuleFor(p => p.FirstName).Length(3, 50)
			.WithMessage(p => string.IsNullOrEmpty(p.FirstName)
			? EMessage.Required.Description().FormatTo("First Name")
			: EMessage.InvalidLength.Description().FormatTo("First Name", "3 to 50"));

        RuleFor(p => p.LastName).Length(3, 50)
            .WithMessage(p => string.IsNullOrEmpty(p.LastName)
            ? EMessage.Required.Description().FormatTo("Last Name")
			: EMessage.InvalidLength.Description().FormatTo("Last Name", "3 to 50"));

		RuleFor(p => p.Age).GreaterThan(0)
			.WithMessage(EMessage.GreaterThan.Description().FormatTo("Age", "0"));

		RuleFor(p => p.DateOfBirth).GreaterThan(DateTime.Now.AddYears(-18))
			.WithMessage(EMessage.GreaterThan.Description().FormatTo("Date of birth", DateTime.Now.AddYears(-18).ToString()));

		RuleFor(p => p.Email).EmailAddress()
			.WithMessage(EMessage.InvalidFormat.Description().FormatTo("Email", "yourmail@yourprovider.com"));

		RuleFor(p => CpfValidator.ValidateCpf(p.Cpf)).Equal(true)
			.WithMessage(p => EMessage.InvalidFormat.Description().FormatTo("Cpf", "00000000000"));
    }
}
