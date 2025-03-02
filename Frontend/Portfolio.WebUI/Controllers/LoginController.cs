using Microsoft.AspNetCore.Mvc;
using Portfolio.DtoLayer.PortfolioDtos.LoginDtos;
using Portfolio.WebUI.Services.IdentityServices.Abstract;
using Portfolio.WebUI.Services.PortfolioServices.LoginServices;

namespace Portfolio.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IIdentityService _identityService;
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IIdentityService identityService, IHttpClientFactory httpClientFactory)
        {
            _identityService = identityService;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        //[HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var values = await _identityService.SignIn(loginDto);

            if(values == true)
            {
                return RedirectToAction("GetPortfolioAboutMe", "PortfolioAboutMe", new { area = "Admin" });
            }
            return View();  // 401 vb. bir sayfa gidecek 
        }
    }
}
