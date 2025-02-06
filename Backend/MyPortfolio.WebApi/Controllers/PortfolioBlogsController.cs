using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.WebApi.Dtos.PortfolioBlogDtos;
using MyPortfolio.WebApi.Services.PortfolioBlogServices;

namespace MyPortfolio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioBlogsController : ControllerBase
    {
        private readonly IPortfolioBlogService _portfolioBlogService;

        public PortfolioBlogsController(IPortfolioBlogService portfolioBlogService)
        {
            _portfolioBlogService = portfolioBlogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPortfolioBlog(string query = "")
        {
            var values = await _portfolioBlogService.GetAllPortfolioBlogAsync(query);
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPortfolioBlogByPortfolioBlogId(int id)
        {
            var values = await _portfolioBlogService.GetPortfolioBlogByPortfolioBlogIdAsync(id);
            return Ok(values);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreatePortfolioBlog([FromBody] CreatePortfolioBlogDto createPortfolioBlogDto)
        {
            var values = await _portfolioBlogService.CreatePortfolioBlogAsync(createPortfolioBlogDto);
            return Ok(values);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdatePortfolioBlog(UpdatePortfolioBlogDto updatePortfolioBlogDto)
        {
            await _portfolioBlogService.UpdatePortfolioBlogAsync(updatePortfolioBlogDto);
            return Ok("Blog güncelleme işlemi başarılı");
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeletePortfolioBlog(int id)
        {
            await _portfolioBlogService.DeletePortfolioBlogAsync(id);
            return Ok("Blog silme işlemi başarılı");
        }
    }
}
