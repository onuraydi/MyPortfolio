using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogTagServices;

namespace Portfolio.WebUI.ViewComponents.BlogUILayoutComponents.ContentComponents
{
    public class _BlogGetBlogByTagContentBlogUILayoutComponentPartial:ViewComponent
    {
        private readonly IPortfolioBlogService _portfolioBlogService;
        private readonly IPortfolioBlogTagServices _portfolioBlogTagServices;

        public _BlogGetBlogByTagContentBlogUILayoutComponentPartial(IPortfolioBlogService portfolioBlogService, IPortfolioBlogTagServices portfolioBlogTagServices)
        {
            _portfolioBlogService = portfolioBlogService;
            _portfolioBlogTagServices = portfolioBlogTagServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int tagId = Convert.ToInt32(ViewData["TagId"]);
            var page = ViewData["TagPage"] != null ? Convert.ToInt32(ViewData["TagPage"]) : 1;
            var blogs = await _portfolioBlogService.GetBlogByTag(tagId);
            int pageSize = 12;
            int totalItem = blogs.Count;
            int totalPage = (int)Math.Ceiling(totalItem / (double)pageSize);

            var blogForPage = blogs.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.tagCurrentPage = page;
            ViewBag.tagTotalPage = totalPage;
            ViewBag.tagPageSize = pageSize;

            ViewBag.TagId = tagId;
            var tag = await _portfolioBlogTagServices.GetPortfolioBlogTagByPortfolioBlogTagIdAsync(tagId);
            var tagName = tag.TagName;
            ViewBag.TagName = tagName;
            return View(blogForPage);
        }
    }
}
