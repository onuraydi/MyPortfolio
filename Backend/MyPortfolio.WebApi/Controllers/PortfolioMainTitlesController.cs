using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.WebApi.Dtos.PortfolioMainTitleDtos;
using MyPortfolio.WebApi.Services.PortfolioMainTitleServices;

namespace MyPortfolio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioMainTitlesController : ControllerBase
    {
        private readonly IPortfolioMainTitleService _portfolioMainTitleService;

        public PortfolioMainTitlesController(IPortfolioMainTitleService portfolioMainTitleService)
        {
            _portfolioMainTitleService = portfolioMainTitleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPortfolioMainTitle()
        {
            var values = await _portfolioMainTitleService.GetPortfolioMainTitleAsync();
            return Ok(values);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPortfolioMainTitleByPortfolioMainTitleId(int id)
        {
            var values = await _portfolioMainTitleService.GetPortfolioMainTitleByPortfolioMainTitleIdAsync(id);
            return Ok(values);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdatePortfolioMainTitle(UpdatePortfoiloMainTitleDto updatePortfoiloMainTitleDto)
        {
            await _portfolioMainTitleService.UpdatePortfolioMainTitleAsync(updatePortfoiloMainTitleDto);
            return Ok("Ana başlığı güncelleme işlemi başarılı");
        }
    }
}
