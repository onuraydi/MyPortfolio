using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Models;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogCommentServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogServices;

namespace Portfolio.WebUI.Controllers
{
    public class BlogDetailController : Controller
    {
        //private readonly IPortfolioBlogService _portfolioBlogService;
        private readonly IPortfolioBlogCommentService _portfolioBlogCommentService;

        public BlogDetailController(IPortfolioBlogCommentService portfolioBlogCommentService)
        {
            _portfolioBlogCommentService = portfolioBlogCommentService;
        }

        public async Task<IActionResult> GetBlogDetail(int id)
        {

            var values = await _portfolioBlogCommentService.GetPortfolioBlogCommentByPortfolioBlogIdAsync(id);


            ViewData["id"] = id;
            return View(values);
        }
    }
}
