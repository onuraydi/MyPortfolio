using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.WebApi.Dtos.PortfolioSocialMediaFooter;
using MyPortfolio.WebApi.Services.PortfolioSocialMediaFooterServices;

namespace MyPortfolio.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioSocialMediaFootersController : ControllerBase
    {
        private readonly IPortfolioSocialMediaFooterService _portfolioSocialMediaFooterService;

        public PortfolioSocialMediaFootersController(IPortfolioSocialMediaFooterService portfolioSocialMediaFooterService)
        {
            _portfolioSocialMediaFooterService = portfolioSocialMediaFooterService;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllPortfolioSocialMediaFooter()
        {
            var values = await _portfolioSocialMediaFooterService.GetAllPortfolioSocialMediaFooterAsync();
            return Ok(values);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPortfolioSocialMediaFooterById(int id)
        {
            var values = await _portfolioSocialMediaFooterService.GetPortfolioSocialMediaFooterByIdAsync(id);
            return Ok(values);
        }
    
        [HttpPost]
        public async Task<IActionResult> CreatePortfolioSocialMediaFooter(CreatePortfolioSocialMediaFooterDto createPortfolioSocialMediaFooterDto)
        {
            await _portfolioSocialMediaFooterService.CreatePortfolioSocialMediaFooterAsync(createPortfolioSocialMediaFooterDto);
            return Ok("Ekleme işlemi başarılı");
        }
 
        [HttpPut]
        public async Task<IActionResult> UpdatePortfolioSocialMediaFooter(UpdatePortfolioSocialMediaFooterDto updatePortfolioSocialMediaFooterDto)
        {
            await _portfolioSocialMediaFooterService.UpdatePortfolioSocialMediaFooterAsync(updatePortfolioSocialMediaFooterDto);
            return Ok("Güncelleme işlemi başarılı");
        }
   
        [HttpDelete]
        public async Task<IActionResult> DeletePortfolioSocialMediaFooter(int id)
        {
            await _portfolioSocialMediaFooterService.DeletePortfolioSocialMediaFooterAsync(id);
            return Ok("Silme işlemi başarılı");
        }
    }
}
