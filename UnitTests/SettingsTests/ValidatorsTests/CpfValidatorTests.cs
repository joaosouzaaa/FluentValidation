using FluentValidation.API.Settings.ValidationSettings;

namespace UnitTests.SettingsTests.ValidatorsTests;
public sealed class CpfValidatorTests
{
    [Theory]
    [InlineData("58217437025")]
    [InlineData("82532961007")]
    [InlineData("45632504069")]
    [InlineData("80804091021")]
    [InlineData("00514934034")]
    public void ValidateCpf_SuccessfulScenario_ReturnsTrue(string cpfToValidate)
    {
        var validateCpfResult = CpfValidator.ValidateCpf(cpfToValidate);

        Assert.True(validateCpfResult);
    }

    [Theory]
    [InlineData("")]
    [InlineData("aaaa")]
    [InlineData("joao")]
    [InlineData("123912039")]
    [InlineData("123")]
    [InlineData("80904091021")]
    public void ValidaCpf_CpfInvalid_ReturnsFalse(string cpfToValidate)
    {
        var validateCpfResult = CpfValidator.ValidateCpf(cpfToValidate);

        Assert.False(validateCpfResult);
    }
}
