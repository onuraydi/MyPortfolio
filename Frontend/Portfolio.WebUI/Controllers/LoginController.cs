using Microsoft.AspNetCore.Mvc;
using Portfolio.DtoLayer.PortfolioDtos.LoginDtos;
using Portfolio.WebUI.Services.PortfolioServices.LoginServices;

namespace Portfolio.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IloginServices _loginServices;

        public LoginController(IloginServices loginServices)
        {
            _loginServices = loginServices;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var values = await _loginServices.Login(loginDto);
            return RedirectToAction("GetPortfolioAboutMe", "PortfolioAboutMe", new { area = "Admin" });
        }
    }
}
