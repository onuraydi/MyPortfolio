using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.WebApi.Dtos.PortfolioCertificateDtos;
using MyPortfolio.WebApi.Services.PortfolioCertificateServices;

namespace MyPortfolio.WebApi.Controllers
{
    [Authorize(Policy = "ResourcePortfolioAdmin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioCertificatesController : ControllerBase
    {
        private readonly IPortfolioCertificateService _portfolioCertificateService;

        public PortfolioCertificatesController(IPortfolioCertificateService portfolioCertificateService)
        {
            _portfolioCertificateService = portfolioCertificateService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllPortfolioCertificate()
        {
            var values = await _portfolioCertificateService.GetAllPortfolioCertificateAsync();
            return Ok(values);
        }

        // Ana sayfada sertifikanın detayına gitme gibi birşey olursa buradan hata çıkar
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPortfolioCertificateByPortfolioCertificateId(int id)
        {
            var values = await _portfolioCertificateService.GetPortfolioCertificateByPortfolioCertificateIdAsync(id);
            return Ok(values);
        }

        
        [HttpPost]
        public async Task<IActionResult> CreatePortfolioCertificate(CreatePortfolioCertificateDto createPortfolioCertificateDto)
        {
            await _portfolioCertificateService.CreatePortfolioCertificateAsync(createPortfolioCertificateDto);
            return Ok("Sertifika başarıyla eklendi");
        }

        
        [HttpPut]
        public async Task<IActionResult> UpdatePortfolioCertificate(UpdatePortfolioCertificateDto updatePortfolioCertificateDto)
        {
            await _portfolioCertificateService.UpdatePortfolioCertificateAsync(updatePortfolioCertificateDto);
            return Ok("Sertifika başarıyla güncellendi");
        }

        
        [HttpDelete]
        public async Task<IActionResult> DeletePortfolioCertificate(int id)
        {
            await _portfolioCertificateService.DeletePortfolioCertificateAsync(id);
            return Ok("Sertifika başarıyla silindi");
        }
    }
}
