using Microsoft.AspNetCore.Authorization;
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
        // bu sayfada kullanılacak o yüzden authentication eklenmemeli
        [HttpGet]
        public async Task<IActionResult> GetAllPortfolioBlogTag()
        {
            var values = await _portfolioBlogTagService.GetAllPortfolioBlogTagAsync();
            return Ok(values);
        }

        //Olası Hata
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPortfolioBlogTagByPortfolioBlogTagId(int id)
        {
            var values = await _portfolioBlogTagService.GetPortfolioBlogTagByPortfolioBlogTagIdAsync(id);
            return Ok(values);
        }

        // taga göre blog getirme 
        [HttpGet("GetPortfolioBlogByPortfolioBlogTagId/{id}")]
        public async Task<IActionResult> GetPortfolioBlogByPortfolioBlogTagId(int id)
        {
            var values = await _portfolioBlogTagService.GetPortfolioBlogByPortfolioBlogTagIdAsync(id);
            return Ok(values);
        }

        // Blog'a ait tagları getirme
        [HttpGet("GetPortfolioBlogTagsByPortfolioBlogId/{id}")]
        public async Task<IActionResult> GetPortfolioBlogTagsByPortfolioBlogId(int id)
        {
            var values = await _portfolioBlogTagService.GetPortfolioBlogTagsByPortfolioBlogIdAsync(id);
            return Ok(values);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreatePortfolioBlogTag(CreatePortfolioBlogTagDto createPortfolioBlogTagDto)
        {
            await _portfolioBlogTagService.CreatePortfolioBlogTagAsync(createPortfolioBlogTagDto);
            return Ok("Tag ekleme başarılı");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdatePortfolioBlogTag(UpdatePortfolioBlogTagDto updatePortfolioBlogTagDto)
        {
            await _portfolioBlogTagService.UpdatePortfolioBlogTagAsync(updatePortfolioBlogTagDto);
            return Ok("Tag güncelleme başarılı");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeletePortfolioBlogTag(int id)
        {
            await _portfolioBlogTagService.DeletePortfolioBlogTagAsync(id);
            return Ok("Tag silme başarılı");
        }
    }
}
