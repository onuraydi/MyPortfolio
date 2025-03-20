using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.BlogCategoryServices;

namespace Portfolio.WebUI.ViewComponents.BlogUILayoutComponents.ContentComponents
{
    public class _BlogCategoryContentBlogUILayoutComponentPartial : ViewComponent 
    {
        private readonly IBlogCategoryService _blogCategoryService;

        public _BlogCategoryContentBlogUILayoutComponentPartial(IBlogCategoryService blogCategoryService)
        {
            _blogCategoryService = blogCategoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _blogCategoryService.GetAllPortfolioBlogCategoryAsync();
            return View(values);
        }
    }
}
