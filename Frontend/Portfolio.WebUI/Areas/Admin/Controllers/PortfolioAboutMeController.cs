using Microsoft.AspNetCore.Mvc;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioAboutMeDtos;
using Portfolio.WebUI.Services.ImageUploadServices.ImageUploadServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioAboutMeServices;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/PortfolioAboutMe")]
    public class PortfolioAboutMeController : AdminBaseController
    {
        private readonly IPortfolioAboutMeService _portfolioAboutMeService;
        private readonly IImageUploadService _imageUploadService;

        public PortfolioAboutMeController(IPortfolioAboutMeService portfolioAboutMeService, IImageUploadService imageUploadService)
        {
            _portfolioAboutMeService = portfolioAboutMeService;
            _imageUploadService = imageUploadService;
        }

        [HttpGet]
        [Route("GetPortfolioAboutMe")]
        public async Task<IActionResult> GetPortfolioAboutMe()
        {
            var values = await _portfolioAboutMeService.GetPortfolioAboutMeAsync();
            return View(values);
        }

        [HttpGet]
        [Route("UpdatePortfolioAboutMe/{id}")]
        public async Task<IActionResult> UpdatePortfolioAboutMe(int id)
        {
            var values = await _portfolioAboutMeService.GetPortfolioAboutMeByPortfolioAboutMeIdAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdatePortfolioAboutMe/{id}")]
        public async Task<IActionResult> UpdatePortfolioAboutMe(UpdatePortfolioAboutMeDto updatePortfolioAboutMeDto,IFormFile image)
        {
            if(image != null && image.Length > 0)
            {   
                var uploadedImage = await _imageUploadService.UploadImageAsync(image);
                updatePortfolioAboutMeDto.Image = uploadedImage;
            }
            else
            {
                var existingData = await _portfolioAboutMeService.GetPortfolioAboutMeByPortfolioAboutMeIdAsync(updatePortfolioAboutMeDto.PortfolioAboutMeId);
                if(existingData != null)
                {
                    updatePortfolioAboutMeDto.Image = existingData.Image;
                }
            }
            await _portfolioAboutMeService.UpdatePortfolioAboutMeAsync(updatePortfolioAboutMeDto);
            return RedirectToAction("GetPortfolioAboutMe", "PortfolioAboutMe", new { area = "Admin" });
        }
    }
}
