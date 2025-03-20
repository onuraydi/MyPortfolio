using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioMainTitleDtos;
using Portfolio.WebUI.Services.ImageUploadServices.ImageUploadServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioMainTitleServices;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/PortfolioMainTitle")]
    [Authorize]
    public class PortfolioMainTitleController : Controller
    {
        private readonly IPortfolioMainTitleService _portfolioMainTitleService;
        private readonly IImageUploadService _imageUploadService;
        public PortfolioMainTitleController(IPortfolioMainTitleService portfolioMainTitleService, IImageUploadService imageUploadService)
        {
            _portfolioMainTitleService = portfolioMainTitleService;
            _imageUploadService = imageUploadService;
        }

        [HttpGet]
        [Route("GetPortfolioMainTitle")]
        public async Task<IActionResult> GetPortfolioMainTitle()
        {
            var values = await _portfolioMainTitleService.GetPortfolioMainTitleAsync();
            return View(values);
        }

        [HttpGet]
        [Route("UpdatePortfolioMainTitle/{id}")]
        public async Task<IActionResult> UpdatePortfolioMainTitle(int id)
        {

            var values = await _portfolioMainTitleService.GetPortfolioMainTitleByPortfolioMainTitleIdAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdatePortfolioMainTitle/{id}")]  
        public async Task<IActionResult> UpdatePortfolioMainTitle(UpdatePortfolioMainTitleDto updatePortfolioMainTitleDto, IFormFile image, IFormFile cvFile)
        {
            if (image != null && image.Length > 0)
            {
                var uploadedImage = await _imageUploadService.UploadImageAsync(image);
                updatePortfolioMainTitleDto.Image = uploadedImage;
            }
            else
            {
                var existingData = await _portfolioMainTitleService.GetPortfolioMainTitleByPortfolioMainTitleIdAsync(updatePortfolioMainTitleDto.PortfolioMainTitleId);
                if (existingData != null)
                {
                    updatePortfolioMainTitleDto.Image = existingData.Image;
                }
            }

            if (cvFile != null && cvFile.Length > 0)
            {
                var uploadedCV = await _imageUploadService.UploadImageAsync(cvFile);
                updatePortfolioMainTitleDto.CV = uploadedCV;
            }
            else
            {
                var existingData = await _portfolioMainTitleService.GetPortfolioMainTitleByPortfolioMainTitleIdAsync(updatePortfolioMainTitleDto.PortfolioMainTitleId);
                if (existingData != null)
                {
                    updatePortfolioMainTitleDto.CV = existingData.CV;
                }
            }

            await _portfolioMainTitleService.UpdatePortfolioMainTitleAsync(updatePortfolioMainTitleDto);
            return RedirectToAction("GetPortfolioMainTitle", "PortfolioMainTitle", new { area = "Admin" });
        }

        [HttpGet]
        [Route("DownloadCV/{id}")]
        public async Task<IActionResult> DownloadCV(int id)
        {
            var data = await _portfolioMainTitleService.GetPortfolioMainTitleByPortfolioMainTitleIdAsync(id);
            if (data == null || string.IsNullOrEmpty(data.CV))
            {
                return NotFound("CV dosyası bulunamadı.");
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", data.CV);
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
