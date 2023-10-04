using FluentValidation;
using FluentValidation.API.Entities;
using FluentValidation.API.Interfaces.Settings;
using FluentValidation.API.Services;
using FluentValidation.Results;
using Moq;
using TestBuilders;

namespace UnitTests.ServicesTests;
public sealed class PhoneServiceTests
{
    private readonly Mock<IValidator<Phone>> _phoneValidatorMock;
    private readonly Mock<INotificationHandler> _notificationHandlerMock;
    private readonly PhoneService _phoneService;

    public PhoneServiceTests()
    {
        _phoneValidatorMock = new Mock<IValidator<Phone>>();
        _notificationHandlerMock = new Mock<INotificationHandler>();
        _phoneService = new PhoneService(_phoneValidatorMock.Object, _notificationHandlerMock.Object);
    }

    [Fact]
    public async Task ValidatePhoneAsync_SuccessfulScenario_ReturnsTrue()
    {
        // A
        var phone = PhoneBuilder.NewObject().DomainBuild();

        var validationResult = new ValidationResult();
        _phoneValidatorMock.Setup(p => p.ValidateAsync(It.IsAny<Phone>(), It.IsAny<CancellationToken>())).ReturnsAsync(validationResult);

        // A
        var validatePhoneResult = await _phoneService.ValidatePhoneAsync(phone);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Never());

        Assert.True(validatePhoneResult);
    }

    [Fact]
    public async Task ValidatePhoneAsync_PhoneInvalid_AddsNotification_ReturnsFalse()
    {
        // A
        var phone = PhoneBuilder.NewObject().DomainBuild();

        var validationResult = new ValidationResult()
        {
            Errors = new List<ValidationFailure>
            {
                new ValidationFailure("valueaaa", "aaarand")
            }
        };
        _phoneValidatorMock.Setup(p => p.ValidateAsync(It.IsAny<Phone>(), It.IsAny<CancellationToken>())).ReturnsAsync(validationResult);

        // A
        var validatePhoneResult = await _phoneService.ValidatePhoneAsync(phone);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(validationResult.Errors.Count));

        Assert.False(validatePhoneResult);
    }
}
