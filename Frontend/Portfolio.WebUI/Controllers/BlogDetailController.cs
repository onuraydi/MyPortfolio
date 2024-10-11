using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogServices;

namespace Portfolio.WebUI.Controllers
{
    public class BlogDetailController : Controller
    {
        private readonly IPortfolioBlogService _portfolioBlogService;

        public BlogDetailController(IPortfolioBlogService portfolioBlogService)
        {
            _portfolioBlogService = portfolioBlogService;
        }

        public async Task<IActionResult> GetBlogDetail(int id)
        {
            var values = await _portfolioBlogService.GetPortfolioBlogByPortfolioBlogIdAsync(id);
            return View(values);
        }
    }
}
