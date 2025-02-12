using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.WebApi.Entites.Identity;
using MyPortfolio.WebApi.Services.AuthServices;

namespace MyPortfolio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthLoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public AuthLoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var response = await _loginService.Login(loginModel);
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
