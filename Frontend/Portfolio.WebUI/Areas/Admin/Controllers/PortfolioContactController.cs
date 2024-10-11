using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioContactServices;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/PortfolioContact")]
    public class PortfolioContactController : Controller
    {
        private readonly IPortfolioContactService _portfolioContactService;

        public PortfolioContactController(IPortfolioContactService portfolioContactService)
        {
            _portfolioContactService = portfolioContactService;
        }

        [HttpGet]
        [Route("GetAllPortfolioContact")]
        public async Task<IActionResult> GetAllPortfolioContact()
        {
            var values = await _portfolioContactService.GetAllPortfolioContactAsync();
            return View(values);
        }

        [HttpDelete("{id}")]
        [Route("DeletePortfolioContact/{id}")]
        public async Task<IActionResult> DeletePortfolioContact(int id)
        {
            await _portfolioContactService.DeletePortfolioContactAsync(id);
            return RedirectToAction("GetAllPortfolioContact", "PortfolioContact",new {area = "Admin"});
        }

        [HttpGet("{id}")]
        [Route("GetByIdPortfolioContact/{id}")]
        public async Task<IActionResult> GetByIdPortfolioContact(int id)
        {
            var values = await _portfolioContactService.GetPortfolioContactByPortfolioContactIdAsync(id);
            return View(values);
        }

        [HttpPost("{id}/MarkAsRead")]
        [Route("MarkAsRead/{id}")]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            await _portfolioContactService.MarkAsRead(id);
            return RedirectToAction("GetAllPortfolioContact", "PortfolioContact", new { area = "Admin" });
        }

        [HttpPost("{id}/MarkAsNotRead")]
        [Route("MarkAsNotRead/{id}")]
        public async Task<IActionResult> MarkasNotRead(int id)
        {
            await _portfolioContactService.MarkAsNotRead(id);
            return RedirectToAction("GetAllPortfolioContact", "PortfolioContact", new { area = "Admin" });
        }
    }
}
