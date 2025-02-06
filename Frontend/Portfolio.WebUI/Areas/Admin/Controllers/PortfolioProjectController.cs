using Microsoft.AspNetCore.Mvc;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioProjectDtos;
using Portfolio.DtoLayer.PortfolioDtos.ProjectImageDtos;
using Portfolio.WebUI.Services.ImageUploadServices.ImageUploadServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioProjectServices;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/PortfolioProject")]
    public class PortfolioProjectController : AdminBaseController
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
        public async Task<IActionResult> UpdatePortfolioProject(UpdatePortfolioProjectDto updatePortfolioProjectDto, IFormFile image)
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
            await _portfolioProjectService.UpdatePortfolioProjectAsync(updatePortfolioProjectDto);
            return RedirectToAction("GetAllPortfolioProject", "PortfolioProject", new { area = "Admin" });
        }

        
        [HttpGet]
        [Route("UpdateProjectImages/{id}")]
        public async Task<IActionResult> UpdateProjectImages(int id)
        {
            var values = await _portfolioProjectService.GetProjectImageByPortfolioProjectIdAsync(id);
            ViewBag.projectid = id;
            return View(values);
        }


        [HttpPost]
        [Route("UpdateProjectImages/{id}")]
        public async Task<IActionResult> UpdateProjectImages(GetProjectImageByPortfolioProjectIdDto updateProjectImageDto, IFormFile projectImages, int ProjectImageId, int PortfolioProjectId)
        {
            if (projectImages != null && projectImages.Length > 0)
            {
                var uploadedImages = await _imageUploadService.UpdateManyImageAsync(projectImages);
                uploadedImages.PortfolioProjectId = PortfolioProjectId;
                uploadedImages.ProjectImageId = ProjectImageId;
                updateProjectImageDto = uploadedImages;
            }
            await _portfolioProjectService.UpdateProjectImageAsync(updateProjectImageDto);
            return RedirectToAction("UpdateProjectImages", "PortfolioProject", new { area = "Admin" });

            //else
            //{
            //    var existingData = await _portfolioProjectService.GetAllPortfolioProjectByPortfolioProjectIdAsync(updateProjectImageDto.PortfolioProjectId);
            //    if (existingData != null)
            //    {
            //        updatePortfolioProjectDto.projectImages = existingData.projectImages;
            //    }
            //}
        }

        [HttpDelete("PortfolioProject/{id}")]
        [Route("DeletePortfolioProject/{id}")]
        public async Task<IActionResult> DeletePortfolioProject(int id)
        {
            await _portfolioProjectService.DeletePortfolioProjectAsync(id);
            return RedirectToAction("GetAllPortfolioProject", "PortfolioProject", new { area = "Admin" });
        }

        [HttpDelete("ProjectImage/{id}")]
        [Route("DeleteProjectImage/{id}")]
        public async Task<IActionResult> DeleteProjectImage(int id)
        {
            await _portfolioProjectService.DeleteProjectImagesByProjectImageIdAsync(id); 
            return RedirectToAction("UpdateProjectImages", "PortfolioProject", new { area = "Admin" });
        }

    }
}
