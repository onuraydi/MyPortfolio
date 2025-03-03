using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioSocialMediaFooterDtos;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioSocialMediaFooterServices;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/PortfolioSocialMediaFooter")]
    [Authorize]
    public class PortfolioSocialMediaFooterController : Controller
    {
        private readonly IPortfolioSocialMediaFooterService _portfolioSocialMediaFooterService;

        public PortfolioSocialMediaFooterController(IPortfolioSocialMediaFooterService portfolioSocialMediaFooterService)
        {
            _portfolioSocialMediaFooterService = portfolioSocialMediaFooterService;
        }

        [HttpGet]
        [Route("GetAllPortfolioSocialMediaFooter")]
        public async Task<IActionResult> GetAllPortfolioSocialMediaFooter()
        {
            var values = await _portfolioSocialMediaFooterService.GetAllPortfolioSocialMediaFooterAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreatePortfolioSocialMediaFooter")]
        public IActionResult CreatePortfolioSocialMediaFooter()
        {
            return View();
        }

        [HttpPost]
        [Route("CreatePortfolioSocialMediaFooter")]
        public async Task<IActionResult> CreatePortfolioSocialMediaFooter(CreatePortfolioSocialMediaFooterDto createPortfolioSocialMediaFooterDto)
        {
            await _portfolioSocialMediaFooterService.CreatePortfolioSocialMediaFooterAsync(createPortfolioSocialMediaFooterDto);
            return RedirectToAction("GetAllPortfolioSocialMediaFooter", "PortfolioSocialMediaFooter",new {area = "Admin"});
        }

        [HttpGet]
        [Route("UpdatePortfolioSocialMediaFooter/{id}")]
        public async Task<IActionResult> UpdatePortfolioSocialMediaFooter(int id)
        {
            var values = await _portfolioSocialMediaFooterService.GetPortfolioSocilaMediaFooterByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdatePortfolioSocialMediaFooter/{id}")]
        public async Task<IActionResult> UpdatePortfolioSocialMediaFooter(UpdatePortfolioSocialMediaFooterDto updatePortfolioSocialMediaFooterDto)
        {
            await _portfolioSocialMediaFooterService.UpdatePortfolioSocialMediaFooterAsync(updatePortfolioSocialMediaFooterDto);
            return RedirectToAction("GetAllPortfolioSocialMediaFooter", "PortfolioSocialMediaFooter", new { area = "Admin" });
        }

        [HttpDelete("{id}")]
        [Route("DeletePortfolioSocialMediaFooter/{id}")]
        public async Task<IActionResult> DeletePortfolioSocialMediaFooter(int id)
        {
            await _portfolioSocialMediaFooterService.DeletePortfolioSocialMediaFooterAsync(id);
            return RedirectToAction("GetAllPortfolioSocialMediaFooter", "PortfolioSocialMediaFooter", new { area = "Admin" });
        }
    }
}
