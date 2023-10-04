using FluentValidation.API.Constants.RouteConstants;
using IntegrationTests.Fixture;
using System.Net;
using System.Net.Http.Json;
using TestBuilders;

namespace IntegrationTests;
public sealed class SkillIntegrationTests : HttpClientFixture
{
    private const string baseUrl = "api/Skill/";

    [Fact]
    public async Task ValidateSkillAsync_SuccessfulScenario_Returns200OK()
    {
        // A
        var skill = SkillBuilder.NewObject().DomainBuild();

        // A
        var validateSkillHttpResponseMessageResult = await _httpClient.PostAsJsonAsync(baseUrl + SkillRouteConstants.ValidateSkill, skill);

        // A
        Assert.Equal(validateSkillHttpResponseMessageResult.StatusCode, HttpStatusCode.OK);
    }

    [Fact]
    public async Task ValidateSkillAsync_InvalidSkill_Returns400BadRequest()
    {
        // A
        var skill = SkillBuilder.NewObject().WithExperienceYears(-1).DomainBuild();

        // A
        var validateSkillHttpResponseMessageResult = await _httpClient.PostAsJsonAsync(baseUrl + SkillRouteConstants.ValidateSkill, skill);

        // A
        Assert.Equal(validateSkillHttpResponseMessageResult.StatusCode, HttpStatusCode.BadRequest);
    }
}
