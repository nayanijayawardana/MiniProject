using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

using CodeFirstDB.ViewModle;
using CodeFirstDB.IServices;

namespace CodeFirstDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController: ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService tokenService;

        public AccountController(
                                UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager,
                                ITokenService tokenService
                                )
        {
            _userManager = userManager;
           _signInManager = signInManager;
            this.tokenService = tokenService;
        }
        [HttpGet("[action]")]
        [Authorize]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName) != null;
        }


        [HttpPost("[action]")]
        public async Task<ActionResult<string>> Login(string userName, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userName: userName, password:password,isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(userName: userName);

                if (user == null)
                {
                    return Unauthorized("This user is unautherized");
                }
                if (result.Succeeded)
                {
                    return tokenService.CreateToken(user);
                }
            }
            
            
               return Unauthorized();
            
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<string>> Register([FromBody] RegisterModel model)
        {
            if (CheckEmailExistsAsync(model.UserName).Result.Value)
            {
                return BadRequest("already exits the user");
            }
            var user = new ApplicationUser
            {
                UserName = model.UserName,
                NIC = model.NIC,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return tokenService.CreateToken(user);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
