using FluentValidation;
using FluentValidation.API.Entities;
using FluentValidation.API.Interfaces.Settings;
using FluentValidation.API.Services;
using FluentValidation.Results;
using Moq;
using TestBuilders;

namespace UnitTests.ServicesTests;
public sealed class AddressServiceTests
{
    private readonly Mock<IValidator<Address>> _addressValidatorMock;
    private readonly Mock<INotificationHandler> _notificationHandlerMock;
    private readonly AddressService _addressService;

    public AddressServiceTests()
    {
        _addressValidatorMock = new Mock<IValidator<Address>>();
        _notificationHandlerMock = new Mock<INotificationHandler>();
        _addressService = new AddressService(_addressValidatorMock.Object, _notificationHandlerMock.Object);
    }

    [Fact]
    public async Task ValidateAddressAsync_SuccessfulScenario_ReturnsTrue()
    {
        // A
        var address = AddressBuilder.NewObject().DomainBuild();

        var validationResult = new ValidationResult();
        _addressValidatorMock.Setup(a => a.ValidateAsync(It.IsAny<Address>(), It.IsAny<CancellationToken>())).ReturnsAsync(validationResult);

        // A
        var validateAddressResult = await _addressService.ValidateAddressAsync(address);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Never());

        Assert.True(validateAddressResult);
    }

    [Fact]
    public async Task ValidateAddressAsync_AddressInvalid_AddsNotification_ReturnsFalse()
    {
        // A
        var address = AddressBuilder.NewObject().DomainBuild();

        var validationResult = new ValidationResult() 
        {
            Errors = new List<ValidationFailure> 
            { 
                new ValidationFailure("value", "rand")
            }
        };
        _addressValidatorMock.Setup(a => a.ValidateAsync(It.IsAny<Address>(), It.IsAny<CancellationToken>())).ReturnsAsync(validationResult);

        // A
        var validateAddressResult = await _addressService.ValidateAddressAsync(address);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(validationResult.Errors.Count));

        Assert.False(validateAddressResult);
    }
}
