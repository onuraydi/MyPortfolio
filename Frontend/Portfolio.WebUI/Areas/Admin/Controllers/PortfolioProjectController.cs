using Microsoft.AspNetCore.Mvc;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioProjectDtos;
using Portfolio.DtoLayer.PortfolioDtos.ProjectImageDtos;
using Portfolio.WebUI.Services.ImageUploadServices.ImageUploadServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioProjectServices;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/PortfolioProject")]
    public class PortfolioProjectController : Controller
    {
        private readonly IPortfolioProjectService _portfolioProjectService;
        private readonly IImageUploadService _imageUploadService;

        public PortfolioProjectController(IPortfolioProjectService portfolioProjectService, IImageUploadService imageUploadService)
        {
            _portfolioProjectService = portfolioProjectService;
            _imageUploadService = imageUploadService;
        }

        [HttpGet]
        [Route("GetAllPortfolioProject")]
        public async Task<IActionResult> GetAllPortfolioProject()
        {
            var values = await _portfolioProjectService.GetAllPortfolioProjectAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreatePortfolioProject")]
        public IActionResult CreatePortfolioProject()
        {
            return View();
        }

        [HttpPost]
        [Route("CreatePortfolioProject")]
        public async Task<IActionResult> CreatePortfolioProject(CreatePortfolioProjectDto createPortfolioProjectDto, List<IFormFile> projectImages, IFormFile image)
        {
            var uploadingImages = await _imageUploadService.UploadManyImageAsync(projectImages);
            createPortfolioProjectDto.projectImages.AddRange(uploadingImages);


            var uploadingCoverImage = await _imageUploadService.UploadImageAsync(image);
            createPortfolioProjectDto.Image = uploadingCoverImage;

            await _portfolioProjectService.CreatePortfolioProjectAsync(createPortfolioProjectDto);
            return RedirectToAction("GetAllPortfolioProject", "PortfolioProject", new { area = "Admin" });
        }


        [HttpGet]
        [Route("UpdatePortfolioProject/{id}")]
        public async Task<IActionResult> UpdatePortfolioProject(int id)
        {
            var values = await _portfolioProjectService.GetAllPortfolioProjectByPortfolioProjectIdAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdatePortfolioProject/{id}")]
        public async Task<IActionResult> UpdatePortfolioProject(UpdatePortfolioProjectDto updatePortfolioProjectDto,List<IFormFile> projectImages, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                var uploadedImage = await _imageUploadService.UploadImageAsync(image);
                updatePortfolioProjectDto.Image = uploadedImage;
            }

            else
            {
                var existingData = await _portfolioProjectService.GetAllPortfolioProjectByPortfolioProjectIdAsync(updatePortfolioProjectDto.PortfolioProjectId);
                if (existingData != null)
                {
                    updatePortfolioProjectDto.Image = existingData.Image;
                }
            }


            if(projectImages != null)
            {
                var uploadedImages = await _imageUploadService.UpdateManyImageAsync(projectImages);
                updatePortfolioProjectDto.projectImages.AddRange(uploadedImages);
            }
            else
            {
                var existingData = await _portfolioProjectService.GetAllPortfolioProjectByPortfolioProjectIdAsync(updatePortfolioProjectDto.PortfolioProjectId);
                if(existingData != null)
                {
                    updatePortfolioProjectDto.projectImages = existingData.projectImages;
                }
            }

            await _portfolioProjectService.UpdatePortfolioProjectAsync(updatePortfolioProjectDto);
            return RedirectToAction("GetAllPortfolioProject", "PortfolioProject",new {area="Admin"});
        }

        [HttpDelete("{id}")]
        [Route("DeletePortfolioProject/{id}")]
        public async Task<IActionResult> DeletePortfolioProject(int id)
        {
            await _portfolioProjectService.DeletePortfolioProjectAsync(id);
            return RedirectToAction("GetAllPortfolioProject", "PortfolioProject", new { area = "Admin" });
        }
    }
}
