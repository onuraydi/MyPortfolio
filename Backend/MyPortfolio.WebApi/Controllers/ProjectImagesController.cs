using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.WebApi.Dtos.ProjectImageDtos;
using MyPortfolio.WebApi.Services.ProjectImageServices;

namespace MyPortfolio.WebApi.Controllers
{
    [Authorize(Policy = "ResourcePortfolioAdmin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectImagesController : ControllerBase
    {
        private readonly IProjectImageService _projectImageService;

        public ProjectImagesController(IProjectImageService projectImageService)
        {
            _projectImageService = projectImageService;
        }


        // buradan bir hata gelebilir.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectImagesByPortfolioProjectId(int id)
        {
            var values = await _projectImageService.GetProjectImagesByPortfolioProjectIdAsync(id);
            return Ok(values);
        }
     
        [HttpDelete]
        public async Task<IActionResult> DeleteProjectImagesByProjectImageId(int id)
        {
            await _projectImageService.DeleteProjectImageByProjectImageIdAsync(id);
            return Ok("Resmi silme işlemi başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProjectImage(UpdateProjectImageDto updateProjectImageDto)
        {
            await _projectImageService.UpdateProjectImageAsync(updateProjectImageDto);
            return Ok("Resmi güncelleme işlemi başarılı");
        }
    }
}
