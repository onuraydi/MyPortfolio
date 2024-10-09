using Microsoft.AspNetCore.Mvc;

namespace Portfolio.WebUI.ViewComponents.BlogUILayoutComponents
{
    public class _ContentBlogUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
