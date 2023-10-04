using FluentValidation.API.Constants.RouteConstants;
using IntegrationTests.Fixture;
using System.Net;
using System.Net.Http.Json;
using TestBuilders;

namespace IntegrationTests;
public sealed class PhoneIntegrationTests : HttpClientFixture
{
    private const string baseUrl = "api/Phone/";

    [Fact]
    public async Task ValidatePhoneAsync_SuccessfulScenario_Returns200OK()
    {
        // A
        var phone = PhoneBuilder.NewObject().DomainBuild();

        // A
        var validatePhoneHttpResponseMessageResult = await _httpClient.PostAsJsonAsync(baseUrl + PhoneRouteConstants.ValidatePhone, phone);

        // A
        Assert.Equal(validatePhoneHttpResponseMessageResult.StatusCode, HttpStatusCode.OK);
    }

    [Fact]
    public async Task ValidatePhoneAsync_InvalidPhone_Returns400BadRequest()
    {
        // A
        var phone = PhoneBuilder.NewObject().WithPhoneNumber("23").DomainBuild();

        // A
        var validatePhoneHttpResponseMessageResult = await _httpClient.PostAsJsonAsync(baseUrl + PhoneRouteConstants.ValidatePhone, phone);

        // A
        Assert.Equal(validatePhoneHttpResponseMessageResult.StatusCode, HttpStatusCode.BadRequest);
    }
}
