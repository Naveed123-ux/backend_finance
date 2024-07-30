using backend_finance.Dtos.Account;
using backend_finance.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace backend_finance.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountControllers : ControllerBase
    {

        private readonly UserManager<AppUser> _userManager;
        public AccountControllers(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto register)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                };
                var appUser = new AppUser
                {
                    UserName = register.UserName,
                    Email = register.EmailAddress
                };
                var createUser = await _userManager.CreateAsync(appUser, register.Password);
                if (createUser.Succeeded)
                {
                    var roleUser = await _userManager.AddToRoleAsync(appUser, "User");
                    if (roleUser.Succeeded) {
                        return Ok("user created");
                    }
                    else
                    {
                        return StatusCode(500, roleUser.Errors); 
                    }
                }
                else
                {
                    return StatusCode(500,createUser.Errors);
                }

            }
            catch (Exception ex) { 
            return StatusCode(500,ex);
            }
        }
    } 
}
