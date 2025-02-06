using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogCommentServices;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/PortfolioBlogComment")]
    public class PortfolioBlogCommentController : AdminBaseController
    {
        private readonly IPortfolioBlogCommentService _portfolioBlogCommentService;

        public PortfolioBlogCommentController(IPortfolioBlogCommentService portfolioBlogCommentService)
        {
            _portfolioBlogCommentService = portfolioBlogCommentService;
        }

        [HttpGet]
        [Route("GetAllPortfolioBlogComment")]
        public async Task<IActionResult> GetAllPortfolioBlogComment()
        {
            var values = await _portfolioBlogCommentService.GetAllPortfolioBlogCommentAsync();
            return View(values);
        }

        [HttpDelete("{id}")]
        [Route("DeletePortfolioBlogComment/{id}")]
        public async Task<IActionResult> DeleltePortfolioBlogComment(int id)
        {
            await _portfolioBlogCommentService.DeletePortfolioBlogCommentAsync(id);
            return RedirectToAction("GetAllPortfolioBlogComment", "PortfolioBlogComment",new {area = "Admin"});
        }

        [HttpGet("{id}")]
        [Route("GetByIdPortfolioBlogComment/{id}")]
        public async Task<IActionResult> GetByIdPortfolioBlogComment(int id)
        {
            var values = await _portfolioBlogCommentService.GetPortfolioBlogCommentByPortfolioBlogCommentIdAsync(id);
            return View(values);
        }
    }
}
