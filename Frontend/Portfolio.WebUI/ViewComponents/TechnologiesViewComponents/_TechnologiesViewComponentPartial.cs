using Microsoft.AspNetCore.Mvc;

namespace Portfolio.WebUI.ViewComponents.TechnologiesViewComponents
{
    public class _TechnologiesViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
