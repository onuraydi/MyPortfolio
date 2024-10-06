using Microsoft.AspNetCore.Mvc;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioAboutMeDtos;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioAboutMeServices;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/PortfolioAboutMe")]
    public class PortfolioAboutMeController : Controller
    {
        private readonly IPortfolioAboutMeService _portfolioAboutMeService;

        public PortfolioAboutMeController(IPortfolioAboutMeService portfolioAboutMeService)
        {
            _portfolioAboutMeService = portfolioAboutMeService;
        }

        [HttpGet]
        [Route("GetPortfolioAboutMe")]
        public async Task<IActionResult> GetPortfolioAboutMe()
        {
            var values = await _portfolioAboutMeService.GetPortfolioAboutMeAsync();
            return View(values);
        }

        [HttpGet]
        [Route("UpdatePortfolioAboutMe/{id}")]
        public async Task<IActionResult> UpdatePortfolioAboutMe(int id)
        {
            var values = await _portfolioAboutMeService.GetPortfolioAboutMeByPortfolioAboutMeIdAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdatePortfolioAboutMe/{id}")]
        public async Task<IActionResult> UpdatePortfolioAboutMe(UpdatePortfolioAboutMeDto updatePortfolioAboutMeDto)
        {
            await _portfolioAboutMeService.UpdatePortfolioAboutMeAsync(updatePortfolioAboutMeDto);
            return RedirectToAction("GetPortfolioAboutMe", "PortfolioAboutMe", new { area = "Admin" });
        }
    }
}
