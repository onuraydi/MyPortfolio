using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.WebApi.Dtos.PortfolioBlogDtos;
using MyPortfolio.WebApi.Services.PortfolioBlogServices;

namespace MyPortfolio.WebApi.Controllers
{
    [Authorize]
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
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPortfolioBlog(string query = "")
        {
            var values = await _portfolioBlogService.GetAllPortfolioBlogAsync(query);
            return Ok(values);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPortfolioBlogByPortfolioBlogId(int id)
        {
            var values = await _portfolioBlogService.GetPortfolioBlogByPortfolioBlogIdAsync(id);
            return Ok(values);
        }

        [HttpGet("GetBlogByCategory/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetBlogByCategory(int id)
        {
            var values = await _portfolioBlogService.GetBlogByCategory(id);
            return Ok(values);
        }

        [HttpGet("GetBlogByTag/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetblogByTag(int id)
        {
            var values = await _portfolioBlogService.GetBlogByTag(id);
            return Ok(values);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreatePortfolioBlog([FromBody] CreatePortfolioBlogDto createPortfolioBlogDto)
        {
            var values = await _portfolioBlogService.CreatePortfolioBlogAsync(createPortfolioBlogDto);
            return Ok(values);
        }

        [HttpGet("MarkSuggested/{id}")]
        public async Task<IActionResult> MarkSuggested(int id)
        {
            await _portfolioBlogService.MarkSuggested(id);
            return Ok("Önerilme durumu değiştirildi");
        }

        [AllowAnonymous]
        [HttpGet("GetSuggestedPortfolioBlog")]
        public async Task<IActionResult> GetSuggestedPortfolioBlog()
        {
            var values = await _portfolioBlogService.GetSuggestedPortfolioBlog();
            return Ok(values);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePortfolioBlog(UpdatePortfolioBlogDto updatePortfolioBlogDto)
        {
            await _portfolioBlogService.UpdatePortfolioBlogAsync(updatePortfolioBlogDto);
            return Ok("Blog güncelleme işlemi başarılı");
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeletePortfolioBlog(int id)
        {
            await _portfolioBlogService.DeletePortfolioBlogAsync(id);
            return Ok("Blog silme işlemi başarılı");
        }
    }
}
