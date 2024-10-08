using Microsoft.AspNetCore.Mvc;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioEducationDtos;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioEducationServices;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/PortfolioEducation")]
    public class PortfolioEducationController : Controller
    {
        private readonly IPortfolioEducationService _portfolioEducationService;

        public PortfolioEducationController(IPortfolioEducationService portfolioEducationService)
        {
            _portfolioEducationService = portfolioEducationService;
        }

        [HttpGet]
        [Route("GetAllPortfolioEducation")]
        public async Task<IActionResult> GetAllPortfolioEducation()
        {
            var values = await _portfolioEducationService.GetAllPortfolioEducationAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreatePortfolioEducation")]
        public IActionResult CreatePortfolioEducation()
        {
            return View();
        }

        [HttpPost]
        [Route("CreatePortfolioEducation")]
        public async Task<IActionResult> CreatePortfolioEducation(CreatePortfolioEducationDto createPortfolioEducationDto)
        {
            await _portfolioEducationService.CreatePortfolioEducationAsync(createPortfolioEducationDto);
            return RedirectToAction("GetAllPortfolioEducation", "PortfolioEducation", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdatePortfolioEducation/{id}")]
        public async Task<IActionResult> UpdatePortfolioEducation(int id)
        {
            var values = await _portfolioEducationService.GetPortfolioEducationByPortfolioEducationAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdatePortfolioEducation/{id}")]
        public async Task<IActionResult> UpdatePortfolioEducation(UpdatePortfolioEducationDto updatePortfolioEducationDto)
        {
            await _portfolioEducationService.UpdatePortfolioEducationAsync(updatePortfolioEducationDto);
            return RedirectToAction("GetAllPortfolioEducation", "PortfolioEducation", new { area = "Admin" });
        }

        [HttpDelete("{id}")]
        [Route("DeletePortfolioEducation/{id}")]
        public async Task<IActionResult> DeletePortfolioEducation(int id)
        {
            await _portfolioEducationService.DeletePortfolioEducationAsync(id);
            return RedirectToAction("GetAllPortfolioEducation", "PortfolioEducation", new { area = "Admin" });
        }
    }
}
