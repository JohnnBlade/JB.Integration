using System.Threading.Tasks;
using JB.Integration.Api.Test.Fixtures;
using JB.Integration.Core.ViewModels;
using Xunit;

namespace JB.Integration.Api.Test.Controllers
{
    public class TestFour : BaseIntegrationTest
    {
        public TestFour(IntegrationFixture factory) : base(factory)
        {
        }

        [Theory]
        [InlineData("/api/v1/weatherforecast")]
        [InlineData("/api/v1/profile")]
        public async Task Get_Public_Api_End_Points(string url)
        {
            // Arrange
            // Act
            var response = await Client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/api/v1/auth")]
        public async Task Get_Login_When_Post_Is_Expected(string url)
        {
            // Arrange
            // Act
            var response = await Client.GetAsync(url);

            // Assert
            Assert.Equal("MethodNotAllowed", response.StatusCode.ToString());
            //Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/api/v1/auth")]
        public async Task Post_Do_Login(string url)
        {
            // Arrange
            var content = new LoginViewModel()
            {
                UserName = "test@test.com",
                Password = "12345678"
            };

            // Act
            var response = await Client.PostAsync(url, ObjectToJsonContent(content));

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            //Assert.Equal("MethodNotAllowed", response.StatusCode.ToString());
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}
