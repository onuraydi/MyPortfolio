using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.WebApi.Dtos.PortfolioProjectDtos;
using MyPortfolio.WebApi.Dtos.ProjectImageDtos;
using MyPortfolio.WebApi.Services.PortfolioProjectServices;

namespace MyPortfolio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioProjectsController : ControllerBase
    {
        private readonly IPortfolioProjectService _portfolioProjectService;

        public PortfolioProjectsController(IPortfolioProjectService portfolioProjectService)
        {
            _portfolioProjectService = portfolioProjectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPortfolioProject()
        {
            var values = await _portfolioProjectService.GetAllPortfolioProjectAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPortfolioProjectByPortfolioProjectId(int id)
        {
            var values = await _portfolioProjectService.GetAllPortfolioProjectByPortfolioProjectIdAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePortfolioProject(CreatePortfolioProjectDto createPortfolioProjectDto,CreateProjectImageDto createProjectImageDto)
        {
            await _portfolioProjectService.CreatePortfolioProjectAsync(createPortfolioProjectDto);
            return Ok("Proje başarıyla eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePortfolioProject(UpdatePortfolioProjectDto updatePortfolioProjectDto)
        {
            await _portfolioProjectService.UpdatePortfolioProjectAsync(updatePortfolioProjectDto);
            return Ok("Proje başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePortfolioProject(int id)
        {
            await _portfolioProjectService.DeletePortfolioProjectAsync(id);
            return Ok("Proje başarıyla silindi");
        }
    }
}
