using FluentValidation.API.Entities;
using FluentValidation.API.Enums;
using FluentValidation.API.Extensions;

namespace FluentValidation.API.Settings.ValidationSettings;

public sealed class AddressValidator : AbstractValidator<Address>
{
	public AddressValidator()
	{
		RuleFor(a => a.ZipCode).Matches(@"^\d{8}$")
			.WithMessage(EMessage.InvalidFormat.Description().FormatTo("ZipCode", "00000000"));

		RuleFor(a => a.Street).Length(3, 100)
			.WithMessage(a => string.IsNullOrEmpty(a.Street)
            ? EMessage.Required.Description().FormatTo("Street")
            : EMessage.InvalidLength.Description().FormatTo("Street", "3 to 100"));

		When(a => !string.IsNullOrEmpty(a.Complement), () =>
		{
            RuleFor(a => a.Complement).Length(3, 100)
				.WithMessage(EMessage.InvalidLength.Description().FormatTo("Complement", "3 to 100"));
        });

        RuleFor(a => a.Number).Length(3, 10)
            .WithMessage(a => string.IsNullOrEmpty(a.Number)
            ? EMessage.Required.Description().FormatTo("Number")
            : EMessage.InvalidLength.Description().FormatTo("Number", "3 to 10"));

        RuleFor(a => a.District).Length(3, 100)
            .WithMessage(a => string.IsNullOrEmpty(a.District)
            ? EMessage.Required.Description().FormatTo("District")
            : EMessage.InvalidLength.Description().FormatTo("District", "3 to 100"));

        RuleFor(a => a.City).Length(3, 100)
            .WithMessage(a => string.IsNullOrEmpty(a.City)
            ? EMessage.Required.Description().FormatTo("City")
            : EMessage.InvalidLength.Description().FormatTo("City", "3 to 100"));
    }
}
