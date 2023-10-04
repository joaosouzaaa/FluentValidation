using FluentValidation.API.Settings.ValidationSettings;
using TestBuilders;

namespace UnitTests.SettingsTests.ValidatorsTests;
public sealed class PhoneValidatorTests
{
    private readonly PhoneValidator _phoneValidator;

    public PhoneValidatorTests()
    {
        _phoneValidator = new PhoneValidator();
    }

    [Fact]
    public async Task ValidatePhoneAsync_SuccessfulScenario_ReturnsTrue()
    {
        // A
        var phoneToValidate = PhoneBuilder.NewObject().DomainBuild();

        // A
        var validationResult = await _phoneValidator.ValidateAsync(phoneToValidate);

        // A
        Assert.True(validationResult.IsValid);
    }

    [Theory]
    [InlineData("a")]
    [InlineData("")]
    [InlineData("23901230")]
    [InlineData("123333")]
    [InlineData("419967485412")]
    public async Task ValidatePhoneAsync_InvalidPhoneNumber_ReturnsFalse(string phoneNumber)
    {
        // A
        var phoneWithInvalidPhoneNumber = PhoneBuilder.NewObject().WithPhoneNumber(phoneNumber).DomainBuild();

        // A
        var validationResult = await _phoneValidator.ValidateAsync(phoneWithInvalidPhoneNumber);

        // A
        Assert.False(validationResult.IsValid);
    }
}
