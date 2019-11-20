using System.Threading.Tasks;
using JB.Integration.Api.Test.Fixtures;
using Xunit;

namespace JB.Integration.Api.Test.Controllers
{
    public class TestOne : BaseIntegrationTest
    {
        public TestOne(IntegrationFixture factory) : base(factory)
        {
        }

        [Theory]
        [InlineData("/api/v1/weatherforecast")]
        public async Task Get_WeatherPage_AnonymousAllowed_Success(string url)
        {
            // Arrange
            // Act
            var response = await Client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}
