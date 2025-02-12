using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.WebApi.Entites.Identity;
using MyPortfolio.WebApi.Services.AuthServices;

namespace MyPortfolio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        public AuthController(IRegisterService registerService)
        {
            _registerService = registerService;
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            await _registerService.Register(registerModel);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
