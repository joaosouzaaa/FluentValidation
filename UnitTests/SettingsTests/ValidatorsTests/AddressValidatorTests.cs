using FluentValidation.API.Settings.ValidationSettings;

namespace UnitTests.SettingsTests.ValidatorsTests;
public sealed class AddressValidatorTests
{
    private readonly AddressValidator _addressValidator;

	public AddressValidatorTests()
	{
		_addressValidator = new AddressValidator();
	}

	
}
