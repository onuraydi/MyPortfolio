using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioAboutMeDtos;
using Portfolio.WebUI.Services.ImageUploadServices.ImageUploadServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioAboutMeServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioMainTitleServices;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/PortfolioAboutMe")]
    [Authorize]
    public class PortfolioAboutMeController : Controller
    {
        private readonly IPortfolioAboutMeService _portfolioAboutMeService;
        private readonly IImageUploadService _imageUploadService;
        private readonly IPortfolioMainTitleService _portfolioMainTitleService;

        public PortfolioAboutMeController(IPortfolioAboutMeService portfolioAboutMeService, IImageUploadService imageUploadService, IPortfolioMainTitleService portfolioMainTitleService)
        {
            _portfolioAboutMeService = portfolioAboutMeService;
            _imageUploadService = imageUploadService;
            _portfolioMainTitleService = portfolioMainTitleService;
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

            // CV dosyasının yolunu PortfolioMainTitle'dan al
            var mainTitleData = await _portfolioMainTitleService.GetPortfolioMainTitleAsync();
            if (mainTitleData != null && mainTitleData.Any() && !string.IsNullOrEmpty(mainTitleData.FirstOrDefault().Button1Href))
            {
                updatePortfolioAboutMeDto.ButtonHref = mainTitleData.FirstOrDefault().Button1Href;
            }

            await _portfolioAboutMeService.UpdatePortfolioAboutMeAsync(updatePortfolioAboutMeDto);
            return RedirectToAction("GetPortfolioAboutMe", "PortfolioAboutMe", new { area = "Admin" });
        }

        public async Task<IActionResult> DownloadCv(int id)
        {
            var data = await _portfolioAboutMeService.GetPortfolioAboutMeByPortfolioAboutMeIdAsync(id);
            if (data == null || string.IsNullOrEmpty(data.ButtonHref))
            {
                return NotFound("CV dosyası bulunamadı.");
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", data.ButtonHref);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("CV dosyası bulunamadı.");
            }

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, "application/pdf", "CV.pdf");
        }
    }
}
