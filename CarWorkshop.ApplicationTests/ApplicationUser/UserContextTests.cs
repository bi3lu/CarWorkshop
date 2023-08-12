using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Security.Claims;
using Xunit;

namespace CarWorkshop.Application.ApplicationUser.Tests
{
    public class UserContextTests
    {
        [Fact()]
        public void GetCurrentUser_WithAuthenticatedUser_ShouldReturnCurrentUser()
        {
            // arrange
            var claims = new List<Claim> 
            {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Email, "test@example.com"),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "User")
            };

            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"));

            var httpContextAccessMock = new Mock<IHttpContextAccessor>();

            httpContextAccessMock.Setup(x => x.HttpContext).Returns(new DefaultHttpContext()
            {
                User = user
            });

            var userContext = new UserContext(httpContextAccessMock.Object);

            // act
            var currentUser = userContext.GetCurrentUser();

            // assert
            currentUser.Should().NotBeNull();
            currentUser!.Id.Should().Be("1");
            currentUser.Email.Should().Be("test@example.com");
            currentUser.Roles.Should().ContainInOrder("Admin", "User");
        }
    }
}