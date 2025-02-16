using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.WebApi.Dtos.PortfolioBlogTagDtos;
using MyPortfolio.WebApi.Services.PortfolioBlogTagServices;

namespace MyPortfolio.WebApi.Controllers
{
    [Authorize(Policy = "ResourcePortfolioAdmin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioBlogTagsController : ControllerBase
    {
        private readonly IPortfolioBlogTagService _portfolioBlogTagService;

        public PortfolioBlogTagsController(IPortfolioBlogTagService portfolioBlogTagService)
        {
            _portfolioBlogTagService = portfolioBlogTagService;
        }
        // bu sayfada kullanılacak o yüzden authentication eklenmemeli
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllPortfolioBlogTag()
        {
            var values = await _portfolioBlogTagService.GetAllPortfolioBlogTagAsync();
            return Ok(values);
        }

        
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPortfolioBlogTagByPortfolioBlogTagId(int id)
        {
            var values = await _portfolioBlogTagService.GetPortfolioBlogTagByPortfolioBlogTagIdAsync(id);
            return Ok(values);
        }

        // taga göre blog getirme 
        [AllowAnonymous]
        [HttpGet("GetPortfolioBlogByPortfolioBlogTagId/{id}")]
        public async Task<IActionResult> GetPortfolioBlogByPortfolioBlogTagId(int id)
        {
            var values = await _portfolioBlogTagService.GetPortfolioBlogByPortfolioBlogTagIdAsync(id);
            return Ok(values);
        }

        // Blog'a ait tagları getirme
        [AllowAnonymous]
        [HttpGet("GetPortfolioBlogTagsByPortfolioBlogId/{id}")]
        public async Task<IActionResult> GetPortfolioBlogTagsByPortfolioBlogId(int id)
        {
            var values = await _portfolioBlogTagService.GetPortfolioBlogTagsByPortfolioBlogIdAsync(id);
            return Ok(values);
        }

        
        [HttpPost]
        public async Task<IActionResult> CreatePortfolioBlogTag(CreatePortfolioBlogTagDto createPortfolioBlogTagDto)
        {
            await _portfolioBlogTagService.CreatePortfolioBlogTagAsync(createPortfolioBlogTagDto);
            return Ok("Tag ekleme başarılı");
        }

        
        [HttpPut]
        public async Task<IActionResult> UpdatePortfolioBlogTag(UpdatePortfolioBlogTagDto updatePortfolioBlogTagDto)
        {
            await _portfolioBlogTagService.UpdatePortfolioBlogTagAsync(updatePortfolioBlogTagDto);
            return Ok("Tag güncelleme başarılı");
        }

        
        [HttpDelete]
        public async Task<IActionResult> DeletePortfolioBlogTag(int id)
        {
            await _portfolioBlogTagService.DeletePortfolioBlogTagAsync(id);
            return Ok("Tag silme başarılı");
        }
    }
}
