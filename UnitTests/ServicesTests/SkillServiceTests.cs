using FluentValidation;
using FluentValidation.API.Entities;
using FluentValidation.API.Interfaces.Settings;
using FluentValidation.API.Services;
using FluentValidation.Results;
using Moq;
using TestBuilders;

namespace UnitTests.ServicesTests;
public sealed class SkillServiceTests
{
    private readonly Mock<IValidator<Skill>> _skillValidatorMock;
    private readonly Mock<INotificationHandler> _notificationHandlerMock;
    private readonly SkillService _skillService;

    public SkillServiceTests()
    {
        _skillValidatorMock= new Mock<IValidator<Skill>>();
        _notificationHandlerMock = new Mock<INotificationHandler>();
        _skillService = new SkillService(_skillValidatorMock.Object, _notificationHandlerMock.Object);
    }

    [Fact]
    public async Task ValidateSkillAsync_SuccessfulScenario_ReturnsTrue()
    {
        // A
        var skill = SkillBuilder.NewObject().DomainBuild();

        var validationResult = new ValidationResult();
        _skillValidatorMock.Setup(s => s.ValidateAsync(It.IsAny<Skill>(), It.IsAny<CancellationToken>())).ReturnsAsync(validationResult);

        // A
        var validateSkillResult = await _skillService.ValidateSkillAsync(skill);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Never());

        Assert.True(validateSkillResult);
    }

    [Fact]
    public async Task ValidateSkillAsync_SkillInvalid_AddsNotification_ReturnsFalse()
    {
        // A
        var skill = SkillBuilder.NewObject().DomainBuild();

        var validationResult = new ValidationResult()
        {
            Errors = new List<ValidationFailure>
            {
                new ValidationFailure("random", "errpr"),
                new ValidationFailure("random", "errpr")
            }
        };
        _skillValidatorMock.Setup(s => s.ValidateAsync(It.IsAny<Skill>(), It.IsAny<CancellationToken>())).ReturnsAsync(validationResult);

        // A
        var validateSkillResult = await _skillService.ValidateSkillAsync(skill);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(validationResult.Errors.Count));

        Assert.False(validateSkillResult);
    }
}
