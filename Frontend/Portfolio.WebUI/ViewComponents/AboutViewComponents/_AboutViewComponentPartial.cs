using Microsoft.AspNetCore.Mvc;

namespace Portfolio.WebUI.ViewComponents.AboutViewComponents
{
    public class _AboutViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
