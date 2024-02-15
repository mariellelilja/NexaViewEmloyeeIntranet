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
            var existingUser = _memberService.GetByEmail(model.Email);
            if (existingUser == null)
            {
                try
                {
                    IMember user = _memberService.CreateMemberWithIdentity(model.Username, model.Email, model.Username, "Member");
                    user.RawPasswordValue = _passwordHasher.HashPassword(model.Password);
                    _memberService.Save(user);
                    return Ok("User created successfully");
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to create new member " + ex.Message);
                }
            }
            return BadRequest("Failed to create user");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserModel model)
        {
            var user = _memberService.GetByEmail(model.Email);

            if (user != null)
            {
                if (await _memberManager.ValidateCredentialsAsync(model.Username, model.Password))
                {
                    var result = await _memberSignInManager.PasswordSignInAsync(model.Username, model.Password, false, true);
                    if (result.Succeeded)
                    {
                        return Ok("User logged in");
                    }
                }
            }

            return BadRequest("Failed to create user");
        }


        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _memberSignInManager.SignOutAsync();
            return BadRequest("Failed to create user");
        }
    }

    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
