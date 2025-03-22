using Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace Identity.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(RegisterModel registerModel)
        {
            var values = new ApplicationUser()
            {
                Email = registerModel.Email,
                UserName = registerModel.Username,
                Name = registerModel.Name,
                Surname = registerModel.Surname,
            };

            var result = await _userManager.CreateAsync(values, registerModel.Password);
            if(result.Succeeded)
            {
                return Ok("kullanıcı başarıyla kaydedildi");
            }
            return BadRequest("Bir Hata oldu");
        }
    }
}
