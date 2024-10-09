using Microsoft.AspNetCore.Mvc;

namespace Portfolio.WebUI.ViewComponents.BlogUIComponents
{
    public class _HeadBlogUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
