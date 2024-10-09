using Microsoft.AspNetCore.Mvc;

namespace Portfolio.WebUI.ViewComponents.BlogUILayoutComponents.ContentComponents
{
    public class _BlogAllCommentsContentBlogUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
