using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.WebApi.Dtos.PortfolioEducationDtos;
using MyPortfolio.WebApi.Services.PortfolioEducationServices;


namespace MyPortfolio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioEducationsController : ControllerBase
    {
        private readonly IPortfolioEducationService _portfolioEducationService;

        public PortfolioEducationsController(IPortfolioEducationService portfolioEducationService)
        {
            _portfolioEducationService = portfolioEducationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPortfolioEducation()
        {
            var values = await _portfolioEducationService.GetAllPortfolioEducationAsync();
            return Ok(values);
        }

        // Ana sayfada eğitim detayına gitme gibi bir olay olursa bu kısımdan olası hata çıkar
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPortfolioEducationByPortfolioEducationId(int id)
        {
            var values = await _portfolioEducationService.GetPortfolioEducationByPortfolioEducationIdAsync(id);
            return Ok(values);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreatePortfolioEducation(CreatePortfolioEducationDto createPortfolioEducationDto)
        {
            await _portfolioEducationService.CreatePortfolioEducationAsync(createPortfolioEducationDto);
            return Ok("Eğitim başarıyla eklendi");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdatePortfolioEducation(UpdatePortfolioEducationDto updatePortfolioEducationDto)
        {
            await _portfolioEducationService.UpdatePortfolioEducationAsync(updatePortfolioEducationDto);
            return Ok("Eğitim başarıyla güncellendi");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeletePortfolioEducation(int id)
        {
            await _portfolioEducationService.DeletePortfolioEducationAsync(id);
            return Ok("Eğitim başarıyla silindi");
        }
    }
}
