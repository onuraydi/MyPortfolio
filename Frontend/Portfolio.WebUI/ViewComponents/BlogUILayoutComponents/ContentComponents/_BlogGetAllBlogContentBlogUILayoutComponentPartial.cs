using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogServices;
using System.Runtime.InteropServices;

namespace Portfolio.WebUI.ViewComponents.BlogUILayoutComponents.ContentComponents
{
    public class _BlogGetAllBlogContentBlogUILayoutComponentPartial : ViewComponent
    {
        private readonly IPortfolioBlogService _portfolioBlogService;

        public _BlogGetAllBlogContentBlogUILayoutComponentPartial(IPortfolioBlogService portfolioBlogService)
        {
            _portfolioBlogService = portfolioBlogService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var page = ViewData["page"] != null ? Convert.ToInt32(ViewData["page"]) : 1;
            var allBlogs = await _portfolioBlogService.GetAllPortfolioBlogAsync();
            int pageSize = 12;
            int totalItems = allBlogs.Count;
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            
            var blogsForPage = allBlogs
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.PageSize = pageSize;

            return View(blogsForPage);
        }
    }
}
