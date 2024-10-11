using Microsoft.AspNetCore.Mvc;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioContactDtos;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioContactServices;

namespace Portfolio.WebUI.Controllers
{
    public class denemeController : Controller
    {
        private readonly IPortfolioContactService _portfolioContactService;

        public denemeController(IPortfolioContactService portfolioContactService)
        {
            _portfolioContactService = portfolioContactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreatePortfolioContactDto createPortfolioContactDto)
        {
            
            await _portfolioContactService.CreatePortfolioContactAsync(createPortfolioContactDto);
            return RedirectToAction("Index","deneme");
        }
    }
}
