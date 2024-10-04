using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.WebApi.Dtos.PortfolioExperienceDtos;
using MyPortfolio.WebApi.Services.PortfolioExperienceServices;

namespace MyPortfolio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioExperiencesController : ControllerBase
    {
        private readonly IPortfolioExperienceService _portfolioExperienceService;

        public PortfolioExperiencesController(IPortfolioExperienceService portfolioExperienceService)
        {
            _portfolioExperienceService = portfolioExperienceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPortfolioExperience()
        {
            var values = await _portfolioExperienceService.GetAllPortfolioExperienceAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPortfolioExperienceByPortfolioExperienceId(int id)
        {
            var values = await _portfolioExperienceService.GetPortfolioExperienceByportfolioExperienceIdAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePortfolioExperience(CreatePortfolioExperienceDto createPortfolioExperienceDto)
        {
            await _portfolioExperienceService.CreatePortfolioExperienceAsync(createPortfolioExperienceDto);
            return Ok("İş tecrübesi başarıyla eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePortfolioExperience(UpdatePortfolioExperienceDto updatePortfolioExperienceDto)
        {
            await _portfolioExperienceService.UpdatePortfolioExperienceAsync(updatePortfolioExperienceDto);
            return Ok("İş tecrübesi başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePortfolioExperience(int id)
        {
            await _portfolioExperienceService.DeletePortfolioExperienceAsync(id);
            return Ok("İş tecrübesi başarıyla silindi");
        }
    }
}
