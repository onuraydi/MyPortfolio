using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.WebApi.Dtos.PortfolioBlogTagDtos;
using MyPortfolio.WebApi.Services.PortfolioBlogTagServices;

namespace MyPortfolio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioBlogTagsController : ControllerBase
    {
        private readonly IPortfolioBlogTagService _portfolioBlogTagService;

        public PortfolioBlogTagsController(IPortfolioBlogTagService portfolioBlogTagService)
        {
            _portfolioBlogTagService = portfolioBlogTagService;
        }

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

        [HttpGet("GetPortfolioBlogByPortfolioBlogTagId/{id}")]
        public async Task<IActionResult> GetPortfolioBlogByPortfolioBlogTagId(int id)
        {
            var values = await _portfolioBlogTagService.GetPortfolioBlogByPortfolioBlogTagIdAsync(id);
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
