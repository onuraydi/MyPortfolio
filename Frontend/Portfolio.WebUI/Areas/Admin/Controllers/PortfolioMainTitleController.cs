using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioMainTitleDtos;
using Portfolio.WebUI.Services.CvUploadServices;
using Portfolio.WebUI.Services.ImageUploadServices.ImageUploadServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioMainTitleServices;
using System.IO;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/PortfolioMainTitle")]
    [Authorize]
    public class PortfolioMainTitleController : Controller
    {
        private readonly IPortfolioMainTitleService _portfolioMainTitleService;
        private readonly IImageUploadService _imageUploadService;
        private readonly ICvUploadService _cvUploadService;
        public PortfolioMainTitleController(IPortfolioMainTitleService portfolioMainTitleService, IImageUploadService imageUploadService, ICvUploadService cvUploadService)
        {
            _portfolioMainTitleService = portfolioMainTitleService;
            _imageUploadService = imageUploadService;
            _cvUploadService = cvUploadService;
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
            if (cvFile != null)
            {
                updatePortfolioMainTitleDto.Button1Href = await _cvUploadService.CreateCvFileAsync(cvFile);
            }
            else
            {
                var existingCvData = await _portfolioMainTitleService.GetPortfolioMainTitleByPortfolioMainTitleIdAsync(updatePortfolioMainTitleDto.PortfolioMainTitleId);
                    {
                    if(existingCvData != null)
                    {
                        updatePortfolioMainTitleDto.Button1Href = existingCvData.Button1Href;
                    }
                }
            }

            await _portfolioMainTitleService.UpdatePortfolioMainTitleAsync(updatePortfolioMainTitleDto);
            return RedirectToAction("GetPortfolioMainTitle", "PortfolioMainTitle", new { area = "Admin" });
        }

        public async Task<IActionResult> DownloadCv(int id)
        {
            var data = await _portfolioMainTitleService.GetPortfolioMainTitleByPortfolioMainTitleIdAsync(id);
            if (data == null || string.IsNullOrEmpty(data.Button1Href))
            {
                return NotFound("CV dosyası bulunamadı.");
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", data.Button1Href);
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
