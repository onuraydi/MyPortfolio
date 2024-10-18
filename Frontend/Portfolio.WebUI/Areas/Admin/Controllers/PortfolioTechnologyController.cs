using Microsoft.AspNetCore.Mvc;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioTechnologyDtos;
using Portfolio.WebUI.Services.ImageUploadServices.ImageUploadServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioTechnologyServices;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/PortfolioTechnology")]
    public class PortfolioTechnologyController : Controller
    {
        private readonly IPortfolioTechnologyService _portfolioTechnologyService;
        private readonly IImageUploadService _imageUploadService;
        public PortfolioTechnologyController(IPortfolioTechnologyService portfolioTechnologyService, IImageUploadService imageUploadService)
        {
            _portfolioTechnologyService = portfolioTechnologyService;
            _imageUploadService = imageUploadService;
        }

        [HttpGet]
        [Route("GetAllPortfolioTechnology")]
        public async Task<IActionResult> GetAllPortfolioTechnology()
        {
            var values = await _portfolioTechnologyService.GetAllPortfolioTechnologyAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreatePortfolioTechnology")]
        public IActionResult CreatePortfolioTechnology()
        {
            return View();
        }

        [HttpPost]
        [Route("CreatePortfolioTechnology")]
        public async Task<IActionResult> CreatePortfolioTechnology(CreatePortfolioTechnologyDto createPortfolioTechnologyDto,IFormFile iconUrl)
        {
            var uplodingImage = await _imageUploadService.UploadImageAsync(iconUrl);
            createPortfolioTechnologyDto.IconUrl = uplodingImage;
            await _portfolioTechnologyService.CreatePortfolioTechnologyAsync(createPortfolioTechnologyDto);
            return RedirectToAction("GetAllPortfolioTechnology", "PortfolioTechnology", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdatePortfolioTechnology/{id}")]
        public async Task<IActionResult> UpdatePortfolioTechnology(int id)
        {
            var values = await _portfolioTechnologyService.GetPortfolioTechnologyByPortfolioTechnologyIdAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdatePortfolioTechnology/{id}")]
        public async Task<IActionResult> UpdatePortfolioTechnology(UpdatePortfolioTechnologyDto updatePortfolioTechnologyDto,IFormFile iconUrl)
        {
            if (iconUrl != null || iconUrl.Length > 0)
            {
                var uploadedImage = await _imageUploadService.UploadImageAsync(iconUrl);
                updatePortfolioTechnologyDto.IconUrl = uploadedImage;
            }
            else
            {
                var existingData = await _portfolioTechnologyService.GetPortfolioTechnologyByPortfolioTechnologyIdAsync(updatePortfolioTechnologyDto.PortfolioTechnologyId);
                if (existingData != null)
                {
                    updatePortfolioTechnologyDto.IconUrl = existingData.IconUrl;
                }
            }
            await _portfolioTechnologyService.UpdatePortfolioTechnologyAsync(updatePortfolioTechnologyDto);
            return RedirectToAction("GetAllPortfolioTechnology", "PortfolioTechnology", new { area = "Admin" });
        }

        [HttpDelete("{id}")]
        [Route("DeletePortfolioTechnology/{id}")]
        public async Task<IActionResult> DeletePortfolioTechnology(int id)
        {
            await _portfolioTechnologyService.DeletePortfolioTechnologyAsync(id);
            return RedirectToAction("GetAllPortfolioTechnology", "PortfolioTechnology", new { area = "Admin" });
        }
    }
}
