using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.WebApi.Dtos.PortfolioContactDtos;
using MyPortfolio.WebApi.Services.PortfolioContactServices;

namespace MyPortfolio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioContactsController : ControllerBase
    {
        private readonly IPortfolioContactService _portfolioContactService;

        public PortfolioContactsController(IPortfolioContactService portfolioContactService)
        {
            _portfolioContactService = portfolioContactService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllPortfolioContact()
        {
            var values = await _portfolioContactService.GetAllPortfolioContactAsync();
            return Ok(values);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPortfolioContactByPortfolioContactId(int id)
        {
            var values = await _portfolioContactService.GetPortfolioContactByPortfolioContactAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePortfolioContact(CreatePortfolioContactDto createPortfolioContactDto)
        {
            await _portfolioContactService.CreatePortfolioContactAsync(createPortfolioContactDto);
            return Ok("İletişim ekleme işlemi başarılı");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdatePortfolioContact(UpdatePortfolioContactDto updatePortfolioContactDto)
        {
            await _portfolioContactService.UpdatePortfolioContactAsync(updatePortfolioContactDto);
            return Ok("İletişim güncelleme işlemi başarılı");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeletePortfolioContact(int id)
        {
            await _portfolioContactService.DeletePortfolioContactAsync(id);
            return Ok("İletişim silme işlemi başarılı");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("MarkAsRead/{id}")]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            await _portfolioContactService.MarkAsRead(id);
            return Ok("Okundu olarak işaretlendi");
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("MarkAsNotRead/{id}")]
        public async Task<IActionResult> MarkAsNotRead(int id)
        {
            await _portfolioContactService.MarkAsNotRead(id);
            return Ok("Okunmadı olarak işaretlendi");
        }
    }
}
