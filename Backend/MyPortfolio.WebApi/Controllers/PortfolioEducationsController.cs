using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.WebApi.Dtos.PortfolioEducationDtos;
using MyPortfolio.WebApi.Services.PortfolioEducationServices;


namespace MyPortfolio.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioEducationsController : ControllerBase
    {
        private readonly IPortfolioEducationService _portfolioEducationService;

        public PortfolioEducationsController(IPortfolioEducationService portfolioEducationService)
        {
            _portfolioEducationService = portfolioEducationService;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllPortfolioEducation()
        {
            var values = await _portfolioEducationService.GetAllPortfolioEducationAsync();
            return Ok(values);
        }

        // Ana sayfada eğitim detayına gitme gibi bir olay olursa bu kısımdan olası hata çıkar allow ekle
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPortfolioEducationByPortfolioEducationId(int id)
        {
            var values = await _portfolioEducationService.GetPortfolioEducationByPortfolioEducationIdAsync(id);
            return Ok(values);
        }

        
        [HttpPost]
        public async Task<IActionResult> CreatePortfolioEducation(CreatePortfolioEducationDto createPortfolioEducationDto)
        {
            await _portfolioEducationService.CreatePortfolioEducationAsync(createPortfolioEducationDto);
            return Ok("Eğitim başarıyla eklendi");
        }

        
        [HttpPut]
        public async Task<IActionResult> UpdatePortfolioEducation(UpdatePortfolioEducationDto updatePortfolioEducationDto)
        {
            await _portfolioEducationService.UpdatePortfolioEducationAsync(updatePortfolioEducationDto);
            return Ok("Eğitim başarıyla güncellendi");
        }

        
        [HttpDelete]
        public async Task<IActionResult> DeletePortfolioEducation(int id)
        {
            await _portfolioEducationService.DeletePortfolioEducationAsync(id);
            return Ok("Eğitim başarıyla silindi");
        }
    }
}
