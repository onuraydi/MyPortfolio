using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioCertificateDtos;
using Portfolio.WebUI.Services.ImageUploadServices.ImageUploadServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioCertificateServices;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/PortfolioCertificate")]
    [Authorize]
    public class PortfolioCertificateController : Controller
    {
        private readonly IPortfolioCertificateService _portfolioCertificateService;
        private readonly IImageUploadService _imageUploadService;
        public PortfolioCertificateController(IPortfolioCertificateService portfolioCertificateService, IImageUploadService imageUploadService)
        {
            _portfolioCertificateService = portfolioCertificateService;
            _imageUploadService = imageUploadService;
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
        public async Task<IActionResult> CreatePortfolioCertificate(CreatePortfolioCertificateDto createPortfolioCertificateDto, IFormFile image)
        {
            if(image != null)
            {
                var uplodingImage = await _imageUploadService.UploadImageAsync(image);
                createPortfolioCertificateDto.Image = uplodingImage;
            }
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
        public async Task<IActionResult> UpdatePortfolioCertificate(UpdatePortfolioCertificateDto updatePortfolioCertificateDto,IFormFile image)
        {
            if (image != null)
            {
                var updatedImage = await _imageUploadService.UploadImageAsync(image);
                updatePortfolioCertificateDto.Image = updatedImage;
            }
            else
            {
                var exsistingImage = await _portfolioCertificateService.GetPortfolioCertificateByPortfolioCertificateIdAsync(updatePortfolioCertificateDto.PortfolioCertificateId);
                if (exsistingImage != null)
                {
                    updatePortfolioCertificateDto.Image = exsistingImage.Image;
                }
            }
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
