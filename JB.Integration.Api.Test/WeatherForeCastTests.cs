using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace JB.Integration.Api.Test
{

    public class WeatherForeCastTests : IClassFixture<WebApplicationFactory<JB.Integration.Api.Startup>>
    {
        private readonly WebApplicationFactory<JB.Integration.Api.Startup> _factory;

        public WeatherForeCastTests(WebApplicationFactory<JB.Integration.Api.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/v1/weatherforecast")]
        public async Task Get_WeatherPage_AnonymousAllowed_Success(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/api/v1/profile")]
        public async Task Get_AuthorizedProfilePage_Success(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            Assert.Equal("401", response.StatusCode.ToString());
        }
    }
}
