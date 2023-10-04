using FluentValidation.API.Constants.RouteConstants;
using IntegrationTests.Fixture;
using System.Net;
using System.Net.Http.Json;
using TestBuilders;

namespace IntegrationTests;
public sealed class AddressIntegrationTests : HttpClientFixture
{
    private const string baseUrl = "api/Address/";

    [Fact]
    public async Task ValidateAddressAsync_SuccessfulScenario_Returns200OK()
    {
        // A
        var address = AddressBuilder.NewObject().DomainBuild();

        // A
        var validateAddressHttpResponseMessageResult = await _httpClient.PostAsJsonAsync(baseUrl + AddressRouteConstants.ValidateAddress, address);

        // A
        Assert.Equal(validateAddressHttpResponseMessageResult.StatusCode, HttpStatusCode.OK);
    }

    [Fact]
    public async Task ValidateAddressAsync_InvalidAddres_Returns400BadRequest()
    {
        // A
        var address = AddressBuilder.NewObject().WithNumber("").DomainBuild();

        // A
        var validateAddressHttpResponseMessageResult = await _httpClient.PostAsJsonAsync(baseUrl + AddressRouteConstants.ValidateAddress, address);

        // A
        Assert.Equal(validateAddressHttpResponseMessageResult.StatusCode, HttpStatusCode.BadRequest);
    }
}
