using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.WebApi.Dtos.PortfolioBlogCommentDtos;
using MyPortfolio.WebApi.Services.PortfolioBlogCommentServices;

namespace MyPortfolio.WebApi.Controllers
{
    [Authorize(Policy = "ResourcePortfolioAdmin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioBlogCommentsController : ControllerBase
    {
        private readonly IPortfolioBlogCommentService _portfolioBlogCommentService;

        public PortfolioBlogCommentsController(IPortfolioBlogCommentService portfolioBlogCommentService)
        {
            _portfolioBlogCommentService = portfolioBlogCommentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPortfolioBlogComment()
        {
            var values = await _portfolioBlogCommentService.GetAllPortfolioBlogCommentAsync();
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPortfolioBlogCommentByPortfolioBlogCommentId(int id)
        {
            var values = await _portfolioBlogCommentService.GetPortfolioBlogCommentByPortfolioBlogCommentIdAsync(id);
            return Ok(values);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreatePortfolioBlogComment(CreatePortfolioBlogCommentDto createPortfolioBlogCommentDto)
        {
            createPortfolioBlogCommentDto.CommentDate = Convert.ToDateTime(DateTime.Now.ToString("dd MMMM yyyy HH:mm"));
            var values = await _portfolioBlogCommentService.CreatePortfolioBlogCommentAsync(createPortfolioBlogCommentDto);
            return Ok(values);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePortfolioBlogComment(int id)
        {
            await _portfolioBlogCommentService.DeletePortfolioBlogCommentAsync(id);
            return Ok("Yorum silme işlemi başarılı");
        }
        // Bloğa göre yorum getirme
        [AllowAnonymous]
        [HttpGet("GetPortfolioBlogCommentByPortfolioBlogId/{id}")]
        public async Task<IActionResult> GetPortfolioBlogCommentByPortfolioBlogId(int id)
        {
            var values = await _portfolioBlogCommentService.GetPortfolioBlogCommentByPortfolioBlogIdAsync(id);
            return Ok(values);
        }
    }
}
