using Microsoft.AspNetCore.Mvc;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogDtos;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogServices;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/PortfolioBlog")]
    public class PortfolioBlogController : Controller
    {
        private readonly IPortfolioBlogService _portfolioBlogService;

        public PortfolioBlogController(IPortfolioBlogService portfolioBlogService)
        {
            _portfolioBlogService = portfolioBlogService;
        }

        [HttpGet]
        [Route("GetAllPortfolioBlog")]
        public async Task<IActionResult> GetAllPortfolioBlog()
        {
            var values = await _portfolioBlogService.GetAllPortfolioBlogAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreatePortfolioBlog")]
        public IActionResult CreatePortfolioBlog()
        {
            return View();
        }

        [HttpPost]
        [Route("CreatePortfolioBlog")]
        public async Task<IActionResult> CreatePortfolioBlog(CreatePortfolioBlogDto createPortfolioBlogDto)
        {
            await _portfolioBlogService.CreatePortfolioBlogAsync(createPortfolioBlogDto);
            return Json(new { redirectToUrl = Url.Action("GetAllPortfolioBlog", "PortfolioBlog", new { area = "Admin" }) });
        }

        [HttpGet]
        [Route("UpdatePortfolioBlog/{id}")]
        public async Task<IActionResult> UpdatePortfolioBlog(int id)
        {
            var values = await _portfolioBlogService.GetPortfolioBlogByPortfolioBlogIdAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdatePortfolioBlog/{id}")]
        public async Task<IActionResult> UpdatePortfolioBlog(UpdatePortfolioBlogDto updatePortfolioBlogDto)
        {
            await _portfolioBlogService.UpdatePortfolioBlogAsync(updatePortfolioBlogDto);
            return RedirectToAction("GetAllPortfolioBlog", "PortfolioBlog", new { area = "Admin" });
        }

        [HttpDelete("{id}")]
        [Route("DeletePortfolioBlog/{id}")]
        public async Task<IActionResult> DeletePortfolioBlog(int id)
        {
            await _portfolioBlogService.DeletePortfolioBlogAsync(id);
            return RedirectToAction("GetAllPortfolioBlog", "PortfolioBlog", new { area = "Admin" });
        }
    }
}
