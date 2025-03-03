using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioRoutingFooterDtos;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioRoutingFooterServices;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/PortfolioRoutingFooter")]
    [Authorize]
    public class PortfolioRoutingFooterController : Controller  
    {
        private readonly IPortfolioRoutingFooterService _portfolioRoutingFooterService;

        public PortfolioRoutingFooterController(IPortfolioRoutingFooterService portfolioRoutingFooterService)
        {
            _portfolioRoutingFooterService = portfolioRoutingFooterService;
        }

        [HttpGet]
        [Route("GetAllPortfolioRoutingFooter")]
        public async Task<IActionResult> GetAllPortfolioRoutingFooter()
        {
            var values = await _portfolioRoutingFooterService.GetAllPortfolioRoutingFooterAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreatePortfolioRoutingFooter")]
        public IActionResult CreatePortfolioRoutingFooter()
        {
            return View();
        }

        [HttpPost]
        [Route("CreatePortfolioRoutingFooter")]
        public async Task<IActionResult> CreatePortfolioRoutingFooter(CreatePortfolioRoutingFooterDto createPortfolioRoutingFooterDto)
        {
            await _portfolioRoutingFooterService.CreatePortfolioRoutingFooterDto(createPortfolioRoutingFooterDto);
            return RedirectToAction("GetAllPortfolioRoutingFooter","PortfolioRoutingFooter",new {area = "Admin"});
        }

        [HttpGet]
        [Route("UpdatePortfolioRoutingFooter/{id}")]
        public async Task<IActionResult> UpdatePortfolioRoutingFooter(int id)
        {
            var values = await _portfolioRoutingFooterService.GetPortfolioRoutingFooterByPortfolioRoutingFooterIdAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdatePortfolioRoutingFooter/{id}")]
        public async Task<IActionResult> UpdatePortfolioRoutingFooter(UpdatePortfolioRoutingFooterDto updatePortfolioRoutingFooterDto)
        {
            await _portfolioRoutingFooterService.UpdatePortfolioRoutingFooterDto(updatePortfolioRoutingFooterDto);
            return RedirectToAction("GetAllPortfolioRoutingFooter", "PortfolioRoutingFooter", new { area = "Admin" });
        }

        [HttpDelete("{id}")]
        [Route("DeletePortfolioRoutingFooter/{id}")]
        public async Task<IActionResult> DeletePortfolioRoutingFooter(int id)
        {
            await _portfolioRoutingFooterService.DeletePortfolioRoutingFooterDto(id);
            return RedirectToAction("GetAllPortfolioRoutingFooter", "PortfolioRoutingFooter", new { area = "Admin" });
        }
    }
}
