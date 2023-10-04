using FluentValidation.API.Enums;
using FluentValidation.API.Extensions;

namespace UnitTests.ExtensionsTests;
public sealed class MessageExtensionTests
{
    [Fact]
    public void Description_Equals_AsIntended()
    {
        // A
        var messageToGetDescription = EMessage.Required;
        
        // A
        var messageDescription = messageToGetDescription.Description();

        // A
        Assert.Equal(messageDescription, "{0} need to be filled.");
    }
}
