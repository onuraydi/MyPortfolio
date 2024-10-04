using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.WebApi.Dtos.PortfolioSkillDtos;
using MyPortfolio.WebApi.Services.PortfolioSkillServices;

namespace MyPortfolio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioSkillsController : ControllerBase
    {
        private readonly IPortfolioSkillService _portfolioSkillService;

        public PortfolioSkillsController(IPortfolioSkillService portfolioSkillService)
        {
            _portfolioSkillService = portfolioSkillService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPortfolioSkill()
        {
            var values = await _portfolioSkillService.GetAllPortfolioSkillAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPortfolioSkillBySkillId(int id)
        {
            var values = await _portfolioSkillService.GetPortfolioSkillBySkillIdAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePortfolioSkill(CreatePortfolioSkillDto createPortfolioSkillDto)
        {
            await _portfolioSkillService.CreatePortfolioSkillAsync(createPortfolioSkillDto);
            return Ok("Yetenek başarıyla eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePortfolioSkill(UpdatePortfolioSkillDto updatePortfolioSkillDto)
        {
            await _portfolioSkillService.UpdatePortfolioSkillAsync(updatePortfolioSkillDto);
            return Ok("Yetenek başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePortfolioSkill(int id)
        {
            await _portfolioSkillService.DeletePortfolioSkillAsync(id);
            return Ok("Yetenel başarıyla silindi");
        }
    }
}
