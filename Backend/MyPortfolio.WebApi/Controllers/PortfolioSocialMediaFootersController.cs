using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.WebApi.Dtos.PortfolioSocialMediaFooter;
using MyPortfolio.WebApi.Services.PortfolioSocialMediaFooterServices;

namespace MyPortfolio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioSocialMediaFootersController : ControllerBase
    {
        private readonly IPortfolioSocialMediaFooterService _portfolioSocialMediaFooterService;

        public PortfolioSocialMediaFootersController(IPortfolioSocialMediaFooterService portfolioSocialMediaFooterService)
        {
            _portfolioSocialMediaFooterService = portfolioSocialMediaFooterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPortfolioSocialMediaFooter()
        {
            var values = await _portfolioSocialMediaFooterService.GetAllPortfolioSocialMediaFooterAsync();
            return Ok(values);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPortfolioSocialMediaFooterById(int id)
        {
            var values = await _portfolioSocialMediaFooterService.GetPortfolioSocialMediaFooterByIdAsync(id);
            return Ok(values);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreatePortfolioSocialMediaFooter(CreatePortfolioSocialMediaFooterDto createPortfolioSocialMediaFooterDto)
        {
            await _portfolioSocialMediaFooterService.CreatePortfolioSocialMediaFooterAsync(createPortfolioSocialMediaFooterDto);
            return Ok("Ekleme işlemi başarılı");
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdatePortfolioSocialMediaFooter(UpdatePortfolioSocialMediaFooterDto updatePortfolioSocialMediaFooterDto)
        {
            await _portfolioSocialMediaFooterService.UpdatePortfolioSocialMediaFooterAsync(updatePortfolioSocialMediaFooterDto);
            return Ok("Güncelleme işlemi başarılı");
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeletePortfolioSocialMediaFooter(int id)
        {
            await _portfolioSocialMediaFooterService.DeletePortfolioSocialMediaFooterAsync(id);
            return Ok("Silme işlemi başarılı");
        }
    }
}
