using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.WebApi.Dtos.PortfolioExperienceDtos;
using MyPortfolio.WebApi.Services.PortfolioExperienceServices;

namespace MyPortfolio.WebApi.Controllers
{
    [Authorize(Policy = "ResourcePortfolioAdmin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioExperiencesController : ControllerBase
    {
        private readonly IPortfolioExperienceService _portfolioExperienceService;

        public PortfolioExperiencesController(IPortfolioExperienceService portfolioExperienceService)
        {
            _portfolioExperienceService = portfolioExperienceService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllPortfolioExperience()
        {
            var values = await _portfolioExperienceService.GetAllPortfolioExperienceAsync();
            return Ok(values);
        }


        // Ana sayfada Tecrübelerin detayına gitme gibi bir durum olursa buradan hata verir
        
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
