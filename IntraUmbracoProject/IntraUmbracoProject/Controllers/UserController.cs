using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Security;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.Security;
using Umbraco.Cms.Web.Website.Controllers;

namespace YourNamespace.Controllers
{
    [Route("api2/[controller]")]
    [ApiController]
    public class UserController : UmbracoApiController
    {
        private IMemberService _memberService;
        private IMemberSignInManager _memberSignInManager;
        private IMemberManager _memberManager;
        private IPasswordHasher _passwordHasher;

        public UserController(IMemberService memberService, IMemberSignInManager memberSignInManager, IMemberManager memberManager, IPasswordHasher passwordHasher) { 
            _memberService = memberService;
            _memberSignInManager = memberSignInManager;
            _memberManager = memberManager;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = _memberService.GetByEmail(model.Email);
            if (existingUser != null)
            {
                return BadRequest("User with the provided email already exists.");
            }

            try
            {
                IMember user = _memberService.CreateMemberWithIdentity(model.Username, model.Email, model.Username, "Member");
                user.RawPasswordValue = _passwordHasher.HashPassword(model.Password);
                _memberService.Save(user);
                return Ok("User created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the user.");
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = _memberService.GetByEmail(model.Email);
                if (user != null && await _memberManager.ValidateCredentialsAsync(model.Username, model.Password))
                {
                    var result = await _memberSignInManager.PasswordSignInAsync(model.Username, model.Password, false, lockoutOnFailure: true);
                    if (result.Succeeded)
                    {
                        return Ok("User logged in successfully");
                    }
                }
                return BadRequest("Login failed. Invalid email or password.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while attempting to log in.");
            }
        }


        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized("Logout failed or user was not logged in.");
            }
            try
            {
                await _memberSignInManager.SignOutAsync();
                return Ok("User logged out successfully");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Unexpected error occured during log out.");
            }

        }
    }

    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
