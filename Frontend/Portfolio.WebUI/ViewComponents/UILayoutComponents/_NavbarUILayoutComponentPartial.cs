using Microsoft.AspNetCore.Mvc;

namespace Portfolio.WebUI.ViewComponents.UILayoutComponents
{
    public class _NavbarUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
