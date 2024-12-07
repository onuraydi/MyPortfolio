using Microsoft.AspNetCore.Mvc;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogTagDtos;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogTagServices;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/PortfolioBlogTag")]
    public class PortfolioBlogTagController : Controller
    {
        private readonly IPortfolioBlogTagServices _portfolioBlogTagServices;

        public PortfolioBlogTagController(IPortfolioBlogTagServices portfolioBlogTagServices)
        {
            _portfolioBlogTagServices = portfolioBlogTagServices;
        }


        [HttpGet]
        [Route("GetAllPortfolioBlogTag")]
        public async Task<IActionResult> GetAllPortfolioBlogTag()
        {
            var values = await _portfolioBlogTagServices.GetAllPortfolioBlogTagAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreatePortfolioBlogTag")]
        public async Task<IActionResult> CreatePortfolioBlogTag()
        {
            return View();
        }

        [HttpPost]
        [Route("CreatePortfolioBlogTag")]
        public async Task<IActionResult> CreatePortfolioBlogTag(CreatePortfolioBlogTagDto createPortfolioBlogTagDto)
        {
            await _portfolioBlogTagServices.CreatePortfolioBlogTagAsync(createPortfolioBlogTagDto);
            return RedirectToAction("GetAllPortfolioBlogTag", "PortfolioBlogTag", new { Area = "Admin" });
        }

        [HttpGet]
        [Route("UpdatePortfolioBlogTag")]
        public async Task<IActionResult> UpdatePortfolioBlogTag(int id)
        {
            var values = await _portfolioBlogTagServices.GetPortfolioBlogTagByPortfolioBlogTagIdAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdatePortfolioBlogTag")]
        public async Task<IActionResult> UpdatePortfolioBlogTag(UpdatePortfolioBlogTagDto updatePortfolioBlogTagDto)
        {
            await _portfolioBlogTagServices.UpdatePortfolioBlogTagAsync(updatePortfolioBlogTagDto);
            return RedirectToAction("GetAllPortfolioBlogTag", "PortfolioBlogTag", new { Area = "Admin" });
        }

        [HttpDelete("{id}")]
        [Route("DeletePortfolioBlogTag/{id}")]
        public async Task<IActionResult> DeletePortfolioBlogTag(int id)
        {
            await _portfolioBlogTagServices.DeletePortfolioBlogTagAsync(id);
            return RedirectToAction("GetAllPortfolioBlogTag", "PortfolioBlogTag", new { Area = "Admin" });
        }
    }
}
