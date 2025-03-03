using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.WebApi.Dtos.PortfolioTechnologyDtos;
using MyPortfolio.WebApi.Services.PortfolioTechnologyServices;

namespace MyPortfolio.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioTechnologiesController : ControllerBase
    {
        private readonly IPortfolioTechnologyService _portfolioTechnologyService;

        public PortfolioTechnologiesController(IPortfolioTechnologyService portfolioTechnologyService)
        {
            _portfolioTechnologyService = portfolioTechnologyService;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllPortfolioTechnology()
        {
            var values = await _portfolioTechnologyService.GetAllPortfolioTechnologyAsync();
            return Ok(values);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPortfolioTechnologyByPortfolioTechnologyId(int id)
        {
            var values = await _portfolioTechnologyService.GetPortfolioTechnologyByPortfolioTechnologyIdAsync(id);
            return Ok(values);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreatePortfolioTechnology(CreatePortfolioTechnologyDto createPortfolioTechnologyDto)
        {
            await _portfolioTechnologyService.CreatePortfolioTechnologyAsync(createPortfolioTechnologyDto);
            return Ok("Teknoloji başarıyla eklendi");
        }
       
        [HttpPut]
        public async Task<IActionResult> UpdatePortfolioTechnology(UpdatePortfolioTechnologyDto updatePortfolioTechnologyDto)
        {
            await _portfolioTechnologyService.UpdatePortfolioTechnologyAsync(updatePortfolioTechnologyDto);
            return Ok("Teknoloji başarıyla güncellendi");
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeletePortfolioTechnology(int id)
        {
            await _portfolioTechnologyService.DeletePortfolioTechnologyAsync(id);
            return Ok("Teknoloji başarıyla silindi");
        }
    }
}
