using Microsoft.AspNetCore.Mvc;

namespace Portfolio.WebUI.ViewComponents.HomeViewComponents
{
    public class _HomeViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
