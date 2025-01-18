using Microsoft.AspNetCore.Mvc;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioProjectFooterDtos;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioProjectfooterServices;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/PortfolioProjectFooter")]
    public class PortfolioProjectFooterController : Controller
    {
        private readonly IPortfolioProjectFooterService _portfolioProjectFooterService;

        public PortfolioProjectFooterController(IPortfolioProjectFooterService portfolioProjectFooterService)
        {
            _portfolioProjectFooterService = portfolioProjectFooterService;
        }

        [HttpGet]
        [Route("GetAllPortfolioProjectFooter")]
        public async Task<IActionResult> GetAllPortfolioProjectFooter()
        {
            var values = await _portfolioProjectFooterService.GetAllPortfolioProjectFooterAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreatePortfolioProjectFooter")]
        public IActionResult CreatePortfolioProjectFooter()
        {
            return View();
        }

        [HttpPost]
        [Route("CreatePortfolioProjectFooter")]
        public async Task<IActionResult> CreatePortfolioProjectFooter(CreatePortfolioProjectFooterDto createPortfolioProjectFooterDto)
        {
            await _portfolioProjectFooterService.CreatePortfolioProjectFooterAsync(createPortfolioProjectFooterDto);
            return RedirectToAction("GetAllPortfolioProjectFooter","PortfolioProjectFooter",new {area="Admin"});
        }

        [HttpGet]
        [Route("UpdatePortfolioProjectFooter/{id}")]
        public async Task<IActionResult> UpdatePortfolioProjectFooter(int id)
        {
            var values = await _portfolioProjectFooterService.GetPortfollioProjectFooterByPortfolioProjectFooterIdAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdatePortfolioProjectFooter/{id}")]
        public async Task<IActionResult> UpdatePortfolioProjectFooter(UpdatePortfolioProjectFooterDto updatePortfolioProjectFooterDto)
        {
            await _portfolioProjectFooterService.UpdatePortfolioProjectFooterAsync(updatePortfolioProjectFooterDto);
            return RedirectToAction("GetAllPortfolioProjectFooter", "PortfolioProjectFooter", new { area = "Admin" });
        }

        [HttpDelete("{id}")]
        [Route("DeletePortfolioProjectFooter/{id}")]
        public async Task<IActionResult> DeletePortfolioProjectFooter(int id)
        {
            await _portfolioProjectFooterService.DeletePortfolioProjectFooterAsync(id);
            return RedirectToAction("GetAllPortfolioProjectFooter", "PortfolioProjectFooter", new { area = "Admin" });
        }


    }
}
