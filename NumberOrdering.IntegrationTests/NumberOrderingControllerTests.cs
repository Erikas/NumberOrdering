using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace NumberOrdering.IntegrationTests
{
    public class NumberOrderingControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:5000";  // Update with your API's base URL

        public NumberOrderingControllerTests(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }
    }
}
