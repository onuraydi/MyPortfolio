using Microsoft.AspNetCore.Authorization;
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

        // proje detayına gitme gibi bir durum olursa buradan hata verir
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPortfolioProjectByPortfolioProjectId(int id)
        {
            var values = await _portfolioProjectService.GetAllPortfolioProjectByPortfolioProjectIdAsync(id);
            return Ok(values);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreatePortfolioProject(CreatePortfolioProjectDto createPortfolioProjectDto )
        {
            await _portfolioProjectService.CreatePortfolioProjectAsync(createPortfolioProjectDto);
            return Ok("Proje başarıyla eklendi");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdatePortfolioProject(UpdatePortfolioProjectDto updatePortfolioProjectDto )
        {
            await _portfolioProjectService.UpdatePortfolioProjectAsync(updatePortfolioProjectDto);
            return Ok("Proje başarıyla güncellendi");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeletePortfolioProject(int id)
        {
            await _portfolioProjectService.DeletePortfolioProjectAsync(id);
            return Ok("Proje başarıyla silindi");
        }
    }
}
