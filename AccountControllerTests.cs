using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Online_store.Controllers;
using Online_store.Models;
using Xunit;

namespace Online_store.Tests.Controllers
{
    public class AccountControllerTests
    {
        [Fact]
        public async Task Login_ReturnsRedirectToActionResult_WhenLoginIsSuccessful()
        {
            // Arrange
            var userModel = new UserModel
            {
                Username = "testuser",
                PasswordHash = "testpassword",
                ReturnUrl = "/home/index"
            };

            var userManagerMock = new Mock<UserManager<IdentityUser>>(MockBehavior.Strict);
            userManagerMock.Setup(m => m.FindByNameAsync(It.IsAny<string>())).ReturnsAsync(new IdentityUser { UserName = userModel.Username });
            var signInManagerMock = new Mock<Microsoft.AspNetCore.Identity.SignInManager<IdentityUser>>(userManagerMock.Object,
                new Mock<IHttpContextAccessor>().Object,
                new Mock<IUserClaimsPrincipalFactory<IdentityUser>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<ILogger<Microsoft.AspNetCore.Identity.SignInManager<IdentityUser>>>().Object,
                new Mock<IAuthenticationSchemeProvider>().Object);

            signInManagerMock.Setup(m => m.PasswordSignInAsync(It.IsAny<IdentityUser>(), It.IsAny<string>(), false, false))
                .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);

            var controller = new AccountController(null, userManagerMock.Object, signInManagerMock.Object);

            // Act
            var result = await controller.Login(userModel) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Home", result.ControllerName);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal(userModel.ReturnUrl, result.RouteValues["returnUrl"]);
        }

        // Add more test cases for different scenarios such as invalid login, etc.
    }
}
