using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using Xunit;

namespace CarWorkshop.MVC.Controllers.Tests
{
    public class HomeControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public HomeControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact()]
        public async Task About_ReturnsViewWithRenderModel()
        {
            // arrange
            var client = _factory.CreateClient();

            // act
            var respone = await client.GetAsync("/Home/About");

            // assert
            respone.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await respone.Content.ReadAsStringAsync();

            content.Should().Contain("<h1>About page</h1>");
        }
    }
}