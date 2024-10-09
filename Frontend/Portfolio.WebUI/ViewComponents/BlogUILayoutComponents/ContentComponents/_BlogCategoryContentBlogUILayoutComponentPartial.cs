using Microsoft.AspNetCore.Mvc;

namespace Portfolio.WebUI.ViewComponents.BlogUILayoutComponents.ContentComponents
{
    public class _BlogCategoryContentBlogUILayoutComponentPartial : ViewComponent 
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
