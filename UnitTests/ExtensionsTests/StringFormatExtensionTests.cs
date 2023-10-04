using FluentValidation.API.Extensions;

namespace UnitTests.ExtensionsTests;
public sealed class StringFormatExtensionTests
{
    [Fact]
    public void FormatTo_ReturnsFormatedString()
    {
        // A
        var stringToFormat = "{0} meu nome é {1}";

        // A
        var stringFormatted = stringToFormat.FormatTo("oi", "joao");

        // A
        Assert.Equal(stringFormatted, "oi meu nome é joao");
    }

    [Fact]
    public void CleanCaracters_CleanAllCaracters()
    {
        // A
        var stringToClean = "joaoasdsjdiasdi999";

        // A
        var stringCleaned = stringToClean.CleanCaracters();

        // A
        Assert.Equal(stringCleaned, "999");
    }
}
