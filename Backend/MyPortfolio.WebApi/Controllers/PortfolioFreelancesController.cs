using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.WebApi.Dtos.PortfolioFreelanceDtos;
using MyPortfolio.WebApi.Services.PorfolioFreelanceServices;

namespace MyPortfolio.WebApi.Controllers
{
    [Authorize(Policy = "ResourcePortfolioAdmin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioFreelancesController : ControllerBase
    {
        private readonly IPortfolioFreelanceService _portfolioFreelanceService;

        public PortfolioFreelancesController(IPortfolioFreelanceService portfolioFreelanceService)
        {
            _portfolioFreelanceService = portfolioFreelanceService;
        }


        //genel olarak Olası hata


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllPortfolioFreelance()
        {
            var values = await _portfolioFreelanceService.GetAllPortfolioFreelanceAsync();
            return Ok(values);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPortfolioFreelanceByPortfolioFreelanceId(int id)
        {
            var values = await _portfolioFreelanceService.GetPortfolioFreelanceByPortfolioFreelanceIdAsync(id);
            return Ok(values);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreatePortfolioFreelance(CreatePortfolioFreelanceDto createPortfolioFreelanceDto)
        {
            await _portfolioFreelanceService.CreatePortfolioFreelanceAsync(createPortfolioFreelanceDto);
            return Ok("Ekleme işlemi başarılı");
        }

        
        [HttpPut]
        public async Task<IActionResult> UpdatePortfolioFreelance(UpdatePortfolioFreelanceDto updatePortfolioFreelanceDto)
        {
            await _portfolioFreelanceService.UpdatePortfolioFreelanceAsync(updatePortfolioFreelanceDto);
            return Ok("Güncelleme işlemi başarılı");
        }

        
        [HttpDelete]
        public async Task<IActionResult> DeletePortfolioFreelance(int id)
        {
            await _portfolioFreelanceService.DeletePortfolioFreelanceAsync(id);
            return Ok("Silme işlemi başarılı");
        }

    }
}
