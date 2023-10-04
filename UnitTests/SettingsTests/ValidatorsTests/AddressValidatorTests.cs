using FluentValidation.API.Settings.ValidationSettings;
using TestBuilders;

namespace UnitTests.SettingsTests.ValidatorsTests;
public sealed class AddressValidatorTests
{
    private readonly AddressValidator _addressValidator;

    public AddressValidatorTests()
    {
        _addressValidator = new AddressValidator();
    }

    [Fact]
    public async Task ValidateAddressAsync_SuccessfulScenario_ReturnsTrue()
    {
        // A
        var addressToValidate = AddressBuilder.NewObject().DomainBuild();

        // A
        var validationResult = await _addressValidator.ValidateAsync(addressToValidate);

        // A
        Assert.True(validationResult.IsValid);
    }

    [Theory]
    [MemberData(nameof(Invalid3To100StringLengthParameters))]
    public async Task ValidateAddressAsync_InvalidStreet_ReturnsFalse(string street)
    {
        // A
        var addressWithInvalidStreet = AddressBuilder.NewObject().WithStreet(street).DomainBuild();

        // A
        var validationResult = await _addressValidator.ValidateAsync(addressWithInvalidStreet);

        // A
        Assert.False(validationResult.IsValid);
    }

    [Theory]
    [MemberData(nameof(InvalidComplementParameters))]
    public async Task ValidateAddressAsync_InvalidComplement_ReturnsFalse(string complement)
    {
        // A
        var addressWithInvalidComplement = AddressBuilder.NewObject().WithComplement(complement).DomainBuild();

        // A
        var validationResult = await _addressValidator.ValidateAsync(addressWithInvalidComplement);

        // A
        Assert.False(validationResult.IsValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData("very long string")]
    public async Task ValidateAddressAsync_InvalidNumber_ReturnsFalse(string number)
    {
        // A
        var addressWithInvalidNumber = AddressBuilder.NewObject().WithNumber(number).DomainBuild();

        // A
        var validationResult = await _addressValidator.ValidateAsync(addressWithInvalidNumber);

        // A
        Assert.False(validationResult.IsValid);
    }

    [Theory]
    [MemberData(nameof(Invalid3To100StringLengthParameters))]
    public async Task ValidateAddressAsync_InvalidDistrict_ReturnsFalse(string district)
    {
        // A
        var addressWithInvalidDistrict = AddressBuilder.NewObject().WithDistrict(district).DomainBuild();

        // A
        var validationResult = await _addressValidator.ValidateAsync(addressWithInvalidDistrict);

        // A
        Assert.False(validationResult.IsValid);
    }

    [Theory]
    [MemberData(nameof(Invalid3To100StringLengthParameters))]
    public async Task ValidateAddressAsync_InvalidCity_ReturnsFalse(string city)
    {
        // A
        var addressWithInvalidCity = AddressBuilder.NewObject().WithCity(city).DomainBuild();

        // A
        var validationResult = await _addressValidator.ValidateAsync(addressWithInvalidCity);

        // A
        Assert.False(validationResult.IsValid);
    }

    public static IEnumerable<object[]> Invalid3To100StringLengthParameters()
    {
        yield return new object[]
        {
            ""
        };

        yield return new object[]
        {
            "a"
        };

        yield return new object[]
        {
            new string('a', 101)
        };
    }

    public static IEnumerable<object[]> InvalidComplementParameters()
    {
        yield return new object[]
        {
            "a"
        };

        yield return new object[]
        {
            new string('a', 101)
        };
    }
}
