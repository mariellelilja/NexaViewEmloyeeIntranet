using Moq;
using Xunit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IntraUmbracoProject.Controllers;
using Umbraco.Cms.Core.Security;
using Umbraco.Cms.Core.Services;
using Microsoft.AspNetCore.Identity;

using Umbraco.Cms.Core.Install.Models;
using Umbraco.Cms.Core.Models;

using Umbraco.Cms.Web.Common.Security;

//namespace IntraUmbracoProject.Tests;
namespace IntraUmbracoProject;


public class UserControllerTests
{
    private readonly UserController _controller;
    private readonly Mock<IMemberService> _memberServiceMock = new Mock<IMemberService>();
    private readonly Mock<IMemberSignInManager> _memberSignInManagerMock = new Mock<IMemberSignInManager>();
    private readonly Mock<IMemberManager> _memberManagerMock = new Mock<IMemberManager>();
    private readonly Mock<IPasswordHasher> _passwordHasherMock = new Mock<IPasswordHasher>();

    public UserControllerTests()
    {
        _controller = new UserController(
            _memberServiceMock.Object,
            _memberSignInManagerMock.Object,
            _memberManagerMock.Object,
            _passwordHasherMock.Object
            );
    }

    [Fact]
    public void CreateUser_UserExists_ReturnConflict()
    {
        var model = new Controllers.UserModel { Email = "test@example.com" };
        _memberServiceMock.Setup(x => x.GetByEmail(model.Email)).Returns(Mock.Of<IMember>());

        //ACT
        var result = _controller.CreateUser(model);

        //ASSERT
        _memberServiceMock.Verify(x => x.GetByEmail(It.IsAny<string>()), Times.Once);
        //_memberServiceMock.Verify(x => x.Save(It.IsAny<IMember>()), Times.Once);
        //_passwordHasherMock.Verify(x => x.HashPassword(model.Password), Times.Once);
        Assert.IsType<ConflictObjectResult>(result);
    }

    [Fact]
    public void CreateUser_UserDoesNotExist_ReturnOk()
    {
        var model = new Controllers.UserModel
        {
            Username = "newuser",
            Email = "new@email.com",
            Password = "password123"
        };
        _memberServiceMock.Setup(x => x.GetByEmail(model.Email)).Returns((IMember)null);
        _memberServiceMock.Setup(x => x.CreateMemberWithIdentity(model.Username, model.Email, "Member")).Returns(Mock.Of<IMember>());
        _passwordHasherMock.Setup(x => x.HashPassword(It.IsAny<string>())).Returns("hashedpassword");

        var result = _controller.CreateUser(model);

        _memberServiceMock.Verify(x => x.GetByEmail(It.IsAny<string>()), Times.Once); 
        _memberServiceMock.Verify(x => x.Save(It.IsAny<IMember>()), Times.Once);
        _passwordHasherMock.Verify(x => x.HashPassword(model.Password), Times.Once);
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task Login_UserNotFound_ReturnsBadRequest()
    {
        var model = new Controllers.UserModel { Email = "test@example.com" };
        _memberServiceMock.Setup(x => x.GetByEmail(model.Email)).Returns((IMember)null);

        var result = await _controller.Login(model);

        Assert.IsType<BadRequestObjectResult>(result);
        _memberServiceMock.Verify(x => x.GetByEmail(It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public async Task Login_Successful_ReturnsOk()
    {
        var model = new Controllers.UserModel
        {
            Username = "user",
            Password = "password"
        };

        var signInResult = Microsoft.AspNetCore.Identity.SignInResult.Success;
        _memberServiceMock.Setup(x => x.GetByEmail(model.Email)).Returns(Mock.Of<IMember>());
        _memberSignInManagerMock.Setup(x => x.PasswordSignInAsync(model.Username, model.Password, false, true)).ReturnsAsync(signInResult);

        var result = await _controller.Login(model);

        Assert.IsType<OkObjectResult>(result);
        _memberServiceMock.Verify(x => x.GetByEmail(It.IsAny<string>()), Times.Once);
        _memberSignInManagerMock.Verify(x => x.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()), Times.Once);
    }

    [Fact]
    public async Task Logout_ReturnsOk() //No Arrange step as there's no parameters nor external input!
    {
        var result = await _controller.Logout();

        Assert.IsType<OkObjectResult>(result);
        _memberSignInManagerMock.Verify(x => x.SignOutAsync(), Times.Once);
    }

    [Fact]
    public async Task Logout_ThrowsException_ReturnsStatusCode500()
    {
        _memberSignInManagerMock.Setup(x => x.SignOutAsync()).ThrowsAsync(new Exception());

        var result = await _controller.Logout();

        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, statusCodeResult.StatusCode);
        _memberSignInManagerMock.Verify(x => x.SignOutAsync(), Times.Once);

    }
    [Fact]
    public void CreateUser_InvalidModel_ReturnsBadRequest()
    {
        _controller.ModelState.AddModelError("error", "error!");

        var result = _controller.CreateUser(new Controllers.UserModel());

        Assert.IsType<BadRequestObjectResult>(result);
        //_memberServiceMock.Verify(x => x.GetByEmail(It.IsAny<string>()), Times.Once);
        //_memberSignInManagerMock.Verify(x => x.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()), Times.Once);

    }
}