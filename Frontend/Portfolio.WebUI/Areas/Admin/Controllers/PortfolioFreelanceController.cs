using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioFreelanceDtos;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioFreelanceServices;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/PortfolioFreelance")]
    [Authorize]
    public class PortfolioFreelanceController : Controller  
    {
        private readonly IPortfolioFreelanceService _portfolioFreelanceService;


        public PortfolioFreelanceController(IPortfolioFreelanceService portfolioFreelanceService)
        {
            _portfolioFreelanceService = portfolioFreelanceService;
        }

        [HttpGet]
        [Route("GetAllPortfolioFreelance")]
        public async Task<IActionResult> GetAllPortfolioFreelance()
        {
            var values = await _portfolioFreelanceService.GetAllPortfolioFreelanceAsync();
            return View(values);
        }

        [HttpGet]
        [Route("GetPortfolioFreelanceByPortfolioFreelanceId/{id}")]
        public async Task<IActionResult> GetPortfolioFreelanceByPortfolioFreelanceId(int id)
        {
            var values = await _portfolioFreelanceService.GetPortfolioFreelanceByPortfolioFreelanceIdAsync(id);
            return View(values);
        }

        [HttpGet]
        [Route("CreatePortfolioFreelance")]
        public IActionResult CreatePortfolioFreelance()
        {
            return View();
        }

        [HttpPost]
        [Route("CreatePortfolioFreelance")]
        public async Task<IActionResult> CreatePortfolioFreelance(CreatePortfolioFreelanceDto createPortfolioFreelanceDto)
        {
            await _portfolioFreelanceService.CreatePortfolioFreelanceAsync(createPortfolioFreelanceDto);
            return RedirectToAction("GetAllPortfolioFreelance","PortfolioFreelance",new {area = "Admin"});
        }

        [HttpGet]
        [Route("UpdatePortfolioFreelance/{id}")]
        public async Task<IActionResult> UpdatePortfolioFreelance(int id)
        {
            var values = await _portfolioFreelanceService.GetPortfolioFreelanceByPortfolioFreelanceIdAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdatePortfolioFreelance/{id}")]
        public async Task<IActionResult> UpdatePortfolioFreelance(UpdatePortfolioFreelanceDto updatePortfolioFreelanceDto)
        {
            await _portfolioFreelanceService.UpdatePortfolioFreelanceAsync(updatePortfolioFreelanceDto);
            return RedirectToAction("GetAllPortfolioFreelance", "PortfolioFreelance", new { area = "Admin" });
        }

        [HttpDelete("{id}")]
        [Route("DeletePortfoliFreelance/{id}")]
        public async Task<IActionResult> DeletePortfolioFreelance(int id)
        {
            await _portfolioFreelanceService.DeletePortfolioFreelanceAsync(id);
            return RedirectToAction("GetAllPortfolioFreelance", "PortfolioFreelance", new { area = "Admin" });
        }
    }
}
