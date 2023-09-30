using Microsoft.AspNetCore.Mvc.Testing;

namespace IntegrationTests.Fixture;
public sealed class HttpClientFixture
{
    protected readonly HttpClient _httpClient;

    protected HttpClientFixture()
    {
        var appFactory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder => { });

        _httpClient = appFactory.CreateClient();
    }
}
