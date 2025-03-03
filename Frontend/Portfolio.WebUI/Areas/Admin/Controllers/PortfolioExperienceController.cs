using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioExperineceDtos;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioExperienceServices;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/PortfolioExperience")]
    [Authorize]
    public class PortfolioExperienceController : Controller
    {
        private readonly IPortfolioExperienceService _portfolioExperienceService;

        public PortfolioExperienceController(IPortfolioExperienceService portfolioExperienceService)
        {
            _portfolioExperienceService = portfolioExperienceService;
        }

        [HttpGet]
        [Route("GetAllPortfolioExperince")]
        public async Task<IActionResult> GetAllPortfolioExperince()
        {
            var values = await _portfolioExperienceService.GetAllPortfolioExperienceAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreatePortfolioExperience")]
        public IActionResult CreatePortfolioExperience()
        {
            return View();
        }

        [HttpPost]
        [Route("CreatePortfolioExperience/")]
        public async Task<IActionResult> CreatePortfolioExperience(CreatePortfolioExperienceDto createPortfolioExperienceDto)
        {
            await _portfolioExperienceService.CreatePortfolioExperienceAsync(createPortfolioExperienceDto);
            return RedirectToAction("GetAllPortfolioExperince", "PortfolioExperience", new { area = "Admin" });

        }

        [HttpGet]
        [Route("UpdatePortfolioExperience/{id}")]
        public async Task<IActionResult> UpdatePortfolioExperience(int id)
        {
            var values = await _portfolioExperienceService.GetPortfolioExperienceByPortfolioExperienceIdAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdatePortfolioExperience/{id}")]
        public async Task<IActionResult> UpdatePortfolioExperience(UpdatePortfolioExperienceDto updatePortfolioExperienceDto)
        {
            await _portfolioExperienceService.UpdatePortfolioExperienceAsync(updatePortfolioExperienceDto);
            return RedirectToAction("GetAllPortfolioExperince", "PortfolioExperience", new { area = "Admin" });

        }

        [HttpDelete("{id}")]
        [Route("DeletePortfolioExperience/{id}")]
        public async Task<IActionResult> DeletePortfolioExperience(int id)
        {
            await _portfolioExperienceService.DeletePortfolioExperienceAsync(id);
            return RedirectToAction("GetAllPortfolioExperince", "PortfolioExperience", new { area = "Admin" });
        }
    }
}
