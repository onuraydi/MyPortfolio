using Microsoft.AspNetCore.Mvc;

namespace Portfolio.WebUI.ViewComponents.ExperienceViewComponents
{
    public class _ExperienceViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
