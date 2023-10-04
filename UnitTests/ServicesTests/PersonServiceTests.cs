using FluentValidation;
using FluentValidation.API.Entities;
using FluentValidation.API.Interfaces.Settings;
using FluentValidation.API.Services;
using FluentValidation.Results;
using Moq;
using TestBuilders;

namespace UnitTests.ServicesTests;
public sealed class PersonServiceTests
{
    private readonly Mock<IValidator<Person>> _personValidatorMock;
    private readonly Mock<INotificationHandler> _notificationHandlerMock;
    private readonly PersonService _personService;

    public PersonServiceTests()
    {
        _personValidatorMock = new Mock<IValidator<Person>>();
        _notificationHandlerMock = new Mock<INotificationHandler>();
        _personService = new PersonService(_personValidatorMock.Object, _notificationHandlerMock.Object);
    }

    [Fact]
    public async Task ValidatePersonAsync_SuccessfulScenario_ReturnsTrue()
    {
        // A
        var person = PersonBuilder.NewObject().DomainBuild();

        var validationResult = new ValidationResult();
        _personValidatorMock.Setup(p => p.ValidateAsync(It.IsAny<Person>(), It.IsAny<CancellationToken>())).ReturnsAsync(validationResult);

        // A
        var validatePersonResult = await _personService.ValidatePersonAsync(person);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Never());

        Assert.True(validatePersonResult);
    }

    [Fact]
    public async Task ValidatePersonAsync_InvalidPerson_AddsNotification_ReturnsFalse()
    {
        // A
        var person = PersonBuilder.NewObject().DomainBuild();

        var validationResult = new ValidationResult()
        {
            Errors = new List<ValidationFailure>
            {
                new ValidationFailure("test", "2"),
                new ValidationFailure("value", "rand"),
                new ValidationFailure("person", "test")
            }
        };
        _personValidatorMock.Setup(p => p.ValidateAsync(It.IsAny<Person>(), It.IsAny<CancellationToken>())).ReturnsAsync(validationResult);

        // A
        var validatePersonResult = await _personService.ValidatePersonAsync(person);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(validationResult.Errors.Count));

        Assert.False(validatePersonResult);
    }
}
