using Microsoft.AspNetCore.Mvc;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioCertificateDtos;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioCertificateServices;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/PortfolioCertificate")]
    public class PortfolioCertificateController : Controller
    {
        private readonly IPortfolioCertificateService _portfolioCertificateService;

        public PortfolioCertificateController(IPortfolioCertificateService portfolioCertificateService)
        {
            _portfolioCertificateService = portfolioCertificateService;
        }

        [HttpGet]
        [Route("GetAllPortfolioCertificate")]
        public async Task<IActionResult> GetAllPortfolioCertificate()
        {
            var values = await _portfolioCertificateService.GetAllPortfolioCertificateAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreatePortfolioCertificate")]
        public IActionResult CreatePortfolioCertificate()
        {
            return View();
        }

        [HttpPost]
        [Route("CreatePortfolioCertificate")]
        public async Task<IActionResult> CreatePortfolioCertificate(CreatePortfolioCertificateDto createPortfolioCertificateDto)
        {
            await _portfolioCertificateService.CreatePortfolioCertificateAsync(createPortfolioCertificateDto);
            return RedirectToAction("GetAllPortfolioCertificate", "PortfolioCertificate",new {area="Admin"});
        }

        [HttpGet]
        [Route("UpdatePortfolioCertificate/{id}")]
        public async Task<IActionResult> UpdatePortfolioCertificate(int id)
        {
            var values = await _portfolioCertificateService.GetPortfolioCertificateByPortfolioCertificateIdAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdatePortfolioCertificate/{id}")]
        public async Task<IActionResult> UpdatePortfolioCertificate(UpdatePortfolioCertificateDto updatePortfolioCertificateDto)
        {
            await _portfolioCertificateService.UpdatePortfolioCertificateAsync(updatePortfolioCertificateDto);
            return RedirectToAction("GetAllPortfolioCertificate", "PortfolioCertificate", new { area = "Admin" });
        }

        [HttpDelete("{id}")]
        [Route("DeletePortfolioCertificate/{id}")]
        public async Task<IActionResult> DeletePortfolioCertificate(int id)
        {
            await _portfolioCertificateService.DeletePortfolioCertificateAsync(id);
            return RedirectToAction("GetAllPortfolioCertificate", "PortfolioCertificate", new { area = "Admin" });
        }
    }
}
