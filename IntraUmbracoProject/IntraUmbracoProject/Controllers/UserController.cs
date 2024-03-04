using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Umbraco.Cms.Core.Security;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.Security;

namespace IntraUmbracoProject.Controllers;

[Route("api2/[controller]")]
[ApiController]

public class UserController : UmbracoApiController
{
    private IMemberService _memberService;
    private IMemberSignInManager _memberSignInManager;
    private IMemberManager _memberManager;
    private IPasswordHasher _passwordHasher;

    public UserController(IMemberService memberService, IMemberSignInManager memberSignInManager, IMemberManager memberManager, IPasswordHasher passwordHasher)
    {
        _memberService = memberService;
        _memberSignInManager = memberSignInManager;
        _memberManager = memberManager;
        _passwordHasher = passwordHasher;
    }

    [HttpPost("CreateUser")]
    public IActionResult CreateUser([FromBody] UserModel model)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = _memberService.GetByEmail(model.Email);
            if (existingUser != null)
            {
                return Conflict("User with the given email already exists.");
            }
            var user = _memberService.CreateMemberWithIdentity(model.Username, model.Email, "Member");
            user.RawPasswordValue = _passwordHasher.HashPassword(model.Password);
            _memberService.Save(user);
            return Ok("User created successfully");
        }
        catch (Exception)
        {
            return StatusCode(500, "An internal server error occurred while attempting to create user. Please try again later.");
        }
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] UserModel model)
    {
        try
        {
            var user = _memberService.GetByEmail(model.Email);
            if (user == null)
            {
                return BadRequest("User not found.");

            }

            var result = await _memberSignInManager.PasswordSignInAsync(model.Username, model.Password, false, true);
            if (result.Succeeded)
            {
                return Ok("User logged in successfully.");
            }
            if (result.IsLockedOut)
            {
                return StatusCode(423, "User account is locked out.");
            }
            return BadRequest("Invalid login attempt");
        }
        catch (Exception)
        {
            return StatusCode(500, "An internal server error occurred while attempting to log in. Please try again later.");
        }
    }

    [HttpPost("Logout")]
    public async Task<IActionResult> Logout()
    {
        try
        {
            await _memberSignInManager.SignOutAsync();
            return Ok("User logged out successfully.");
        }
        catch (Exception)
        {
            return StatusCode(500, "An internal server error occurred while attempting to log out. Please try again later.");
        }
    }
}

public class UserModel
{
    [Required]
    public string Username { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
