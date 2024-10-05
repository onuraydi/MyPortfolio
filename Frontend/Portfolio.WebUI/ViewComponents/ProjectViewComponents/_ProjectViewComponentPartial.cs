using Microsoft.AspNetCore.Mvc;

namespace Portfolio.WebUI.ViewComponents.ProjectViewComponents
{
    public class _ProjectViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
