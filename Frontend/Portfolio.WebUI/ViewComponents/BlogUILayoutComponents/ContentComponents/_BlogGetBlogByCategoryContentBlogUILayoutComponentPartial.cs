using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.BlogCategoryServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogServices;

namespace Portfolio.WebUI.ViewComponents.BlogUILayoutComponents.ContentComponents
{
    public class _BlogGetBlogByCategoryContentBlogUILayoutComponentPartial:ViewComponent
    {
        private readonly IPortfolioBlogService _portfolioBlogService;
        private readonly IBlogCategoryService _blogCategoryService;

        public _BlogGetBlogByCategoryContentBlogUILayoutComponentPartial(IPortfolioBlogService portfolioBlogService, IBlogCategoryService blogCategoryService)
        {
            _portfolioBlogService = portfolioBlogService;
            _blogCategoryService = blogCategoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int categoryId = Convert.ToInt32(ViewData["CategoryId"]);
            var page = ViewData["CategoryPage"] != null ? Convert.ToInt32(ViewData["CategoryPage"]) : 1;
            var blogs = await _portfolioBlogService.GetBlogByCategory(categoryId);
            int pageSize = 12;
            int totalItem = blogs.Count;
            int totalPage = (int)Math.Ceiling(totalItem / (double)pageSize);

            var blogForPage = blogs.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.categoryCurrentPage = page;
            ViewBag.categoryTotalPage = totalPage;
            ViewBag.categoryPageSize = pageSize;

            ViewBag.CategoryId = categoryId;
            var category = await _blogCategoryService.GetPortfolioBlogCategoryByIdAsync(categoryId);
            var categoryName = category.CategoryName;
            ViewBag.CategoryName = categoryName;
            return View(blogForPage);
        }
    }
}
