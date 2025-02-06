using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using MyPortfolio.WebApi.Dtos.PortfolioRoutingFooterDtos;
using MyPortfolio.WebApi.Services.PortfolioRoutingFooterServices;

namespace MyPortfolio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioRoutingFootersController : ControllerBase
    {
        private readonly IPortfolioRoutingFooterService _portfolioRoutingFooterService;

        public PortfolioRoutingFootersController(IPortfolioRoutingFooterService portfolioRoutingFooterService)
        {
            _portfolioRoutingFooterService = portfolioRoutingFooterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPortfolioRoutingFooter()
        {
            var values = await _portfolioRoutingFooterService.GetAllPortfolioRoutingFooterAsync();
            return Ok(values);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPortfolioRoutingFooterByPortfolioRoutingFooterId(int id)
        {
            var values = await _portfolioRoutingFooterService.GetPortfolioRoutingFooterByPortfolioRoutingFooterIdAsync(id);
            return Ok(values);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreatePortfolioRoutingFooter(CreatePortfolioRoutingFooterDto createPortfolioRoutingFooterDto)
        {
            await _portfolioRoutingFooterService.CreatePortfolioRoutingFooterAsync(createPortfolioRoutingFooterDto);
            return Ok("Ekleme işlemi Başarılı");
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdatePortfolioRoutingFooter(UpdatePortfolioRoutingFooterDto updatePortfolioRoutingFooterDto)
        {
            await _portfolioRoutingFooterService.UpdatePortfolioRoutingFooterAsync(updatePortfolioRoutingFooterDto);
            return Ok("Güncelleme işlemi başarılı");
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeletePortfolioRoutingFooter(int id)
        {
            await _portfolioRoutingFooterService.DeletePortfolioRoutingFooterAsync(id);
            return Ok("Silme işlemi başarılı");
        }
    }
}
