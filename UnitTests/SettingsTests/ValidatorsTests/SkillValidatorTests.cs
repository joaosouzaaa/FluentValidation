using FluentValidation.API.Settings.ValidationSettings;
using TestBuilders;

namespace UnitTests.SettingsTests.ValidatorsTests;
public sealed class SkillValidatorTests
{
    private readonly SkillValidator _skillValidator;

	public SkillValidatorTests()
	{
		_skillValidator = new SkillValidator();
	}

	[Fact]
	public async Task ValidateSkillAsync_SuccessfulScenario_ReturnsTrue()
	{
		// A
		var skillToValidate = SkillBuilder.NewObject().DomainBuild();

		// A
		var validationResult = await _skillValidator.ValidateAsync(skillToValidate);

		// A
		Assert.True(validationResult.IsValid);
	}

    [Theory]
    [MemberData(nameof(InvalidNameParameters))]
    public async Task ValidateSkillAsync_InvalidName_ReturnsFalse(string name)
    {
        // A
        var skillWithInvalidName = SkillBuilder.NewObject().WithName(name).DomainBuild();

        // A
        var validationResult = await _skillValidator.ValidateAsync(skillWithInvalidName);

        // A
        Assert.False(validationResult.IsValid);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-10)]
    [InlineData(-5)]
    public async Task ValidateSkillAsync_InvalidExperienceYears_ReturnsFalse(int experienceYears)
    {
        // A
        var skillWithInvalidExperienceYears = SkillBuilder.NewObject().WithExperienceYears(experienceYears).DomainBuild();

        // A
        var validationResult = await _skillValidator.ValidateAsync(skillWithInvalidExperienceYears);

        // A
        Assert.False(validationResult.IsValid);
    }

    public static IEnumerable<object[]> InvalidNameParameters()
	{
		yield return new object[]
		{
            ""
		};

        yield return new object[]
        {
            "aa"
        };

        yield return new object[]
        {
            new string ('a', 100)
        };

        yield return new object[]
        {
            new string('q', 51)
        };
    }
}
