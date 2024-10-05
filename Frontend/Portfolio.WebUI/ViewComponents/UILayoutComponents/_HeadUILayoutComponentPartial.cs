using Microsoft.AspNetCore.Mvc;

namespace Portfolio.WebUI.ViewComponents.UILayoutComponents
{
    public class _HeadUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
