using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.WebApi.Dtos.PortfolioAboutMeDtos;
using MyPortfolio.WebApi.Services.PortfolioAboutMeServices;

namespace MyPortfolio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioAboutMeApiController : ControllerBase
    {
        private readonly IPortfolioAboutMeService _portfolioAboutMeService;

        public PortfolioAboutMeApiController(IPortfolioAboutMeService portfolioAboutMeService)
        {
            _portfolioAboutMeService = portfolioAboutMeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPortfolioAboutMe()
        {
            var values = await _portfolioAboutMeService.GetPortfolioAboutMeAsync();
            return Ok(values);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePortfolioAboutMe(UpdatePortfolioAboutMeDto updatePortfolioAboutMeDto)
        {
            await _portfolioAboutMeService.UpdatePortfolioAboutMeAsync(updatePortfolioAboutMeDto);
            return Ok("Hakkımda kısmı güncelleme işlemi başarılı");
        }
    }
}
