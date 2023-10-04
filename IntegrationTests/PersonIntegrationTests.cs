using FluentValidation.API.Constants.RouteConstants;
using IntegrationTests.Fixture;
using System.Net;
using System.Net.Http.Json;
using TestBuilders;

namespace IntegrationTests;
public sealed class PersonIntegrationTests : HttpClientFixture
{
    private const string baseUrl = "api/Person/";

    [Fact]
    public async Task ValidatePersonAsync_SuccessfulScenario_Returns200OK()
    {
        // A
        var person = PersonBuilder.NewObject().DomainBuild();

        // A
        var validatePersonHttpResponseMessageResult = await _httpClient.PostAsJsonAsync(baseUrl + PersonRouteConstants.ValidatePerson, person);

        // A
        Assert.Equal(validatePersonHttpResponseMessageResult.StatusCode, HttpStatusCode.OK);
    }

    [Fact]
    public async Task ValidatePersonAsync_InvalidPerson_Returns400BadRequest()
    {
        // A
        var person = PersonBuilder.NewObject().WithCpf("worng").DomainBuild();

        // A
        var validatePersonHttpResponseMessageResult = await _httpClient.PostAsJsonAsync(baseUrl + PersonRouteConstants.ValidatePerson, person);

        // A
        Assert.Equal(validatePersonHttpResponseMessageResult.StatusCode, HttpStatusCode.BadRequest);
    }
}
